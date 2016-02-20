using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour {

	public List<int> floors = new List<int>();
	public Fred fred;
	public GameObject[] enemies;

	public float ratioMouvement = 0.001f;

	// Use this for initialization
	void Start () {
		this.floors.Add (0); // this.floors[0] = 0;
		this.floors.Add (1); // this.floors[1] = 1;
		this.floors.Add (2); // this.floors[2] = 2;

		this.fred.actualFloor = this.floors [0];
		this.fred.bufferFloor = this.fred.actualFloor;

		this.enemies = GameObject.FindGameObjectsWithTag("Enemy") as GameObject[];
	}
	
	// Update is called once per frame
	void Update () {
		if (this.fred.bufferFloor != this.fred.actualFloor) {
			this.fred.gameObject.transform.position = new Vector3(
				this.fred.gameObject.transform.position.x,
				this.fred.initialPosition.y + (this.floors[this.fred.actualFloor] * this.ratioMouvement),
				0
			);
			this.fred.bufferFloor = this.fred.actualFloor;
		}
		foreach (GameObject enemyGO in this.enemies) {
			Enemy enemy = enemyGO.GetComponent<Enemy>();
			if (enemy.bufferFloor != enemy.actualFloor) {
				enemy.gameObject.transform.position = new Vector3(
					enemy.gameObject.transform.position.x,
					enemy.initialPosition.y + (this.floors[enemy.actualFloor] * this.ratioMouvement),
					0
					);
				enemy.bufferFloor = enemy.actualFloor;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Enemy") {
			Debug.Log (coll.gameObject.name);
		}
	}
}
