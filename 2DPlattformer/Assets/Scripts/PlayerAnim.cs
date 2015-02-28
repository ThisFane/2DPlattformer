using UnityEngine;
using System.Collections;

public class PlayerAnim : MonoBehaviour {

	public GameObject Player;
	public double SpeedBla;
	Animator animator;
	
	// Update is called once per frame
	void FiexdUpdate () {
		SpeedBla = Player.rigidbody2D.velocity.y;

		if (SpeedBla >= 1){
			animator.SetBool ("isRunning", true);
		}else{
			animator.SetBool("isRunning", false);
		}
	}
}