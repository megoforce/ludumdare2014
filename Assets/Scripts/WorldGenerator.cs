using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	public tk2dTileMap tileMap;

	void Start(){
		for(int i = 0; i < 32;i++){
			for(int j = 0; j < 32;j++){
				tileMap.Layers[0].SetTile(i,j,1);
			}

		}
		tileMap.Build();
	}

}
