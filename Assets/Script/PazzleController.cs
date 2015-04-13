using UnityEngine;
using System.Collections;

public class PazzleController : MonoBehaviour {

	private GameObject black_1;
	private GameObject black_2;
	private GameObject black_3;
	private GameObject black_4;
	private GameObject black_5;
	private GameObject black_6;



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
}
