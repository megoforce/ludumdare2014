using UnityEngine;
using System.Collections;

public class WorldGenerator : MonoBehaviour {
	public tk2dTileMap tileMap;
	public CameraFilterPack_Colors_HUE_Rotate hueCamera;

	public void GenerateWorld(float temperature, float humidity, float pressure, string skyname,float lat, float lng){
		
		//Floor
		int floorTileId = 0;
		for(int i = 0; i < tileMap.width;i++){
			for(int j = 0; j < tileMap.height;j++){
				tileMap.Layers[0].SetTile(i,j,floorTileId);
				if(Random.Range(0,humidity)>64) {

				}
				// muy humedo
				if(Random.Range(0,128)<humidity) {
					if((Random.Range(0,128)<temperature) && temperature>8) {
						tileMap.Layers[1].SetTile(i,j,7);
					} else if(Random.Range(0,16)==1 && temperature>4) {
						tileMap.Layers[1].SetTile(i,j,13);
					}
				} else if(Random.Range(0,16)==1 && temperature>0) {
					// piedras
					tileMap.Layers[1].SetTile(i,j,1);
					if(Random.Range(0,4)==1 && temperature>4) {
						tileMap.Layers[1].SetTile(i,j,1);
					} else if(Random.Range(0,2)==1 && temperature>8) {
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
				if(Mathf.PerlinNoise(x*.07f+Mathf.Round(lat),y*.07f+Mathf.Round(lng)) < .3f){
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

		SetTemperatureColor(temperature);
	}

	void SetTemperatureColor(float temp){


		temp = Mathf.Min(Mathf.Max(-20,temp),40);
		float r = (temp+20f) / 60f;
		hueCamera.HUE = Mathf.Lerp(2.61f,6.24f,r);
		print("Temp = "+temp+ " HUE:"+hueCamera.HUE+" r:"+r);
	}
}
