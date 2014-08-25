using UnityEngine;
using System.Collections;

public class CardUtility {
	public static string GetCardName(int cardID){
		if(cardID == 0) return "SUN";
		else if(cardID == 1) return "RAIN";
		else if(cardID == 2) return "ICE";
		else if(cardID == 3) return "EARTH";
		else if(cardID == 4) return "WIND";

		return "null";
	}
}
