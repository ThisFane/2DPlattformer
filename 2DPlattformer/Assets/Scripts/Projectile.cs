using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public GameObject arrow;
	public GameObject player;
	public GameObject UIDamage;
	public GameObject PlayerUI;

	public Vector3 enemyPos;
	public bool collidedWithEnemy = false;

	// Use this for initialization
	void Start () 
	{
		PlayerUI = GameObject.Find("Player UI");
		player = GameObject.FindGameObjectWithTag("Player");
		giveVelocity(PlayerMovement.lookingLeft);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}


	//GiveVelocity gibt dem Projektil einen "Push" in die Richtige Richtung!
	void giveVelocity(bool direction)
	{
		if(!direction)
		{
			//Dreht den Pfeil um
			Vector3 theScale = transform.localScale;
			theScale.x *= 1;
			transform.localScale = theScale;
			if(player.GetComponent<Rigidbody2D>().velocity.x != 0)
			{ 
				GetComponent<Rigidbody2D>().velocity = new Vector2((3f+(player.GetComponent<Rigidbody2D>().velocity.x*1.4f)), -0.1f);
				//Debug.Log("MIT PLAYER: "+(player.rigidbody2D.velocity.x*10f));
			}
			else
			 GetComponent<Rigidbody2D>().velocity = new Vector2(3f, -0.1f);
		}

		if(direction)
		{
			//Dreht den Pfeil um
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;


			if(player.GetComponent<Rigidbody2D>().velocity.x != 0)
			{	
				GetComponent<Rigidbody2D>().velocity = new Vector2((-3f+(player.GetComponent<Rigidbody2D>().velocity.x*1.4f)), -0.1f);
			}
			else
			 GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, -0.1f);
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Wenn der Pfeil einen Feind trifft, wird er zerstört und der Gegener erhält Schaden nach dem Attack Stat des Players
		if(other.gameObject.tag == "enemy")
		{
			GameObject temp = other.gameObject;
			collidedWithEnemy = !collidedWithEnemy;
			enemyPos = temp.gameObject.transform.position;
			GameObject UIDamageInstance = Instantiate(UIDamage, new Vector3(enemyPos.x, enemyPos.y, enemyPos.z), Quaternion.identity) as GameObject;
			UIDamageInstance.GetComponent<RectTransform>().localScale = new Vector3(0.002f, 0.002f, 0.002f);
			UIDamageInstance.transform.parent = PlayerUI.transform;
			UIDamageInstance.GetComponent<Text>().text = PlayerUtil.playerAttack+"";
			if(PlayerMovement.lookingLeft)
				UIDamageInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.7f, 1.6f);
			if(!PlayerMovement.lookingLeft)
				UIDamageInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0.7f, 1.6f);
			Destroy(UIDamageInstance, 1.0f);
			temp.GetComponent<Enemy>().setHealth((temp.GetComponent<Enemy>().getHealth() - PlayerUtil.playerAttack));
			collidedWithEnemy = !collidedWithEnemy;

			Destroy(arrow);
		}
		//Geht der Pfeil zu weit, dann wird er zerstört
		if(other.gameObject.tag == "boundry")
		{
			Destroy(arrow);
		}
	}


}
