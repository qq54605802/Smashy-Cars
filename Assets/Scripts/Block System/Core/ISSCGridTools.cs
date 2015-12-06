using UnityEngine;
using System.Collections;

#region -L 12060208
public enum ModuleType
{
	Sphere,
	Cube,
	Cone,
	Cylinder
}

public class ISSCGridTools
{

	public static bool CreatePrimitive (ISSCBGrid grid, ModuleType moduleType, int blockID, ISSCBlockVector origin, float radius)
	{
		if (moduleType != ModuleType.Sphere)
			return false;
		if (!grid.IsBlockAvailable (origin))
			return false;
		if (radius <= 0)
			return false;
			
			ISSCBlockVector[] bvs = grid.BlocksInRange(origin,radius);
			foreach(ISSCBlockVector bv in bvs){
			grid.SetBlock(bv,blockID);
			}
			//
			
		return true;

		
	}
	
	public static bool CreatePrimitive (ISSCBGrid grid, ModuleType moduleType, int blockID, ISSCBlockVector position1, ISSCBlockVector position2)
	{
		if (moduleType != ModuleType.Cube)
			return false;
		if (!grid.IsBlockAvailable (position1))
			return false;
		if (!grid.IsBlockAvailable (position2))
			return false;
			
		ISSCBlockVector[] bvs = grid.BlocksInRange(position1,position2);
		foreach(ISSCBlockVector bv in bvs){
			grid.SetBlock(bv,blockID);
		}
		//
		
		
		return true;

		
	}

//	public static bool CreatePrimitive (ISSCBGrid grid, ModuleType moduleType, ISSCBlockVector origin, float radius, float height,Vector3 direction)
//	{
//		if (moduleType != ModuleType.Cone)
//			return false;
//		if (!grid.IsBlockAvailable (origin))
//			return false;
//		if (radius <= 0 || height <= 0)
//			return false;
//		return true;
//
//		
//	}

	public static bool CreatePrimitive (ISSCBGrid grid, ModuleType moduleType, int blockID, ISSCBlockVector origin, float radius, float height)
	{
		if (moduleType != ModuleType.Cylinder)
			return false;
		if (!grid.IsBlockAvailable (origin))
			return false;
		if (radius <= 0 || height <= 0)
			return false;
			
		ISSCBlockVector[] bvs = grid.BlocksInRange(origin,radius,height);
		foreach(ISSCBlockVector bv in bvs){
			grid.SetBlock(bv,blockID);
		}
		//
		
		return true;

	}
}
#endregion