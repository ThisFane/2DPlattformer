using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{

	public static int health = 10;
	public int enemyType = 1;
	EnemyType enemy = new EnemyType();

	// Use this for initialization
	void Start () 
	{
		
	}

	// Update is called once per frame
	void Update () 
	{

	}

	void enemyTypeCheck()
	{
		if(enemyType == 1)
		{
			enemy.setName("Lumberjack");
			enemy.setHealth(5);
			enemy.setAttack(1);
		}
	}


}
