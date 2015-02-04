using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUtil : MonoBehaviour 
{
	//public GameObject player;
	public int playerHealth = 10;
	public static int playerAttack = 1;
	public int playerAttackSpeed = 2; 
	bool wasHit = false;
	public GameObject[] hearts = new GameObject[5];
	public Sprite[] heartSprite = new Sprite[3];
	public GameObject arrow;

	public int[] keys = new int[4];

	float invinceTime = 2f;

	// Use this for initialization
	void Start () 
	{
		for(int i = 0; i < hearts.Length; i++)
		{
			hearts[i] = GameObject.Find("Heart"+(i+1));
		}
	}
	
	// Update is called once per frame
	void Update () 
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

		updateHealth();

	}

	void updateHealth()
	{
		switch(playerHealth)
		{
		case 0: hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				die ();
				break;
		case 1: hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				break;
		case 2:	hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
		case 3:	hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				break;
		case 4: hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
		case 5: hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				break;
		case 6:	hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
		case 7:	hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				break;
		case 8:	hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
		case 9:	hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				break;
		case 10:hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				break;
		}
	}


	void die()
	{
		Application.OpenURL("https://www.youtube.com/watch?v=ANk8dEEVjLM");
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

		if(coll.gameObject.tag == "key")
		{
			keys[coll.gameObject.GetComponent<Key>().whichKey] += 1;
			Destroy(coll.gameObject);
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
