using UnityEngine;
using System.Collections;

public class PlayerUtil : MonoBehaviour 
{
	//public static GameObject player = this.gameObject;
	public static int playerHealth = 10;
	public static int playerAttack = 1;
	public static int playerAttackSpeed = 2; 
	public GameObject arrow;


	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject Projectile = Instantiate(arrow, new Vector3(this.transform.position.x, this.transform.position.y, 0f), Quaternion.identity) as GameObject; 
		}

		if(Input.GetKeyDown(KeyCode.O) && Input.GetKeyDown(KeyCode.U))
		{
			Application.LoadLevel("test1");
		}
	}
}
