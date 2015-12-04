using UnityEngine;
using System.Collections;

public enum Layers
{
	CreatingCube,
	Cube,
	Module,
	Environment
}

public class DesinerController : MonoBehaviour
{

	public static int GetLayer (Layers l)
	{
		switch (l) {
		case Layers.CreatingCube:
			return LayerMask.NameToLayer ("CreatingCube");
		case Layers.Cube:
			return LayerMask.NameToLayer ("Cube");
		case Layers.Module:
			return LayerMask.NameToLayer ("Module");
		case Layers.Environment:
			return LayerMask.NameToLayer ("Environment");

		}
		return LayerMask.NameToLayer ("Default");
	}
}
