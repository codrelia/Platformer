using UnityEngine;
using System.Collections;

public class platfY : MonoBehaviour {
	public float spacing = 2f;
	public float num = 10f;
	float direction = 1;
	float minX,maxX;
	
	void Start(){
		minX = transform.position.y;
		maxX = minX + num * spacing;
	}
	
	void Update(){
		Vector3 currPos = transform.position;
		if (currPos.y >= maxX) {
			direction = -1;		
			
		}
		if (currPos.y <= minX) {
			direction = 1;
			
		}
		transform.Translate (new Vector3 (0, direction * 2f * Time.deltaTime, 0));
	}
	void OnCollisionEnter2D(Collision2D col){
		col.transform.parent = transform;
		
	}
	void OnCollisionExit2D(Collision2D col){
		col.transform.parent = null;
	}
}