using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	public tk2dTileMap tileMap;
	
	public void GenerateWorld(float temperature, float humidity, float pressure, string skyname){
		
		//Floor
		int floorTileId = 0;
		for(int i = 0; i < tileMap.width;i++){
			for(int j = 0; j < tileMap.height;j++){
				tileMap.Layers[0].SetTile(i,j,floorTileId);
				if(Random.Range(0,300)>200) {
					tileMap.Layers[1].SetTile(i,j,0);
					if(Random.Range(0,humidity)>64) {
						tileMap.Layers[1].SetTile(i,j,7);
					} 
					if(Random.Range(0,humidity)<32) {
						tileMap.Layers[1].SetTile(i,j,1);
					} else if (Random.Range(0,humidity)<1) {
						tileMap.Layers[1].SetTile(i,j,14);
					}


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
					tileMap.Layers[5].SetTile(x,y,10);



				}
			}
		}
		//Add bottom to mesetas
		for(int x = 0; x < tileMap.width; x++){
			for(int y = 0; y < tileMap.width; y++){
				int tileid=tileMap.GetTile(x,y,5);
				if(tileid>0 && y>1 && y<tileMap.height) {
					//Debug.Log(tileid);
					if(tileMap.GetTile(x,y-1,5)<0) {
						tileMap.Layers[5].SetTile(x,y-1,22);
						tileMap.Layers[5].SetTile(x,y-2,28);
					

					}
				}
			}
		}


		
		tileMap.ForceBuild();
	}


}
