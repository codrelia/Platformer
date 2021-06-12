using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class izumr : MonoBehaviour {
	Animator anim1;
    public static int score;

	void Start(){
		anim1 = GetComponent<Animator>();
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		score = score + 1;
		Destroy (gameObject);

		         }

}

