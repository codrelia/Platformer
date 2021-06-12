using UnityEngine;
using System.Collections;

public class priz : MonoBehaviour {
	Animator anim;
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
		if (currPos.x > maxX) {
			direction *= -1;	
			Vector3 theScale = transform.localScale;
			theScale.x *= direction;
			transform.localScale = theScale;	

			
		}
		if (currPos.x < minX) {
			direction *= -1;
			Vector3 theScale = transform.localScale;
			theScale.x *= direction;
			transform.localScale = theScale;
			
		}
		transform.Translate (new Vector3 ( direction * 5f * Time.deltaTime, 0, 0));

}
}