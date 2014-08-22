using UnityEngine;
using System.Collections;

public static class RandomExt  {
	
	public static int RandomRangeExcept(int min, int max, int except){
		int r = Random.Range(min,max-1);
		return (r < except) ? r : r+1;
	}
	
	public static float RandomFloatBetween(float min, float max){
		return (min + (max-min)*Random.value);
	}
}
