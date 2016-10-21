using UnityEngine;
using System.Collections;

public class rotateCoin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0f, 0f, 45f) * Time.deltaTime);
	
	}
}
