using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour {


	public GameObject TankHeader;
	public GameObject TankGun;
	public GameObject Bullet;
	public bool isAngry = false;
	public bool isShooting = false;
	public bool lockOn = false;
	public float speed = 20f;
	public float speedShoot = 3f;
	public float curTime;
	public float ShootDist = 0.1f;
	RaycastHit hit;
	public GameObject enemy;
	public Vector3 v;
	GameObject blcl;
	public int health = 100; 

	Quaternion startRotHeader;
	Quaternion startRotTank;

	void Start () {
		ShootDist = 4f;
		startRotHeader = TankHeader.transform.rotation;
		startRotTank = transform.rotation;
	}


	void Update () {
		if (enemy == null) {
			isAngry = false;
			isShooting =  false;

			transform.rotation = Quaternion.Lerp (transform.rotation, startRotTank, 2f * Time.deltaTime);
			TankHeader.transform.rotation = Quaternion.Lerp (transform.rotation, startRotHeader, speed * Time.deltaTime);
		}

		if (isAngry == false && isShooting == false ) {
			Vector3 v = transform.position;
			v.x -= speed * Time.deltaTime;
			transform.position = v;

		}
		if (isAngry == true && enemy!=null) {
			Ray ray = new Ray (transform.position, enemy.transform.position);
			//if (Physics.Raycast (ray, out hit)) {
			Debug.DrawLine (transform.position, enemy.transform.position, Color.red);
			//Debug.Log (hit.distance);
			if (Vector3.Distance(transform.position, enemy.transform.position) >= ShootDist*2) {
				Debug.Log (Vector3.Distance (transform.position, enemy.transform.position));
				transform.position = Vector3.MoveTowards (transform.position, enemy.transform.position, Time.deltaTime * speed);
				transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.LookRotation (enemy.transform.position - transform.position), Time.deltaTime*speed);

			}else {
				isAngry = false;
				isShooting = true;
				lockOn = false;

			}
			//}
		}

		if (isShooting == true) {
			//TankHeader.transform.LookAt (enemy.transform);
			if (curTime <= 0) {
				blcl = Instantiate (Bullet, TankGun.transform.position, TankGun.transform.rotation);	
				blcl.gameObject.GetComponent<Bullet> ().Target = enemy;
				blcl.gameObject.GetComponent<Bullet> ().Out = this.gameObject;
				blcl.gameObject.GetComponent<Bullet> ().Damage = 30;
				curTime = speedShoot;

			}else {
				curTime -= Time.deltaTime;
			}



		}
		if (health <= 0)
			Destroy (gameObject);

	}

	void OnTriggerEnter(Collider other){
		
		if (other.gameObject.tag == "enemy" && lockOn == false) {
			isAngry = true;
			enemy = other.gameObject;
			lockOn = true;

		}
		if (other.gameObject.tag == "EnemyTower2" && lockOn == false) {
			isAngry = true;
			lockOn = true;
			enemy = other.gameObject;

		}

	}
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "enemy" && lockOn == false) {
			isAngry = true;
			enemy = other.gameObject;
			lockOn = true;

		}
	}


	void OnCollisionEnter(Collision collision) {
		GameObject other = collision.collider.gameObject;
		if (other.gameObject.tag == "bullet") {
			health -= other.gameObject.GetComponent<Bullet>().Damage;
			Destroy (other.gameObject);
		}
	}
}
