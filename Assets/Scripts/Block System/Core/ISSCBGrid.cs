using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ISSCBGrid : Object
{
	public static readonly float ISSC_BLOCK_UNIT_SIZE = 1;
	protected int[] blocks;
	public readonly ISSCBlockVector gridSize;

	/// <summary>
	/// Initializes a new instance of the <see cref="ISSCBGrid"/> class with specific size.
	/// </summary>
	/// <param name="size">Size.</param>
	public ISSCBGrid (ISSCBlockVector size)
	{
		if (!(size.x > 0))
			size.x = 1;
		if (!(size.y > 0))
			size.y = 1;
		if (!(size.z > 0))
			size.z = 1;

		gridSize = size;

		blocks = new int[gridSize.Length ()];
	}
	
	public ISSCBGrid (ISSCBGridDescriber describer)
	{
		gridSize = describer.size;
		
		blocks = new int[gridSize.Length ()];
		SetBlock (GetCenterBlock (), describer.centerBlock);
	}

	public int[] GetRawData ()
	{
		return blocks;
	}

	/// <summary>
	/// Determines whether this position is available in grid.
	/// </summary>
	/// <returns><c>true</c> if this position is available; otherwise, <c>false</c>.</returns>
	/// <param name="position">Position.</param>
	public bool IsBlockAvailable (ISSCBlockVector position)
	{
		bool result = ISMath.Contains (position.x, 0, gridSize.x)
			|| ISMath.Contains (position.y, 0, gridSize.y)
			|| ISMath.Contains (position.y, 0, gridSize.y);

		return result;
	}
	
	public int EncodeIndex (ISSCBlockVector position)
	{
		int xIndex = position.x;
		int yIndex = position.y * gridSize.x;
		int zIndex = position.z * gridSize.x * gridSize.y;
		return xIndex + yIndex + zIndex;
	}

	public ISSCBlockVector DecodeIndex (int id)
	{

		//int index = position.x + position.y * gridSize.x + position.z * gridSize.x * gridSize.y;

		int z = id / (gridSize.x * gridSize.y);
		int y = (id % (gridSize.x * gridSize.y)) / gridSize.x;
		int x = (id % (gridSize.x * gridSize.y)) % gridSize.x / 1;
		return new ISSCBlockVector (x, y, z);
	}


	/// <summary>
	/// Set block's ID to change a block in specific position to another block.
	/// </summary>
	/// <returns>Error code if any error ocurred, otherwise return the previous ID of the block.</returns>
	/// <param name="position">Position.</param>
	/// <param name="blockID">Block ID.</param>
	public int SetBlock (ISSCBlockVector position, int blockID)
	{
		
		if (!IsBlockAvailable (position)) {
			Debug.LogError ("Block IO Exception: Out of range.");
			return -1;
		}

		int encodedIndex = EncodeIndex (position);

		int previousID = blocks [encodedIndex];
		blocks [encodedIndex] = blockID;

		return previousID;
	}

	/// <summary>
	/// Get blocks's ID with a specific position
	/// </summary>
	/// <returns>ID of the block.</returns>
	/// <param name="position">Position.</param>
	public int GetBlock (ISSCBlockVector position)
	{
		if (!IsBlockAvailable (position)) {
			Debug.LogError ("Block IO Exception: Out of range.");
			return -1;
		}
	
		return blocks [EncodeIndex (position)];
	}

	public ISSCBlockVector GetCenterBlock ()
	{
		return new ISSCBlockVector (gridSize.x / 2, gridSize.y / 2, gridSize.y / 2);
	}

	/// <summary>
	/// Check if the block is empty.
	/// </summary>
	/// <returns><c>true</c>, if blocks ID is 0, <c>false</c> otherwise.</returns>
	/// <param name="position">Position.</param>
	public bool IsBlockEmpty (ISSCBlockVector position)
	{
		int blockID = GetBlock (position);

		try {
			if (blockID == -1)
				throw new System.Exception ("Block position out of grid.");
		} catch (System.Exception e) {
			Debug.Log (e.Message);
		}


		return blockID == 0;
	}
	
	//Check Block's Direction Nearby Is Empty ,Empty Return True, Or Not Return False
	public bool IsNearByEmpty (ISSCBlockVector position, BlockDirection direction)
	{
		ISSCBlockVector tmpBV = position;

		switch (direction) {
		case BlockDirection.Up: 
			tmpBV.y += 1;
			return IsBlockEmpty (tmpBV);
		case BlockDirection.Down: 
			tmpBV.y -= 1;
			return IsBlockEmpty (tmpBV);
		case BlockDirection.Right: 
			tmpBV.x += 1;
			return IsBlockEmpty (tmpBV);
		case BlockDirection.Left: 
			tmpBV.x -= 1;
			return IsBlockEmpty (tmpBV);
		case BlockDirection.Forward: 
			tmpBV.z += 1;
			return IsBlockEmpty (tmpBV);
		case BlockDirection.Back: 
			tmpBV.z -= 1;
			return IsBlockEmpty (tmpBV);
		default :
			return false;
		}
	}
	
	public bool IsBlockVisiable(ISSCBlockVector position){
		for (int i = 0; i < 6; i++) {
			if(IsNearByEmpty(position,(BlockDirection)i)) return true;
		}
		return false;
	}

	//Set Block Near Position's Direction With BlockID
	public void SetBlockNearBy (ISSCBlockVector position, BlockDirection direction, int blockID)
	{
		ISSCBlockVector tmpBV = new ISSCBlockVector ();
		tmpBV = position;
		switch (direction) {
		case BlockDirection.Up: 
			tmpBV.y += 1;
			SetBlock (tmpBV, blockID);
			break;
		case BlockDirection.Down: 
			tmpBV.y -= 1;
			SetBlock (tmpBV, blockID);
			break;
		case BlockDirection.Right: 
			tmpBV.x += 1;
			SetBlock (tmpBV, blockID);
			break;
		case BlockDirection.Left: 
			tmpBV.x -= 1;
			SetBlock (tmpBV, blockID);
			break;
		case BlockDirection.Forward: 
			tmpBV.z += 1;
			SetBlock (tmpBV, blockID);
			break;
		case BlockDirection.Back: 
			tmpBV.z -= 1;
			SetBlock (tmpBV, blockID);
			break;
		}
	}
	
	//Get Blocks' Position In A Cube Zone Between Position1 And Position2
	public ISSCBlockVector[] BlocksInRange (ISSCBlockVector position1, ISSCBlockVector position2)
	{
		ISSCBlockVector tmpBV = new ISSCBlockVector (Mathf.Min (position1.x, position2.x), Mathf.Min (position1.y, position2.y), Mathf.Min (position1.z, position2.z));
		
		ISSCBlockVector loopTmpBV;
		
		int xSize = Mathf.Abs (position1.x - position2.x) + 1;
		int ySize = Mathf.Abs (position1.y - position2.y) + 1;
		int zSize = Mathf.Abs (position1.z - position2.z) + 1;
		
		List<ISSCBlockVector> l = new List<ISSCBlockVector> ();
				
		for (int z =0; z < zSize; z++) {
			for (int y = 0; y <ySize; y++) {
				for (int x = 0; x <xSize; x++) {
					loopTmpBV = new ISSCBlockVector (tmpBV.x + x, tmpBV.y + y, tmpBV.z + z);
					if (IsBlockAvailable (loopTmpBV)) {
						l.Add (loopTmpBV);
					}
				}
			}
		}
		return l.ToArray ();
	}
	
	//Get Blocks' Position In A Sphere Zone Around Position In Radius
	public ISSCBlockVector[] BlocksInRange (ISSCBlockVector position, float radius)
	{
		ISSCBlockVector position1 = new ISSCBlockVector (position.x - (int)radius, position.y - (int)radius, position.z - (int)radius);
		ISSCBlockVector position2 = new ISSCBlockVector (position.x + (int)radius, position.y + (int)radius, position.z + (int)radius);
		ISSCBlockVector[] bvs = BlocksInRange (position1, position2);
		List<ISSCBlockVector> l = new List<ISSCBlockVector> ();
		foreach (ISSCBlockVector bv in bvs) {
			if (ISSCBlockVector.Distance (position, bv) < radius && IsBlockAvailable (bv)) {
				l.Add (bv);
			}
		}
		return l.ToArray ();
	}
	
	//-L 12051052
	public static Vector3 GridPositionToWorldPosition (ISSCBlockVector position, Vector3 gridOriginInWorld)
	{
//		ISSC_BLOCK_UNIT_SIZE
		return new Vector3 (gridOriginInWorld.x + position.x * ISSC_BLOCK_UNIT_SIZE,
		gridOriginInWorld.y + position.y * ISSC_BLOCK_UNIT_SIZE,
		gridOriginInWorld.z + position.z * ISSC_BLOCK_UNIT_SIZE);
	
	}
}

[System.Serializable]
public struct ISSCBGridDescriber
{
	public ISSCBlockVector size;
	public int centerBlock;
}

public enum BlockDirection
{
	Up,
	Down,
	Right,
	Left,
	Forward,
	Back
}

