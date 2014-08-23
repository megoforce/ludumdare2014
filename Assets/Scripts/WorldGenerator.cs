using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	public tk2dTileMap tileMap;
	float sunrise=14080000;
	float sunset=14080000;
	float sky=200;
	float temp=282;
	float windspeed=1;
	float humidity=81;
	

	void Start(){
		for(int i = 0; i < 32;i++){
			for(int j = 0; j < 32;j++){
				tileMap.Layers[0].SetTile(i,j,0);
				if(Random.Range(0,300)>sky) {
					tileMap.Layers[1].SetTile(i,j,1+Random.Range(0,4));
				}


			}

		}
		tileMap.Build();
	}

}
