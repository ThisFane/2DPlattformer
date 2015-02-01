using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{

	public static int health = 10;
	public int enemyType = 1;
	public EnemyType enemy = new EnemyType();

	// Use this for initialization
	void Start () 
	{
		enemyTypeCheck();
	}

	// Update is called once per frame
	void Update () 
	{
		if(enemy.getHealth() <= 0)
		{
			Destroy(this.gameObject);
		}
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
