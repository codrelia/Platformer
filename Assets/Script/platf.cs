using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class platf : MonoBehaviour {
	public float spacing = 2f;
	public float num = 10f;
	float direction = 1;
	float minX,maxX;

	void Start(){
		minX = transform.position.x;
		maxX = minX + num * spacing;
	}

	void Update(){
		Vector3 currPos = transform.position;
		if (currPos.x >= maxX) {
			direction = -1;		

		}
		if (currPos.x <= minX) {
			direction = 1;

		}
		transform.Translate (new Vector3 (direction * 5f * Time.deltaTime, 0, 0));
	}
	void OnCollisionEnter2D(Collision2D col){
		col.transform.parent = transform;
		
	}
	void OnCollisionExit2D(Collision2D col){
		col.transform.parent = null;
	}
}
