using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public int actualFloor = 0;
	public int bufferFloor = 0;
	public World world;

	public int health = 3;

	public float reactionTime = 60;
	public float reactionCoundown;

	public Vector3 initialPosition;

	// Use this for initialization
	void Start () {
		this.reactionCoundown = this.reactionTime;
		this.bufferFloor = this.actualFloor;
		this.initialPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.actualFloor != this.world.fred.actualFloor) {
			this.reactionCoundown--;
		} else {
			this.reactionCoundown = this.reactionTime;
		}
		if (reactionCoundown == 0) {
			if( this.world.fred.actualFloor < this.actualFloor){
				this.actualFloor --;
			} else if( this.world.fred.actualFloor > this.actualFloor){
				this.actualFloor ++;
			} 
			this.reactionCoundown = this.reactionTime;
		}
	}
}
