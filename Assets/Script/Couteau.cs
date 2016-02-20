using UnityEngine;
using System.Collections;

public class Couteau : MonoBehaviour {
	
	public Fred fred;

	public bool threw = false;
	public bool bufferThrew = false;
	public float speed = 0.1f;

	public float lifeDuration = 60;
	public float lifeCountdown = 60;

	// Use this for initialization
	void Start () {
		//Activate (false);
	}

	public void Activate (bool active, bool delete = false){
		this.threw = active;
		this.GetComponent<SpriteRenderer> ().enabled = this.threw;
		if (!delete) {
			if (!this.threw) {
				this.transform.position = new Vector3 (
					this.fred.transform.position.x,
					this.transform.position.y,
					this.transform.position.z
				);
				this.lifeCountdown = this.lifeDuration;
			}
		} else {
			Destroy(this.gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (this.threw) {
			this.lifeCountdown--;
			this.transform.position = new Vector3(
				this.transform.position.x + this.speed,
				this.transform.position.y,
				this.transform.position.z
			);
			if (this.bufferThrew != this.threw) {
				this.bufferThrew = this.threw;
			}
		}
		if (this.lifeCountdown <= 0) {
			this.Activate(false, true);
		}
	}
}
