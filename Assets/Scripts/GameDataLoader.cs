using UnityEngine;
using System.Collections;
using SimpleJSON;


public class GameDataLoader : MonoBehaviour {
	public bool forceReset = false;
	public WorldGenerator worldGenerator;

	public float lat;
	public float lng;
	public string country;
	string weatherName;
	public string skyname;
	public float temperature;
	public float humidity;
	public float pressure;
	public float weather;

	IEnumerator Start() {
		Debug.Log ("Searching for weather data...");
		
		GlobalStuff.instance.gUIManager.labelTop.text = "CONNECTING...";
		GlobalStuff.instance.gUIManager.labelBottom.text = "";
		int[,] worlds = {
			{27,78},
			{-37,-64},
			{-42,-71},
			{36,-120},
			{38,-70},
			{47,18},
			{-29,16},
			{-28,132},
			{16,143},
			{-9,-54},
			{24,-99},
			{-17,-59},
			{-27,70},
			{23,11},
			{33,-116},
			{36,-113},
			{-75,0},
						{-80,-180},
						{70,-180},

						{60,-160},
						{70,-160},
						{60,-140},
						{70,-140},
						 {
								40,
								-120
						},
						 {
								50,
								-120
						},
						 {
								60,
								-120
						},
						 {
								70,
								-120
						},
						
						 {
								20,
								-100
						},
						 {
								30,
								-100
						},
						 {
								40,
								-100
						},
						 {
								50,
								-100
						},
						 {
								60,
								-100
						},
						 {
								70,
								-100
						},
						 {
								80,
								-100
						},
						
						 {
								0,
								-80
						},
						 {
								40,
								-80
						},
						 {
								50,
								-80
						},
						 {
								60,
								-80
						},
						 {
								70,
								-80
						},
						 {
								80,
								-80
						},
						 {
								90,
								-80
						},
						 {
								0,
								-60
						},
						 {
								50,
								-60
						},
						 {
								80,
								-60
						},
						 {
								90,
								-60
						},
						 {
								60,
								-40
						},
						 {
								70,
								-40
						},
						 {
								80,
								-40
						},
						 {
								90,
								-40
						},
						 {
								80,
								-20
						},
						 {
								90,
								-20
						},
						 {
								10,
								0
						},
						 {
								20,
								0
						},
						 {
								30,
								0
						},
						 {
								40,
								0
						},
						 {
								90,
								0
						},
						 {
								0,
								20
						},
						 {
								10,
								20
						},
						 {
								20,
								20
						},
						 {
								30,
								20
						},
						 {
								40,
								20
						},
						 {
								50,
								20
						},
						 {
								60,
								20
						},
						 {
								70,
								20
						},
						 {
								80,
								20
						},
						 {
								90,
								20
						},
						 {
								0,
								40
						},
						 {
								10,
								40
						},
						 {
								30,
								40
						},
						 {
								40,
								40
						},
						 {
								50,
								40
						},
						 {
								60,
								40
						},
						 {
								90,
								40
						},
						 {
								30,
								60
						},
						 {
								40,
								60
						},
						 {
								50,
								60
						},
						 {
								60,
								60
						},
						 {
								70,
								60
						},
						 {
								80,
								60
						},
						 {
								90,
								60
						},
						 {
								20,
								80
						},
						 {
								30,
								80
						},
						 {
								40,
								80
						},
						 {
								50,
								80
						},
						 {
								60,
								80
						},
						 {
								70,
								80
						},
						 {
								80,
								80
						},
						 {
								90,
								80
						},
						 {
								0,
								100
						},
						 {
								10,
								100
						},
						 {
								20,
								100
						},
						 {
								30,
								100
						},
						 {
								40,
								100
						},
						 {
								50,
								100
						},
						 {
								60,
								100
						},
						 {
								70,
								100
						},
						 {
								80,
								100
						},
						 {
								90,
								100
						},
						 {
								0,
								120
						},
						 {
								10,
								120
						},
						 {
								30,
								120
						},
						 {
								40,
								120
						},
						 {
								50,
								120
						},
						 {
								60,
								120
						},
						 {
								70,
								120
						},
						 {
								90,
								120
						},
						 {
								10,
								140
						},
						 {
								40,
								140
						},
						 {
								50,
								140
						},
						 {
								60,
								140
						},
						 {
								70,
								140
						},
						 {
								90,
								140
						},
						 {
								60,
								160
						},
						 {
								70,
								160
						},
						 {
								90,
								160
						},
						 {
								70,
								180
						},
						 {
								90,
								180
						}
				};

		int rand = Random.Range (0, 100);
		Debug.Log ("WORLD #"+rand);



		lat = worlds[rand, 0]-10+RandomExt.RandomFloatBetween(0,20);
		lng = worlds[rand, 1]-10+RandomExt.RandomFloatBetween(0,20);
		if (lat > 90)
				lat = 90;
		if(lng>180) lng = 180;
		if (lat < -90) {
						lat = lat + 60;
				}
		if(lng<-180) {
				lng=lng+90;
			}
		Debug.Log (lat);
		string url = "http://api.openweathermap.org/data/2.5/weather?lat=" + lat.ToString () + "&lon=" + lng.ToString ()+"&units=metric";
		Debug.Log(url);
		WWW request = new WWW(url);
		Debug.Log (request);
		yield return request;

		if (request.error == null || request.error == "")
		{
			// {"coord":{"lon":"-94.61", "lat":"41.63"}
			// "sys":{"type":"1", "id":"848", "message":"0.1384", "country":"US", "sunrise":"1408793759", "sunset":"1408842346"}
			// "weather":[ {"id":"802", "main":"Clouds", "description":"scattered clouds", "icon":"03d"} ]
			// "base":"cmc stations"
			// "main":{"temp":"300.46", "pressure":"1013", "humidity":"83", "temp_min":"299.15", "temp_max":"302.15"}
			// "wind":{"speed":"3.6", "deg":"160"}
			// "clouds":{"all":"40"}
			// "dt":"1408822294"
			// "id":"4859491"
			// "name":"Guthrie Center"
			// "cod":"200"}


			var N = JSON.Parse(request.text);
			
			Debug.Log(N);
			country=N["sys"]["country"].Value;
			temperature=float.Parse(N["main"]["temp"].Value);
			humidity=float.Parse(N["main"]["humidity"].Value);
			pressure=float.Parse(N["main"]["pressure"].Value);

			weatherName=N["name"];
			Debug.Log(N["weather"][0]["id"].Value);

			weather=float.Parse(N["weather"][0]["id"].Value);
			skyname=N["weather"][0]["main"].Value;

			GlobalStuff.instance.gUIManager.labelTop.text = ""+lat.ToString()+","+lng.ToString()+" "+weatherName.ToUpper()+", "+country;
			GlobalStuff.instance.gUIManager.labelBottom.text = "TEMP:"+Mathf.Round(temperature).ToString()+"C HUMIDITY:"+humidity.ToString()+" PRESSURE: "+pressure.ToString()+" SKY:"+skyname.ToUpper();

			StartCoroutine(GlitchesOff());
			GlobalStuff.instance.enemyGenerator.GenerateEnemies();
		}
		else
		{
			Debug.Log("WWW error: " + request.error);
		}


	}
	void Awake(){
		if(PlayerPrefs.GetInt("isNotFirstTime") != 1 || forceReset){
			print("Is first time");
			ResetData();
		}
	}
	public static void ResetData(){
		Debug.Log("Reset Data!");
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("isNotFirstTime",1);
		
	}

	IEnumerator GlitchesOff(){
		GlobalStuff.instance.gUIManager.glitchEffect.enabled = false;
		yield return new WaitForSeconds(1f);
		worldGenerator.GenerateWorld(temperature,humidity,pressure,skyname,lat,lng);
		GlobalStuff.instance.gUIManager.glitchChromatical.enabled = false;
	}
}




















