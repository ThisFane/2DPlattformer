using UnityEngine;
using System.Collections;

public class PlayerUtil : MonoBehaviour 
{
	//public GameObject player;
	public int playerHealth = 10;
	public static int playerAttack = 1;
	public int playerAttackSpeed = 2; 
	bool wasHit = false;
	public GameObject arrow;

	float invinceTime = 2f;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject Projectile = Instantiate(arrow, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity) as GameObject; 
		}

		if(Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.U))
		{
			if(!PlayerMovement.lookingLeft)
			{
				this.gameObject.GetComponent<PlayerMovement>().Flip();
				Application.LoadLevel("test1");
			}
			else
			{
				Application.LoadLevel("test1");
			}
		}

		if(playerHealth <= 0)
		{
			die();
		}
	}

	void die()
	{
		Destroy(this.gameObject);
	}

	void isHit()
	{
		wasHit = !wasHit;
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "enemy" && !wasHit)
		{
			playerHealth -= coll.gameObject.GetComponent<Enemy>().enemy.getAttack();
			wasHit = !wasHit;
			Invoke("isHit", invinceTime);
		}
	}

	void OnCollisionStay2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "enemy" && !wasHit)
		{
			playerHealth -= coll.gameObject.GetComponent<Enemy>().enemy.getAttack();
			wasHit = !wasHit;
			Invoke("isHit", invinceTime);
		}
	}


}
