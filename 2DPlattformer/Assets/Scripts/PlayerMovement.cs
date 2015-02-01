using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

	public GameObject player;
	public float speed = 3f;
	public float jumpHeight = 3f;
	public float gravity = 1f;
	public static bool grounded = false;
	public static bool lookingLeft = true;

	// Use this for initialization
	void Start () 
	{

	}


	void Update ()
	{
		if(Input.GetButtonDown("Jump") && isGrounded())
		{
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpHeight);
		}

		float move = Input.GetAxis("Horizontal");
		rigidbody2D.velocity = new Vector2(move * speed, rigidbody2D.velocity.y);
	
		if(move < 0 && !lookingLeft)
			Flip();
		else if(move > 0 && lookingLeft)
			Flip();
		//Debug.Log(isGrounded());
		//Debug.Log(Input.GetAxis("Horizontal"));

	}

	public bool isGrounded()
	{
		return grounded;
	}

	//returns 1 if looking right and 0 if looking left!

	public void Flip()
	{
		lookingLeft = !lookingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "ground")
		{
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "ground")
		{
			grounded = false;
		}
	}
}
