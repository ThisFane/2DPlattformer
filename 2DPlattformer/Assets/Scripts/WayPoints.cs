using UnityEngine;
using System.Collections;

public class WayPoints : MonoBehaviour 
{
	Transform birdEnemyTrans;
	public bool WayPoint1 = false;


	// Use this for initialization
	void Start () 
	{
		birdEnemyTrans = this.gameObject.GetComponentInParent<Transform>();
	}

	// Update is called once per frame
	void Update () 
	{
		
	}
}
