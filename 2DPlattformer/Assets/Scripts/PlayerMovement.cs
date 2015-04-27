using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

	public GameObject player;

	public static float speed = 3f;
	public float jumpHeight = 3f;
	public float gravity = 1f;

	public static bool grounded = false;
	public static bool lookingLeft = true;


	// Use this for initialization
	void Start () 
	{

	}


	void FixedUpdate ()
	{
		if(Input.GetButtonDown("Jump") && isGrounded() && PlayerUtil.isGameOver == false)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
		}

		if(DebugMode.flyingMode)
		{

			player.GetComponent<Rigidbody2D>().mass = 0;
			player.GetComponent<Rigidbody2D>().gravityScale = 0;

			float move = Input.GetAxis("Horizontal");
			float moveVerct = Input.GetAxis("Vertical");
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, moveVerct * speed);
			
			if(move < 0 && !lookingLeft)
				Flip();
			else if(move > 0 && lookingLeft)
				Flip();
		}
		if(!DebugMode.flyingMode)
		{
			player.GetComponent<Rigidbody2D>().mass = 1;
			player.GetComponent<Rigidbody2D>().gravityScale = 1;

			float move = Input.GetAxis("Horizontal");
			GetComponent<Rigidbody2D>().velocity = new Vector2(move * speed, GetComponent<Rigidbody2D>().velocity.y);
		
		if(move < 0 && !lookingLeft)
			Flip();
		else if(move > 0 && lookingLeft)
			Flip();

		}
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
		if (PlayerUtil.isGameOver == false) {
				lookingLeft = !lookingLeft;
				Vector3 theScale = transform.localScale;
				theScale.x *= -1;
				transform.localScale = theScale;
		}
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
