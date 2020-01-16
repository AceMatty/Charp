using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public  GameObject Target;
	public  GameObject Out;
	public int Damage;

	void Start () {
		
	}
	

	void Update () {
		if (Target != null && (Target.tag!=Out.tag)) {
			
			transform.position = Vector3.MoveTowards (transform.position, Target.transform.position, Time.deltaTime * 15f);
		}
		else
			Destroy (this.gameObject);
	}
}
