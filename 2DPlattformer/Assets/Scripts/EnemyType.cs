using UnityEngine;
using System.Collections;

public class EnemyType : Object 
{
	private string name = "Lumberjack";
	private int health = 5;
	private int attack = 1;
	private int speed = 2;
		
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
