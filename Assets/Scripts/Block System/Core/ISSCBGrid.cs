using UnityEngine;
using System.Collections;

public class ISSCBGrid : Object {

	protected int[] blocks;

	protected ISSCBlockVector gridSize;

	public ISSCBGrid(ISSCBlockVector size){
		gridSize = size;

		blocks = new int[gridSize.Length()];
	}

	public int SetBlock(ISSCBlockVector position, int blockID){
		int xIndex = position.x;
		int yIndex = position.y * gridSize.x;
		int zIndex = position.z * gridSize.x * gridSize.y;

		int previousID = blocks [xIndex + yIndex + zIndex];

		blocks [xIndex + yIndex + zIndex] = blockID;

		return previousID;
	}

	public int GetBlock(ISSCBlockVector position){
		int xIndex = position.x;
		int yIndex = position.y * gridSize.x;
		int zIndex = position.z * gridSize.x * gridSize.y;
		return blocks [xIndex + yIndex + zIndex];
	}

}

[System.Serializable]
public struct ISSCBlockVector{
	public int x,y,z;

	public ISSCBlockVector(int x, int y, int z){
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public int Length(){
		return x * y * z;
	}
}
