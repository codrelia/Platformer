using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class mainchar : MonoBehaviour
{
	public float jumpForce;
	Rigidbody2D rigidBody;
	public int WidthB = 200;
	public int HeightB = 100;
	public static int score;
	public float moveSpeed = 10f;
	public GUISkin sk;
	private bool moving;
	private int velocity = 5;
	
	bool isFacingRight = true;
	Animator anim;
	
	bool isGrounded = false;
	
	public Transform groundCheck;
	public int extrajumpvalue;
	public float jumpVelocity=10f;
	float groundRadius = 0.3f;
	private int extrajump;
	public LayerMask whatIsGround;

	void Start()
	{

		extrajump = extrajumpvalue;
		anim = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate()
	{
		Run();
		
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool("Ground", isGrounded);
		anim.SetFloat("vSpeed", rigidBody.velocity.y);
		if (!isGrounded)
			return;


		}



	
	
	
	public void Run()
	{
		
		
		
		
		float move = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(move));
		
		
		rigidBody.velocity = new Vector2(move * moveSpeed, rigidBody.velocity.y);
		if (move > 0 && !isFacingRight)
			Flip();
		else if (move < 0 && isFacingRight)
			Flip();
	}
	
	void Flip()
	{
		
		isFacingRight = !isFacingRight;
		
		Vector3 theScale = transform.localScale;
		
		theScale.x *= -1;
		
		transform.localScale = theScale;
	}

	void Update()
	{ 
		if (isGrounded == true) {
			extrajump=extrajumpvalue;
		}

		if(transform.position.y<-15){
			Application.LoadLevel (Application.loadedLevel);
			score=0;
		}
		if (isGrounded && Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetBool("Ground", false);
			rigidBody.AddForce(new Vector2(0, jumpVelocity));
		}
	} 

	void OnGUI()
	{
		GUI.skin = sk;
		GUI.Box (new Rect (Screen.width - WidthB, 0, WidthB, HeightB), "Score:" + score);
	}
	void OnTriggerEnter2D (Collider2D col)
	{
				score = score + 1;
		}



}

	