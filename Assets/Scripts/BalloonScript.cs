using UnityEngine;
using System.Collections;

public class BalloonScript : MonoBehaviour {

	public string SensorIdentity;

	// Use this for initialization
	void Start () {

		SensorIdentity = "10f0519";
	}
	
	// Update is called once per frame
	void Update () {
	

		SerialHandler sh = GetComponent<SerialHandler>();
		Debug.Log (sh.X + sh.Y + sh.Z);

		if (sh.Y >= 60 && sh.Y <= 90 && sh.Z <= -100) {

			Debug.Log("パンチ(手:横)");
		}

		if (sh.Y >= 0 && sh.Y <= 50 && sh.Z <= -100) {

			Debug.Log("パンチ(手:正面)");
		}

	}
}
