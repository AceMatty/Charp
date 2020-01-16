using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] prefs = new GameObject[3];
	public GameObject MCamera;
	public GameObject BuildCamera;
	GameObject cl;
	public bool BuildMode = false;
	RaycastHit hit;
	public int Health1 = 100;
	public int Health2 = 100;
	public GameObject txt1;
	public GameObject txt2;
	public int XStep = 1;
	public int YStep = 1;
	public int ZStep = 1;
	public float speedActionCamera = 2f;
	public bool ActionCamera = false;
	public GameObject zones;
	public Transform StartPositionCamera;

	int clampedX;
	int clampedY;
	int clampedZ;

	void Start () {
		

		
	}

	void FixedUpdate(){


	}

	void Update () {
		txt1.GetComponent<TextMesh> ().text = "Health: " + Health1;
		txt2.GetComponent<TextMesh> ().text = "Health: " + Health2;
		if (ActionCamera == true) {
			MCamera.SetActive (false);
			BuildCamera.SetActive (true);
			BuildMode = true;
			zones.SetActive (true);
		} else {
			MCamera.SetActive (true);
			BuildCamera.SetActive (false);
		}

		if (BuildMode == true) {


			Ray ray = BuildCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				Vector3 pos = hit.point;
				if (hit.collider.gameObject.tag == "ground") {
					clampedX = Mathf.RoundToInt (pos.x) / XStep;
					clampedY = Mathf.RoundToInt (pos.y) / YStep;
					clampedZ = Mathf.RoundToInt (pos.z) / ZStep;
					cl.transform.position = new Vector3 (clampedX * XStep,2f, clampedZ * ZStep);


					if (Input.GetMouseButton (0)) {
						BuildMode = false;
						ActionCamera = false;
						zones.SetActive (false);
						cl.gameObject.GetComponent<BoxCollider> ().enabled = true;
						cl.gameObject.GetComponent<SphereCollider> ().enabled = true;
						cl.gameObject.GetComponent<Tank> ().TankHeader.GetComponent<BoxCollider> ().enabled = true;
					}

				} else {
					cl.transform.position = new Vector3 (clampedX,2f,clampedZ);
				}

			}



		}


		
	}
//	public void moveCam(){
//		if (ActionCamera == true && MCamera.transform.rotation.x < 90) {
//			MCamera.transform.position = Vector3.Slerp (MCamera.transform.position, BuildCamera.transform.position, Time.deltaTime* speedActionCamera);
//			MCamera.transform.rotation = Quaternion.Slerp (MCamera.transform.rotation, BuildCamera.transform.rotation, Time.deltaTime*speedActionCamera);
//			if (MCamera.transform.rotation.x > 90) {
//				BuildMode = true;	
//				ActionCamera = false;
//			}
//
//		} 
//		if(ActionCamera == true && MCamera.transform.rotation.x  > 90) {
//			MCamera.transform.position = Vector3.Lerp (MCamera.transform.position, StartPositionCamera.position, Time.deltaTime*speedActionCamera);
//			MCamera.transform.rotation = Quaternion.Lerp (MCamera.transform.rotation, StartPositionCamera.rotation, Time.deltaTime*speedActionCamera);
//			if (MCamera.transform == StartPositionCamera) {
//				ActionCamera = false;
//
//			}
//		}
//	}

	public void CreateObjects(int Index){
		if (ActionCamera == false) {
			cl = Instantiate (prefs [Index]);
//			Renderer ren = cl.GetComponent<Renderer> ();
//			ren.material.color = Color.green;
			//cl.GetComponent<Renderer> () = ren;
			ActionCamera = true;
			return;

		}




	}
}
