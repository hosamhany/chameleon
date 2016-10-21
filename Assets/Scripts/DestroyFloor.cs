using UnityEngine;
using System.Collections.Generic;

public class DestroyFloor : MonoBehaviour {
	public GameObject floor1;
	public GameObject floor2;
	public GameObject floor3;
	public GameObject floor4;
	public GameObject floor5;

	public GameObject coin;
//	public GameObject purple;
	private int random;
	private float randC;
	private Vector3 vC;
	private bool enter;
//	public static bool x = true;
	public static float zPos = -5f;

	void OnTriggerExit(Collider other)
	{
		
		if(other.gameObject.CompareTag("destroy"))
			{
			Destroy (other.gameObject);
			}
		if (other.gameObject.CompareTag ("x")) {
			Destroy (other.gameObject);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("destroy")){
//			if (x) {
				generateFloors ();
//			}
			generateCoins ();
		}
		if (other.gameObject.CompareTag ("point")) {
			Destroy (other.gameObject);
		}
		if(other.gameObject.CompareTag("purple")){
			Destroy (other.gameObject);
			}
	}
	void Update()
	{

	}
//	void generatePurple()
//	{
//		//		randC = Random.Range (-5f, 5f);
//		//		vC = new Vector3 (0f, 1f, zPos);
//		GameObject newFloor;
//		for (int i = 0; i < 11; i++) {
//			zPos += 10;
//			newFloor = Instantiate (floor);
//			newFloor.transform.position = new Vector3 (0f, 0f, zPos);
//		}
//	}
	void generateCoins()
	{
		randC = Random.Range (-5f, 5f);
		vC = new Vector3 (randC, 0.5f, zPos);
		Instantiate (coin, vC, Quaternion.identity);
	}
	public void generateFloors()
	{
		zPos += 10;
		random = (int) Random.Range (1f, 5f);

		GameObject newFloor;
		switch (random) {
		case 1:
			newFloor = Instantiate (floor1);
			break;
		case 2: 
			newFloor = Instantiate (floor2);

			break;
		case 3:
			newFloor = Instantiate (floor3);

			break;
		case 4:
			newFloor = Instantiate (floor4);

			break;
		case 5:
			newFloor = Instantiate (floor5);

			break;

		default:
			newFloor = Instantiate (floor2);

			break;

		}

		newFloor.transform.position = new Vector3 (0f, 0f, zPos);

	}
}
