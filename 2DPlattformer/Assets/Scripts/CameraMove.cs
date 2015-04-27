using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	public float dampTime = 0f;
	private Vector3 velocity = Vector3.zero;
	public Transform target;

	//Wie weit die Kamera nach "oben" verschoben ist, relativ zum Player
	public float camOffset = 0.2f;
	
	// Update is called once per frame
	void Update () 
	{
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(new Vector3(target.position.x, (target.position.y+camOffset), target.position.z));
			Vector3 delta = (new Vector3(target.position.x, (target.position.y+camOffset), target.position.z)) - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		
	}
}