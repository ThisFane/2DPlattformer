using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public GameObject arrow;
	public GameObject player;


	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
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
			if(player.rigidbody2D.velocity.x != 0)
			{ 
				rigidbody2D.velocity = new Vector2((3f+(player.rigidbody2D.velocity.x*1.4f)), -0.1f);
				//Debug.Log("MIT PLAYER: "+(player.rigidbody2D.velocity.x*10f));
			}
			else
			 rigidbody2D.velocity = new Vector2(3f, -0.1f);
		}
		if(direction)
		{
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			if(player.rigidbody2D.velocity.x != 0)
			{	
				rigidbody2D.velocity = new Vector2((-3f+(player.rigidbody2D.velocity.x*1.4f)), -0.1f);
			}
			else
			 rigidbody2D.velocity = new Vector2(-3f, -0.1f);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "enemy" || other.gameObject.tag == "boundry")
		{
			GameObject temp = other.gameObject;
			temp.GetComponent<Enemy>().enemy.setHealth(temp.GetComponent<Enemy>().enemy.getHealth()-PlayerUtil.playerAttack);
			Destroy(arrow);
		}
	}


}
