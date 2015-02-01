using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public GameObject arrow;
	public GameObject player;


	// Use this for initialization
	void Start () 
	{
		giveVelocity(PlayerMovement.lookingLeft);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void giveVelocity(bool direction)
	{
		if(!direction)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= 1;
			transform.localScale = theScale;
			rigidbody2D.velocity = new Vector2(3f, 0f);
		}
		if(direction)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			rigidbody2D.velocity = new Vector2(-3f, 0f);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "enemy" || other.gameObject.tag == "boundry")
		{
			GameObject temp = other.gameObject;
			temp.GetComponent<Enemy>();
			temp.GetComponent<EnemyHandler>();
			Destroy(arrow);
		}
	}


}
