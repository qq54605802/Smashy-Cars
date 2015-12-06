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

public class ISSCGridPrimitiveShapeUtilities
{

	public static void CreateSphere (ISSCBGrid grid, ISSCBlockVector origin, int fillWith, float radius)
	{

		if (!grid.IsBlockAvailable (origin)) {
			Debug.LogError("Failed to create primitive : Not enough spaces");
			return;
		}
		if (radius <= 0) return;
			
		ISSCBlockVector[] bvs = grid.BlocksOverlapSphere(origin,radius);
		foreach(ISSCBlockVector bv in bvs){
			grid.SetBlock(bv,fillWith);
		}
	}
	
	public static void CreateCube (ISSCBGrid grid, int fillWith, ISSCBlockVector from, ISSCBlockVector to)
	{
		if (!grid.IsBlockAvailable (from)) return;
		if (!grid.IsBlockAvailable (to)) return;
			
		ISSCBlockVector[] bvs = grid.BlocksOverlapCube(from,to);
		foreach(ISSCBlockVector bv in bvs){
			grid.SetBlock(bv,fillWith);
		}

		return;
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

	public static void CreateCylinder (ISSCBGrid grid, int fillWith, ISSCBlockVector origin, float radius, float height)
	{
		if (!grid.IsBlockAvailable (origin)) return;
		if (radius <= 0 || height <= 0) return;
			
		ISSCBlockVector[] bvs = grid.BlocksOverlapCylinder(origin,radius,height);
		foreach(ISSCBlockVector bv in bvs){
			grid.SetBlock(bv,fillWith);
		}
		
		return;

	}
}
#endregion