using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	public GameController gm;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	void OnCollisionEnter(Collision collision) {
		GameObject other = collision.collider.gameObject;
		if (other.gameObject.tag == "bullet") {
			gm.Health2 -= other.gameObject.GetComponent<Bullet>().Damage;
			Destroy (other.gameObject);
		}
	}
}
