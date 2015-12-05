using UnityEngine;
using System.Collections;

[System.Serializable]
public struct ISSCBlockVector
{
	public int x;//{ set; get; }
	
	public int y;//{ set; get; }
	
	public int z;//{ set; get; }

	static public ISSCBlockVector zero{ 
		get{
			return new ISSCBlockVector(0,0,0);
		} 
	}
	
	public ISSCBlockVector (int x, int y, int z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}
	
	public int Length ()
	{
		return x * y * z;
	}
	

	static public float RealWorldDistance (ISSCBlockVector a, ISSCBlockVector b)
	{
		float distancex = (float)(a.x - b.x);
		float distancey = (float)(a.y - b.y);
		float distancez = (float)(a.z - b.z);
		return Mathf.Sqrt (Mathf.Pow (distancex, 2f) + Mathf.Pow (distancey, 2f) + Mathf.Pow (distancez, 2f));
	}

	static public int Distance (ISSCBlockVector a, ISSCBlockVector b)
	{
		int distancex = a.x - b.x;
		int distancey = a.y - b.y;	
		int distancez = a.z - b.z;
		return (int)Mathf.Sqrt (Mathf.Pow (distancex, 2f) + Mathf.Pow (distancey, 2f) + Mathf.Pow (distancez, 2f));
	}
}
