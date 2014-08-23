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

		int borderTileId = 55;

		for(int i = 0; i < tileMap.width;i++){
			for(int j = 0; j < tileMap.height;j++){
				tileMap.Layers[0].SetTile(i,j,0);
				if(Random.Range(0,300)>sky) {
					tileMap.Layers[1].SetTile(i,j,1+Random.Range(0,4));
				}
			}
		}

		//World Borders
		for(int x = 0;x < tileMap.width;x++){
			tileMap.Layers[1].SetTile(x,0,borderTileId);
			tileMap.Layers[1].SetTile(x,tileMap.height-1,borderTileId);
		}
		for(int y = 0;y < tileMap.height;y++){
			tileMap.Layers[1].SetTile(0,y,borderTileId);
			tileMap.Layers[1].SetTile(tileMap.width-1,y,borderTileId);
		}



		tileMap.Build();
	}

}
