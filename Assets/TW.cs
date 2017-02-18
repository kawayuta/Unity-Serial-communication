using UnityEngine;
using System.Collections;

public class TW : MonoBehaviour {
	
	public string SensorIdentity;
	// Use this for initialization
	void Start () {


		SensorIdentity = "10f0519";

	}
	
	// Update is called once per frame
	void Update () {
		SerialHandler sh = GetComponent<SerialHandler>();
		Debug.Log ("X" + sh.X + "Y" + sh.Y + "Z" + sh.Z);
	
	}
}
