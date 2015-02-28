using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

	public GameObject Player;
	public double SpeedBla;
	public Animator animator;
	public double JumpSpeed;

	void Start () 
	{

	}

	void FixedUpdate () {

		SpeedBla = Player.rigidbody2D.velocity.x;
		JumpSpeed = Player.rigidbody2D.velocity.y;

		if (SpeedBla > 0.001||SpeedBla < -0.001){
			animator.SetBool ("isRunning", true);
		}else
		{
			animator.SetBool("isRunning", false);
		}

		if (JumpSpeed > 0.001||JumpSpeed < -0.001){
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