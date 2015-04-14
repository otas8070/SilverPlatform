using UnityEngine;
using System.Collections;

public class PazzleController : MonoBehaviour {

	private GameObject black_1;
	private GameObject black_2;
	private GameObject black_3;
	private GameObject black_4;
	private GameObject black_5;
	private GameObject black_6;
	private float time = 0.0f;


	// Use this for initialization
	void Start () {

		black_1 = GameObject.Find ("black1");
		black_2 = GameObject.Find ("black2");
		black_3 = GameObject.Find ("black3");
		black_4 = GameObject.Find ("black4");
		black_5 = GameObject.Find ("black5");
		black_6 = GameObject.Find ("black6");
	
	}
	
	// Update is called once per frame
	void Update () {

		time = time + Time.deltaTime;
		if(time >= 5.0f){
			time = 0;
			Debug.Log("5秒後");
			StartCoroutine (SensorCheck("http://life-cloud.ht.sfc.keio.ac.jp/mimamori/event/"));
		}


		if (Input.GetKey(KeyCode.W)) {   // Wキーで前進.
			black_1.SetActive (false);
			black_5.SetActive (false);
		}
		if (Input.GetKey(KeyCode.A)) {   // Sキーで後退.
			black_2.SetActive (false);
			black_6.SetActive (false);
		}
		if (Input.GetKey(KeyCode.D)) {  // Aキーで左移動.
			black_3.SetActive (false);
			black_4.SetActive (false);
		}
	}

	IEnumerator SensorCheck(string url){

		Hashtable header = new Hashtable ();
		header.Add ("Accept-Language", "ja");
		WWW www = new WWW (url, null, header);
		yield return www;

		if (www.error == null) {
			Debug.Log("Get Success");

			// 本来はサーバからのレスポンスとしてjsonを戻し、www.textを使用する
			JSONObject json = new JSONObject (www.text);

			Debug.Log ("json ====== "+json.Count);
			for (int i = 0; i < json.Count; i++) {
				Debug.Log (json[i].GetField("event_id").str);
				string event_id = json [i].GetField ("event_id").str;
				if (event_id == "1") {   // Wキーで前進.
					black_1.SetActive (false);
					black_5.SetActive (false);
				}
			}

			//float temp = json.GetField ("main").GetField("temp").n;
			//string temp2 = temp + "℃";


		}
		// 失敗
		else{
			Debug.Log("Get Failure");           
		}
	
	}
}
