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
					tileMap.Layers[5].SetTile(x,y,41);
					if(tileMap.GetTile(x-1,y,5) <0 && tileMap.GetTile(x,y-1,5)<0) {
						tileMap.Layers[5].SetTile(x,y,32);
					} 


				}
			}
		}
		//Add bottom to mesetas
		for(int x = 0; x < tileMap.width; x++){
			for(int y = 0; y < tileMap.width; y++){
				int tileid=tileMap.GetTile(x,y,5);
				if(tileid>0 && y>1 && y<tileMap.height) {
					Debug.Log(tileid);
					if(tileMap.GetTile(x,y-1,5)<0) {
						tileMap.Layers[5].SetTile(x,y-1,43);
						tileMap.Layers[5].SetTile(x,y-2,45);
					

					}
				}
			}
		}

		// left and right borders
		for(int x = 0; x < tileMap.width; x++){
			for(int y = 0; y < tileMap.width; y++){
				int tileid=tileMap.GetTile(x,y,5);
				if(y>1 && y<tileMap.height) {
					if(tileid==41) {
						// top
						if(tileMap.GetTile(x-1,y,5)<0 && tileMap.GetTile(x,y+1,5)<0) {
							tileMap.Layers[5].SetTile(x,y,30);
						}
					}
					if(tileid==43) {
						// middle
						if(tileMap.GetTile(x-1,y,5)<0) {
							tileMap.Layers[5].SetTile(x,y,33);
							tileMap.Layers[5].SetTile(x,y+1,32);

						} else if(tileMap.GetTile(x+1,y,5)<0) {
							tileMap.Layers[5].SetTile(x,y,54);
						}
					}
					if(tileid==45) {
						// bottom
						if(tileMap.GetTile(x-1,y,5)<0) {
							tileMap.Layers[5].SetTile(x,y,35);
						} else if(tileMap.GetTile(x+1,y,5)<0) {
							tileMap.Layers[5].SetTile(x,y,55);
						}
					}
				}

			}
		}
		
		tileMap.ForceBuild();
	}


}
