using UnityEngine;
using System.Collections;

public class DamageUI : MonoBehaviour
{
	GameObject[] projectile;
	Collider2D other;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		projectile = GameObject.FindGameObjectsWithTag("projectile");
		for(int i = 0; i < projectile.Length; i++)
		{
			Debug.Log(projectile[i].GetComponent<Projectile>().enemyPos);
			//if(Projectile.collidedWithEnemy)
			//	Debug.Log(Projectile.enemyPos);
		}
	}

}
