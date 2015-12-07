using UnityEngine;
using System.Collections;

public class ISMath {

	static public bool Contains(float value, float a, float b){
		return (value >= a) && (value <= b);
	}

	static public bool Contains(float value, ISRange range){
		return ISMath.Contains(value,range.min,range.max);
	}

	static public Vector2 RotateVector(Vector2 v, float angle){
		return new Vector2 (v.x * Mathf.Cos (angle) - v.y * Mathf.Sin (angle), v.x * Mathf.Sin (angle) + v.y * Mathf.Cos (angle));
	}

	static public Vector3 RotateVectorXZ(Vector3 v, float angle){
		return new Vector3 (v.x * Mathf.Cos (angle) - v.z * Mathf.Sin (angle), 0, v.x * Mathf.Sin (angle) + v.z * Mathf.Cos (angle));
	}

	static public Vector3 ChangeLengthTo(Vector3 v, float s){
		float f = s/v.magnitude;
		return v * f;
	}

	static public Vector3 Clip2NormalDirection(Vector3 d){
		float[] values = new float[3];
		values [0] = d.x;
		values [1] = d.y;
		values [2] = d.z;

		float max = Mathf.Infinity;
		int maxID = -1;
		for (int i = 0; i < values.Length; i++) {
			if(Mathf.Abs(values[i]) < max){
				max = values[i];
				maxID = i;
			}
			values[i] = 0;
		}

		values [maxID] = max;

		d.x = values [0];
		d.y = values [1];
		d.z = values [2];

		return d;
	}

	static public float Clamp(float v, ISRange range){
		return Mathf.Clamp (v, range.min, range.max);
	}

	static public Vector3 ClampLength(Vector3 v, ISRange range){
		float l = v.magnitude;
		if(l < range.min) return ISMath.ChangeLengthTo(v,range.min);
		if(l > range.max) return ISMath.ChangeLengthTo(v,range.max);
		return v;
	}

	static public float MapToZeroAndOne(float min, float max, float value){
		return value / (max - min);
	}

	static public float Random(ISRange range){
		return UnityEngine.Random.Range (range.min, range.max);
	}

	public enum ISMath_BoundCompareResult{Contains, Larger, Lower}
	static public ISMath_BoundCompareResult BoundCompare(float value, float a, float b){
		if(value > b) return ISMath_BoundCompareResult.Larger;
		else if(value < a) return ISMath_BoundCompareResult.Lower;

		return ISMath_BoundCompareResult.Contains;
	}

	public class WaveNumberGenerater {
		public float numberMax;
		public float numberMin;
		public float translation;
		public float cycleOffseter;

		public WaveNumberGenerater (float min, float max, float offset){
			numberMax = max;
			numberMin = min;
			cycleOffseter = offset;
			translation = UnityEngine.Random.Range(0,2*Mathf.PI/Mathf.Abs(cycleOffseter));
		}

		public float NumberForTime(float time){
			return ((numberMax-numberMin)/2) * Mathf.Sin (time * cycleOffseter + translation) + ((numberMax + numberMin)/2f);
		}
	}
}

[System.Serializable]
public struct ISRange{
	public float min,max;

	public ISRange(float min, float max){
		this.min = min;
		this.max = max;
	}
}
