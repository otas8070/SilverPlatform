using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using LitJson;


public class WeatherCheck : MonoBehaviour {

	private GameObject WeatherImage;
	private GameObject WeatherText;

	// Use this for initialization
	void Start () {
		StartCoroutine(Get("http://api.openweathermap.org/data/2.5/weather?q=Tokyo,jp"));
		WeatherImage = GameObject.Find ("WeatherImage");
		WeatherText = GameObject.Find ("WeatherText");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Get (string url) {
		// HEADERはHashtableで記述
		Hashtable header = new Hashtable ();
		header.Add ("Accept-Language", "ja");
		
		// 送信開始
		WWW www = new WWW (url, null, header);
		yield return www;
		
		// 成功
		if (www.error == null) {
			Debug.Log("Get Success");

			// 本来はサーバからのレスポンスとしてjsonを戻し、www.textを使用する
			JSONObject json = new JSONObject (www.text);
			float temp = json.GetField ("main").GetField("temp").n;
			string temp2 = temp + "℃";

			//天気の画像URLを取得して出す
			string weather = "http://openweathermap.org/img/w/"+json.GetField ("weather") [0].GetField ("icon").str+".png";
			WWW Weatherwww = new WWW (weather);
			yield return Weatherwww;
			Texture2D texture = Weatherwww.texture;
			WeatherImage.GetComponent<Image> ().sprite = Sprite.Create (texture,new Rect(0,0,50,50), Vector2.zero);

			//天気の温度を出す
			WeatherText.GetComponent<Text> ().text = temp2;
			
		}
		// 失敗
		else{
			Debug.Log("Get Failure");           
		}
	}


}
	
