using UnityEngine;
using System.Collections;

public class toggleMenu : MonoBehaviour {

	public void ChangeScene(int scene){
		if (scene == 19) {
			Application.Quit();
			Debug.Log ("Quit");
		} else {
			Application.LoadLevel (scene);
		}
	}
}
