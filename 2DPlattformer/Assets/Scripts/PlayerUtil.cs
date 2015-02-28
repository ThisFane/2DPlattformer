using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerUtil : MonoBehaviour 
{
	//public GameObject player;
	public static int playerHealth = 6;
	public int playerMaxHealth = 6;
	public static int playerAttack = 1;
	public int playerAttackSpeed = 2; 

	int savePlayerMaxHealth = 6;

	bool wasHit = false;
	bool healthDone = false;
	public static bool isGameOver = false;

	public AudioClip KeyPickup;
	public Animator animator;


	public Sprite[] heartSprite = new Sprite[3];

	public GameObject[] hearts = new GameObject[5];
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
		if(Input.GetButtonDown("Fire1") && !DebugMode.onPause && !DebugMode.DebugModus)
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


		if(DebugMode.instantKill)
		{
			playerAttack = 1337;
		}

		if(!DebugMode.instantKill)
		{
			playerAttack = 1;
		}

	
		if(DebugMode.infHealth)
		{
			Debug.Log("INFINTE HEALTH");
			savePlayerMaxHealth = playerMaxHealth;
			playerMaxHealth = 10;
			playerHealth = 1000;
			healthDone = false;
		}
		if(!DebugMode.infHealth && !healthDone)
		{
			healthDone = true;
			playerMaxHealth = savePlayerMaxHealth;
			playerHealth = 6;
		}

		updateHealth();
		//Debug.Log("HEALTH "+playerHealth);
		updateInv();

	}

	void updateInv()
	{
		for(int i = 0; i < keys.Length; i++)
		{
			if(keys[i] != 0)
			{
				GameObject.Find("Key_"+i).GetComponent<Image>().enabled = true;
			}
			if(keys[i] == 0)
			{
				GameObject.Find("Key_"+i).GetComponent<Image>().enabled = false;
			}
		}
	}


	//NEVER LOOK AT THIS CODE! xD
	void updateHealth()
	{
		hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
		hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
		hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
		hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
		hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[0];

		if(playerMaxHealth == 10)
		{
			hearts[0].gameObject.GetComponent<Image>().enabled = true;
			hearts[1].gameObject.GetComponent<Image>().enabled = true;
			hearts[2].gameObject.GetComponent<Image>().enabled = true;
			hearts[3].gameObject.GetComponent<Image>().enabled = true;
			hearts[4].gameObject.GetComponent<Image>().enabled = true;

			switch(playerHealth)
			{
			case 0: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				die ();
				break;
			case 1: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 2:	
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 3:	
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 4: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 5: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 6:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 7:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 8:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 9:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				break;
			case 10:hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				break;
			}
		}
		if(playerMaxHealth == 8)
		{	
			hearts[0].gameObject.GetComponent<Image>().enabled = true;
			hearts[1].gameObject.GetComponent<Image>().enabled = true;
			hearts[2].gameObject.GetComponent<Image>().enabled = true;
			hearts[3].gameObject.GetComponent<Image>().enabled = true;
			hearts[4].gameObject.GetComponent<Image>().enabled = false;

			switch(playerHealth)
			{
			case 0: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				die ();
				break;
			case 1: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 2:	
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 3:	
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 4: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 5: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 6:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 7:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 8:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 9:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				break;
			case 10:hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				break;
			}
		}
		if(playerMaxHealth == 6)
		{
			hearts[0].gameObject.GetComponent<Image>().enabled = true;
			hearts[1].gameObject.GetComponent<Image>().enabled = true;
			hearts[2].gameObject.GetComponent<Image>().enabled = true;
			hearts[3].gameObject.GetComponent<Image>().enabled = false;
			hearts[4].gameObject.GetComponent<Image>().enabled = false;
			switch(playerHealth)
			{
			case 0: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				die ();
				break;
			case 1: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 2:	
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 3:	
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 4: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 5: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 6:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 7:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 8:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 9:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				break;
			case 10:hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				break;
			}
		}
		if(playerMaxHealth == 4)
		{	
			hearts[0].gameObject.GetComponent<Image>().enabled = true;
			hearts[1].gameObject.GetComponent<Image>().enabled = true;
			hearts[2].gameObject.GetComponent<Image>().enabled = false;
			hearts[3].gameObject.GetComponent<Image>().enabled = false;
			hearts[4].gameObject.GetComponent<Image>().enabled = false;
			switch(playerHealth)
			{
			case 0: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				die ();
				break;
			case 1: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 2:	
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 3:	
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 4: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 5: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 6:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 7:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 8:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 9:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				break;
			case 10:hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				break;
			}
		}
		if(playerMaxHealth == 2)
		{	
			hearts[0].gameObject.GetComponent<Image>().enabled = true;
			hearts[1].gameObject.GetComponent<Image>().enabled = false;
			hearts[2].gameObject.GetComponent<Image>().enabled = false;
			hearts[3].gameObject.GetComponent<Image>().enabled = false;
			hearts[4].gameObject.GetComponent<Image>().enabled = false;

			switch(playerHealth)
			{
			case 0: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				die ();
				break;
			case 1: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 2:	
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 3:	
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 4: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 5: 
				hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 6:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 7:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 8:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[2];
				break;
			case 9:	hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[1];
				break;
			case 10:hearts[0].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[1].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[2].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[3].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				hearts[4].gameObject.GetComponent<Image>().sprite = heartSprite[0];
				break;
			}
		}
	}


	void die()
	{
		animator.SetBool ("isGameOver", true);
		isGameOver = true;
		PlayerMovement.speed = 0;
		///Application.OpenURL("https://www.youtube.com/watch?v=ANk8dEEVjLM");
		//Application.LoadLevel(Application.loadedLevel);
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
			GameObject.Find("Main Camera").audio.clip = KeyPickup;
			GameObject.Find("Main Camera").audio.Play();
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
