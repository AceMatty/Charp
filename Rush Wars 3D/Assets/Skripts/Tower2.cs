using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower2 : MonoBehaviour {


	public GameController gm;
	void Start () {

	}

	// Update is called once per frame
	void Update () {


	}
	void OnCollisionStay(Collision collision) {
		GameObject other = collision.collider.gameObject;
		if (other.gameObject.tag == "bullet") {
			gm.Health1 -= other.gameObject.GetComponent<Bullet>().Damage;
			Destroy (other.gameObject);
		}
	}
}

