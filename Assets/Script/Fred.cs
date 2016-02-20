using UnityEngine;
using System.Collections;

public class Fred : MonoBehaviour {
	
	public int actualFloor = 0;
	public int bufferFloor = 0;

	public GameObject couteau;

	public Vector3 initialPosition;

	public World world;

	// Use this for initialization
	void Start () {
		this.initialPosition = this.transform.position;
		this.couteau.GetComponent<Couteau>().Activate(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			this.actualFloor--;
			if(actualFloor < this.world.floors[0]){
				this.actualFloor = this.world.floors[0];
			}
		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {
			this.actualFloor++;
			if(this.actualFloor > this.world.floors[this.world.floors.Count-1]){
				this.actualFloor = this.world.floors[this.world.floors.Count-1];
			}
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			GameObject newCouteau = Instantiate(this.couteau) as GameObject;
			newCouteau.GetComponent<Couteau>().Activate(true);
		}
	}
}
