using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject sphere;
	private Vector3 offset;
	void Start () {
		offset = transform.position - sphere.transform.position;
	}
	

	void LateUpdate()
	{
		transform.position = sphere.transform.position + offset;
	}
}
