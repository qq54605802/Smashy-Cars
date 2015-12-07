using UnityEngine;
using System.Collections;

[System.Serializable]
public struct ISSCBlockVector
{
	public int x;//{ set; get; }
	
	public int y;//{ set; get; }
	
	public int z;//{ set; get; }
	
	static public ISSCBlockVector zero { 
		get {
			return new ISSCBlockVector (0, 0, 0);
		} 
	}

	//-Lag 12060414
	static public ISSCBlockVector up { 
		get {
			return new ISSCBlockVector (0, 1, 0);
		} 
	}

	//-Lag 12060414
	static public ISSCBlockVector down { 
		get {
			return new ISSCBlockVector (0, -1, 0);
		} 
	}

	//-Lag 12060414
	static public ISSCBlockVector right { 
		get {
			return new ISSCBlockVector (1, 0, 0);
		} 
	}

	//-Lag 12060414
	static public ISSCBlockVector left { 
		get {
			return new ISSCBlockVector (-1, 0, 0);
		} 
	}

	//-Lag 12060414
	static public ISSCBlockVector forward { 
		get {
			return new ISSCBlockVector (0, 0, 1);
		} 
	}

	//-Lag 12060414
	static public ISSCBlockVector back { 
		get {
			return new ISSCBlockVector (0, 0, -1);
		} 
	}

	//-Lag 12060414
	static public ISSCBlockVector one { 
		get {
			return new ISSCBlockVector (1, 1, 1);
		} 
	}
	
	
	public ISSCBlockVector (int x, int y, int z)
	{
		this.x = x;
		this.y = y;
		this.z = z;
	}

	public ISSCBlockVector (float x, float y, float z)
	{
		this.x = Mathf.RoundToInt(x);
		this.y = Mathf.RoundToInt(y);
		this.z = Mathf.RoundToInt(z);
	}
	
	//-Lag 12060414
	public ISSCBlockVector (ISSCBlockVector bv)
	{
		this.x = bv.x;
		this.y = bv.y;
		this.z = bv.z;
	}

	public override string ToString ()
	{
		return string.Format ("[ISSCBlockVector:{0}, {1}, {2}]",x,y,z);
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
	
	//-Lag 12060414
	public static ISSCBlockVector operator + (ISSCBlockVector bv1, ISSCBlockVector bv2)
	{
		
		ISSCBlockVector bv = new ISSCBlockVector (bv1);
		bv.x += bv2.x;
		bv.y += bv2.y;
		bv.z += bv2.z;
		return bv;
	}
	
	public static ISSCBlockVector operator + (ISSCBlockVector bv1, int i)
	{
		
		ISSCBlockVector bv = new ISSCBlockVector (bv1);
		bv.x += i;
		bv.y += i;
		bv.z += i;
		return bv;
	}

	//-Lag 12060414
	public static ISSCBlockVector operator - (ISSCBlockVector bv1, ISSCBlockVector bv2)
	{
		
		ISSCBlockVector bv = new ISSCBlockVector (bv1);
		bv.x -= bv2.x;
		bv.y -= bv2.y;
		bv.z -= bv2.z;
		return bv;
	}
	
	public static ISSCBlockVector operator - (ISSCBlockVector bv1, int i)
	{
		
		ISSCBlockVector bv = new ISSCBlockVector (bv1);
		bv.x -= i;
		bv.y -= i;
		bv.z -= i;
		return bv;
	}
	
	//-Lag 12060414
	public static ISSCBlockVector operator * (ISSCBlockVector bv1, ISSCBlockVector bv2)
	{
		
		ISSCBlockVector bv = new ISSCBlockVector (bv1);
		bv.x *= bv2.x;
		bv.y *= bv2.y;
		bv.z *= bv2.z;
		return bv;
	}
	
	public static ISSCBlockVector operator * (ISSCBlockVector bv1, int i)
	{
		
		ISSCBlockVector bv = new ISSCBlockVector (bv1);
		bv.x *= i;
		bv.y *= i;
		bv.z *= i;
		return bv;
	}
	
	//-Lag 12060414
	public static ISSCBlockVector operator / (ISSCBlockVector bv1, ISSCBlockVector bv2)
	{
		
		ISSCBlockVector bv = new ISSCBlockVector (bv1);
		bv.x /= bv2.x;
		bv.y /= bv2.y;
		bv.z /= bv2.z;
		return bv;
	}
	
	public static ISSCBlockVector operator / (ISSCBlockVector bv1, int i)
	{
		
		ISSCBlockVector bv = new ISSCBlockVector (bv1);
		bv.x /= i;
		bv.y /= i;
		bv.z /= i;
		return bv;
	}
}
