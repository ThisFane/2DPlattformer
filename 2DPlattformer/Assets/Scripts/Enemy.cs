using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	GameObject cam;
	GameObject player;
	public static int health = 10;
	public int enemyType = 1;
	public EnemyType enemy = new EnemyType();

	// Use this for initialization
	void Start () 
	{
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		player = GameObject.FindGameObjectWithTag("Player");
		enemyTypeCheck();
	}

	// Update is called once per frame
	void Update () 
	{
		if(enemy.getHealth() <= 0)
		{
			Destroy(this.gameObject);
		}
		if(enemyType == 1 && player.renderer.isVisible && this.renderer.isVisible)
			chasePlayer();
	}

	void chasePlayer()
	{
		Transform plT = player.transform;
		//transform.LookAt(player.position);
		this.transform.Translate(new Vector3((plT.position.x-this.transform.position.x)*0.5f*Time.deltaTime, 0f, 0f));
		//Debug.Log(this.rigidbody2D.velocity);
		//this.rigidbody2D.velocity = new Vector2((player.position.x-this.transform.position.x)*0.5f, rigidbody2D.velocity.y);
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
			enemy.setHealth(5);
			enemy.setAttack(1);
		}

		if(enemyType == 2)
		{
			enemy.setName("Stuff");
			enemy.setHealth(8);
			enemy.setAttack(1);
		}

	}


}
