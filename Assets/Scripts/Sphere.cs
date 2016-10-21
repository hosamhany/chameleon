using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
public class Sphere : MonoBehaviour {
	private float acceleration;
	public Renderer rend;
	public Material m1;
	public Material m2;
	public Material m3;
	private bool color = true;
	private bool pause;
	public static int score;
	public static int hscore;
	public Text text;
	public Text htext;
	public Material m4;
	public GameObject pauseMenu;
	public GameObject floor;
	public GameObject floor1;
//	public AudioClip audio;
	private bool end;

	void Start () {
		pauseMenu.SetActive(false);
		rend = GetComponent<Renderer> ();
		Time.timeScale = 1;
	}


	void OnCollisionEnter(Collision collision)
	{
		if ((this.gameObject.transform.position.x < -2.5f)&&(this.gameObject.transform.position.x>-7.5f)) {
			if (!(collision.gameObject.transform.GetChild (0).transform.GetChild (2).gameObject.GetComponent<Renderer> ().material.color.Equals (m4.color))) {
				if (!this.gameObject.GetComponent<Renderer> ().material.color.Equals (collision.gameObject.transform.GetChild (0).transform.GetChild (2).gameObject.GetComponent<Renderer> ().material.color)) {
					score = score / 2;
				}
			}
		}
		if ((this.gameObject.transform.position.x > 2.5f)&&(this.gameObject.transform.position.x<7.5f)) {
			if (!(collision.gameObject.transform.GetChild (0).transform.GetChild (1).gameObject.GetComponent<Renderer> ().material.color.Equals (m4.color))) {
			if (!this.gameObject.GetComponent<Renderer> ().material.color.Equals (collision.gameObject.transform.GetChild (0).transform.GetChild (1).gameObject.GetComponent<Renderer> ().material.color)) {
					score = score / 2;
				}
			}
		}
		if ((this.gameObject.transform.position.x > -2.5f)&&(this.gameObject.transform.position.x<2.5f)) {
				if (!(collision.gameObject.transform.GetChild (0).transform.GetChild (0).gameObject.GetComponent<Renderer> ().material.color.Equals (m4.color))) {
			if (!this.gameObject.GetComponent<Renderer> ().material.color.Equals(collision.gameObject.transform.GetChild (0).transform.GetChild (0).gameObject.GetComponent<Renderer> ().material.color)) {
				score = score / 2;
			}
			}
		}
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("point")){
			end = true;
			score+=20;
//			hscore = score;
			Destroy (other.gameObject);
		}
		if(other.gameObject.CompareTag("purple"))
			{
				Destroy(other.gameObject);
				generatePurple ();

			}
	}
	void generatePurple()
	{

		GameObject newFloor;
//		DestroyFloor.x = false;
		for (int i = 0; i < 5; i++) {
			DestroyFloor.zPos += 10;
			newFloor = Instantiate (floor);
			newFloor.transform.position = new Vector3 (0f, 0f, DestroyFloor.zPos);
		}

//		DestroyFloor.x = true;
	}
	void Update () {
		if (score > hscore)
			hscore = score;
		text.text = "Score: " + score;
		htext.text = "Highest score, yet: " + hscore;
		if (acceleration < 10f) {
			acceleration += 0.02f;
		}

		Rigidbody rb = GetComponent<Rigidbody> ();

		if(Input.GetKeyDown(KeyCode.A)){
			rb.AddForce(Vector3.left*5, ForceMode.VelocityChange);
		}
		if(Input.GetKeyDown(KeyCode.D)){
			rb.AddForce(Vector3.right*5, ForceMode.VelocityChange);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			if(rb.transform.position.y < 1f)
				rb.AddForce (Vector3.up * 5, ForceMode.Impulse);

		}
		if (Input.GetKeyDown (KeyCode.Q)) {
			rend.material = m1;
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			rend.material = m2;
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			rend.material = m3;
		}
		if (color) {
			rend.material = m1;
			color = false;
		}
		transform.position += transform.forward * Time.deltaTime * acceleration;

		if(Input.GetKeyDown(KeyCode.Escape)&&(pause))
			{
				pause = false;

				Time.timeScale = 1;
			pauseMenu.SetActive (false);
			} 
		else if(Input.GetKeyDown(KeyCode.Escape)&&(!pause)) {
				pause = true;
			pauseMenu.SetActive (true);
				Time.timeScale = 0;


			}

		if (score == 0) {
			if(end == true)
				ChangeScene (4);
		}
		}
	public void ChangeScene(int scene){
		Application.LoadLevel (scene);
	}
		
	}
	
