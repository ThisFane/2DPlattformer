using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour
{
	private string name = "Lumberjack";
	private int health = 5;
	private int attack = 1;
	private int speed = 2;

	private GameObject cam;
	public GameObject player;
	
	private bool flipped = false;
	private short LastWayPoint = 1;
	private Vector3 OriPos;

	// Use this for initialization
	void Start () 
	{
	}

	public void initCam()
	{
		this.cam = GameObject.FindGameObjectWithTag("MainCamera");
	}

	public void initPos()
	{
		this.OriPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
	}

	public void initPlayer()
	{
		this.player = GameObject.FindGameObjectWithTag("Player");
	}

	public void setVar(int h, int atk, int spe)
	{
		this.health = h;
		this.attack = atk;
		this.speed = spe;
	}

	public Enemy(int hp, int atk, int spe)
	{
		this.health = hp;
		this.attack = atk;
		this.speed = spe;
	}

	// Update is called once per frame
	void Update () 
	{
	}

	public void turnAround()
	{
		if(isPlayerLeftOfMe() && !flipped) 
		{	
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			flipped = true;
		}
		if(!isPlayerLeftOfMe() && flipped) 
		{	
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
			flipped = false;
		}
	}

	public bool isPlayerLeftOfMe()
	{
		if(player.transform.position.x-this.transform.position.x < 0)
			return false;
		else
			return true;
	}

	public GameObject getPlayer()
	{
		return this.player;
	}

	public void killEnemy()
	{
		if(this.health <= 0)
		 Destroy(this.gameObject);
	}

	public void setName(string n)
	{
		this.name = n;
	}
	
	public string getName()
	{
		return this.name;
	}
	
	public void setHealth(int hp)
	{
		this.health = hp;
	}
	
	public int getHealth()
	{
		return this.health;
	}
	
	public void setAttack(int atk)
	{
		this.attack = atk;
	}

	public int getAttack()
	{
		return this.attack;
	}
}
