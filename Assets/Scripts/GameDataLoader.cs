using UnityEngine;
using System.Collections;
using SimpleJSON;


public class GameDataLoader : MonoBehaviour {
	public bool forceReset = false;
	public WorldGenerator worldGenerator;
	public string country;
	string weatherName;
	public string skyname;
	public float temperature;
	public float humidity;
	public float pressure;
	public float weather;
	public float wind;
	public AudioClip connecting;
	private bool island;

	void Start() {

		if(!PlayerPrefs.HasKey("lat") || !PlayerPrefs.HasKey("lng")){
			print("reset lat lng");
			PlayerPrefs.SetFloat("lat",RandomExt.RandomFloatBetween(-90,90));
			PlayerPrefs.SetFloat("lng",RandomExt.RandomFloatBetween(-180,180));
		}
		GlobalStuff.instance.lat = PlayerPrefs.GetFloat("lat");
		GlobalStuff.instance.lng = PlayerPrefs.GetFloat("lng");

		StartCoroutine(SearchWeatherData());
	}
	IEnumerator SearchWeatherData() {


		bool island = false;
		while (!island) {
			GlobalStuff.instance.lat = PlayerPrefs.GetFloat("lat");
			GlobalStuff.instance.lng = PlayerPrefs.GetFloat("lng");

			MonophonicTracks.instance.Play(connecting,1,RandomExt.RandomFloatBetween(.9f,1.1f));
			GlobalStuff.instance.gUIManager.label1.text = "[LAT: " + GlobalStuff.instance.lat + ",LNG: " + GlobalStuff.instance.lng + "]...CONNECTING";
			GlobalStuff.instance.gUIManager.label2.text = "Searching for weather data...";

			Debug.Log (GlobalStuff.instance.lat);
			string url = "http://api.openweathermap.org/data/2.5/weather?lat=" + GlobalStuff.instance.lat.ToString () + "&lon=" + GlobalStuff.instance.lng.ToString () + "&units=metric";
			Debug.Log (url);
			WWW request = new WWW (url);
			Debug.Log (request);
			yield return request;

			if (request.error == null || request.error == "") {
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


				var N = JSON.Parse (request.text);
				if (N ["cod"] == "404") {
						PlayerPrefs.SetFloat ("lat", RandomExt.RandomFloatBetween (-90, 90));
						PlayerPrefs.SetFloat ("lng", RandomExt.RandomFloatBetween (-180, 180));
						Application.LoadLevel ("home");
				}
				Debug.Log (N);
				if(N ["main"]["sea_level"]!=null) {
					float sealevel = float.Parse (N ["main"]["sea_level"].Value);
					float groundlevel = float.Parse (N ["main"] ["grnd_level"].Value);
					if (sealevel < groundlevel) {
						island = true;
					} else {
						Debug.Log("sea level "+sealevel.ToString()+" grnd level:"+groundlevel.ToString());
					}
				
				} else {
					island = true;
				}
				
				if(!island) {
					CheckForTeleport.SetNextChunkTeleport();
				}
				country = CountryConverter.CodeToName (N ["sys"] ["country"].Value);

				temperature = float.Parse (N ["main"] ["temp"].Value);
				humidity = float.Parse (N ["main"] ["humidity"].Value);
				pressure = float.Parse (N ["main"] ["pressure"].Value);
				wind = float.Parse (N ["wind"] ["speed"].Value);
				weatherName = N ["name"];
				Debug.Log (N ["weather"] [0] ["id"].Value);

				weather = float.Parse (N ["weather"] [0] ["id"].Value);
				skyname = N ["weather"] [0] ["main"].Value;

				GlobalStuff.instance.gUIManager.label1.text = "[LAT: " + GlobalStuff.instance.lat + ",LNG: " + GlobalStuff.instance.lng + "] " + weatherName.ToUpper () + ", " + country.ToUpper ();
				GlobalStuff.instance.gUIManager.label2.text = "TEMP:" + Mathf.Round (temperature).ToString () + "C HUMIDITY:" + humidity.ToString () + " PRESSURE: " + pressure.ToString () + " SKY:" + skyname.ToUpper () + " WIND:" + wind.ToString ();
			} else {
				Debug.Log ("WWW error: " + request.error);
			}
	}

		StartCoroutine (GlitchesOff ());

		
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
		PlayerPrefs.SetInt("card-1",0);
		PlayerPrefs.SetInt("card-2",0);
		PlayerPrefs.SetInt("card-3",0);
		PlayerPrefs.SetInt("card-4",0);
		PlayerPrefs.SetInt("card-5",0);
		PlayerPrefs.SetString("direction","NORTH");
		PlayerPrefs.SetFloat ("lat", RandomExt.RandomFloatBetween (-90, 90));
		PlayerPrefs.SetFloat ("lng", RandomExt.RandomFloatBetween (-180, 180));
	}

	IEnumerator GlitchesOff(){
		GlobalStuff.instance.gUIManager.glitchEffect.enabled = false;
		MonophonicTracks.instance.Stop(1);
		yield return new WaitForSeconds(1f);

		GlobalStuff.instance.enemyGenerator.GenerateEnemies();
		worldGenerator.GenerateWorld(temperature,humidity,pressure,skyname,GlobalStuff.instance.lat,GlobalStuff.instance.lng);
		GlobalStuff.instance.gUIManager.glitchChromatical.enabled = false;

	}
}




















