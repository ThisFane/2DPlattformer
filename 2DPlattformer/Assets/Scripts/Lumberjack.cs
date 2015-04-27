using UnityEngine;
using System.Collections;

public class Lumberjack : Enemy 
{
	// Use this for initialization
	void Start () 
	{
		initPlayer();
		initCam();
		initPos();
		this.setVar(5, 1, 2);
	}
		
	void chasePlayer()
	{
		Transform plT = player.transform;
		//Debug.Log(plT.position);
		this.transform.Translate(new Vector3((plT.position.x-this.transform.position.x)*0.5f*Time.deltaTime, 0f, 0f));
		//Debug.Log(this.rigidbody2D.velocity);
		//this.rigidbody2D.velocity = new Vector2((player.position.x-this.transform.position.x)*0.5f, rigidbody2D.velocity.y);
	}

	public Lumberjack(int hp, int atk, int spe):base(hp, atk, spe){}

	// Update is called once per frame
	void Update () 
	{
		turnAround();
		killEnemy();
		chasePlayer();
	}
}
