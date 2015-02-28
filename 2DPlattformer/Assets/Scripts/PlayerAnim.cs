using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

	public GameObject Player;
	public double SpeedBla;
	public Animator animator;

	void Start () 
	{
	}

	void FixedUpdate () {

		SpeedBla = Player.rigidbody2D.velocity.x;


		if (SpeedBla > 0.001||SpeedBla < -0.001){
			animator.SetBool ("isRunning", true);
		}else
		{
			animator.SetBool("isRunning", false);
		}
	}
}