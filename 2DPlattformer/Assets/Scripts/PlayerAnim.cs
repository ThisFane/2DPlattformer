using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

	public GameObject Player;
	public double runningSpeed;
	public Animator animator;
	public double jumpSpeed;

	void Start () 
	{

	}

	void FixedUpdate () {

		runningSpeed = Player.rigidbody2D.velocity.x;
		jumpSpeed = Player.rigidbody2D.velocity.y;

		if (runningSpeed > 0.001||runningSpeed < -0.001){
			animator.SetBool ("isRunning", true);
		}else
		{
			animator.SetBool("isRunning", false);
		}

		if (jumpSpeed > 0.001||jumpSpeed < -0.001){
			animator.SetBool ("isJumping", true);
		}else
		{
			animator.SetBool("isJumping", false);
		}

		if(PlayerUtil.playerHealth <= 0){
			animator.SetBool ("isDead", true);
		}
	}
}