using UnityEngine;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using LitJson;


public class WeatherCheck : MonoBehaviour {

	private GameObject WeatherImage;

	// Use this for initialization
	void Start () {
		StartCoroutine(Get("http://api.openweathermap.org/data/2.5/weather?q=Tokyo,jp"));
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

			Debug.Log (www.text);

			WeatherImage = GameObject.Find("WeatherImage");

			// 本来はサーバからのレスポンスとしてjsonを戻し、www.textを使用するが
			// 今回は便宜上、下記のjsonを使用する
			string txt = "{\"name\": \"okude\", \"level\": 99, \"friend_names\": [\"ichiro\", \"jiro\", \"saburo\"]}";
			// 自作したTestResponseクラスにレスポンスを格納する
			TestResponse response = JsonMapper.ToObject<TestResponse> (txt);
			Debug.Log("name: " + response.name);
			Debug.Log("level: " + response.level);
			Debug.Log("friend_names[0]: " + response.friend_names[0]);
			Debug.Log("friend_names[1]: " + response.friend_names[1]);
			Debug.Log("friend_names[2]: " + response.friend_names[2]);
		}
		// 失敗
		else{
			Debug.Log("Get Failure");           
		}
	}


}

class TestResponse {
	public string name;
	public int level;
	public List<string> friend_names;
}
