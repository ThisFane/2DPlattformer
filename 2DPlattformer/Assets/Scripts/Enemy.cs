using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	GameObject cam;
	GameObject player;
	bool flipped = false;
	short LastWayPoint = 1;
	Vector3 OriPos;
	public int health = 10;
	public int enemyType = 1;
	public EnemyType enemy = new EnemyType();

	// Use this for initialization
	void Start () 
	{
		OriPos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		player = GameObject.FindGameObjectWithTag("Player");
		enemyTypeCheck();
	}

	// Update is called once per frame
	void Update () 
	{
		if(this.health <= 0)
		{
			Destroy(this.gameObject);
		}
		if(enemyType == 1 && player.renderer.isVisible && this.renderer.isVisible)
			chasePlayer(); 
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

	bool isPlayerLeftOfMe()
	{
		if(player.transform.position.x-this.transform.position.x < 0)
			return false;
		else
			return true;
	}

	void chasePlayer()
	{
		Transform plT = player.transform;
		//transform.LookAt(player.position);
		this.transform.Translate(new Vector3((plT.position.x-this.transform.position.x)*0.5f*Time.deltaTime, 0f, 0f));
		//Debug.Log(this.rigidbody2D.velocity);
		//this.rigidbody2D.velocity = new Vector2((player.position.x-this.transform.position.x)*0.5f, rigidbody2D.velocity.y);
	}

	void SearchWayPoint()
	{

	}

	void FixedUpdate()
	{
		//this.transform.position += transform.up * 0.3f * Time.deltaTime;                 
	}

	void enemyTypeCheck()
	{
		if(enemyType == 1)
		{
			enemy.setName("Lumberjack");
			this.health = 5;
			enemy.setAttack(3);
		}

		if(enemyType == 2)
		{
			enemy.setName("Blue Bird With Yellow Shoes");
			this.health = 8;
			enemy.setAttack(2);
		}

	}


}
