using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	public tk2dTileMap tileMap;

	//TODO get this data from location
	float sunrise=14080000;
	float sunset=14080000;
	float sky=200;
	float temp=282;
	float windspeed=1;
	float humidity=81;
	

	void Start(){


		//Floor
		int floorTileId = 0;
		for(int i = 0; i < tileMap.width;i++){
			for(int j = 0; j < tileMap.height;j++){
				tileMap.Layers[0].SetTile(i,j,floorTileId);
				if(Random.Range(0,300)>sky) {
					tileMap.Layers[1].SetTile(i,j,Random.Range(1,10));
				}
			}
		}

		//World Borders
		int borderTileId = 10;
		for(int x = 0;x < tileMap.width;x++){
			tileMap.Layers[5].SetTile(x,0,borderTileId);
			tileMap.Layers[5].SetTile(x,tileMap.height-1,borderTileId);
		}
		for(int y = 0;y < tileMap.height;y++){
			tileMap.Layers[5].SetTile(0,y,borderTileId);
			tileMap.Layers[5].SetTile(tileMap.width-1,y,borderTileId);
		}

		//Perlin noise mesetas
		for(int x = 0; x < tileMap.width; x++){
			for(int y = 0; y < tileMap.width; y++){
				if(Mathf.PerlinNoise(x*.07f,y*.07f) < .3f){
					tileMap.Layers[5].SetTile(x,y,borderTileId);
				}
			}
		}
		//Add bottom to mesetas



		tileMap.Build();
	}



}
