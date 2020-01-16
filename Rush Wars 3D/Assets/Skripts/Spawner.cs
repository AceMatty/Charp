using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public float Interval;
	float curtimer;
	public GameObject EnemyTank;
	public Transform[] SpawnPoints = new Transform[3];
	GameObject cl;
	void Start () {
		
	}
	

	void Update () {
		if (curtimer <= 0) {
			int i = Random.Range (0, 3);
			cl = Instantiate (EnemyTank, SpawnPoints [i].position, EnemyTank.transform.rotation);
			curtimer = Interval;

		} 
		else {
			curtimer -= Time.deltaTime;

		}
		
	}
}
