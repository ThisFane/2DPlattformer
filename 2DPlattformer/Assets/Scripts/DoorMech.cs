using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorMech : MonoBehaviour
{
	public bool entrance = true;
	public GameObject player;
	public GameObject goal;
	public Text text;
	public bool entered = false;


	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.W) && entered)
		{
			Debug.Log(goal.transform.position);
			player.transform.position = new Vector3(this.goal.transform.position.x+0.3f, this.goal.transform.position.y, this.goal.transform.position.z);
		}
	}

	void OnGUI()
	{
		if(entered && !entrance)
			GUI.Label(new Rect(Screen.width/3, Screen.height*0.8f, Screen.width, Screen.height),"<size=40>Press 'UP' to leave.</size>");
	
		if(entered && entrance)
			GUI.Label(new Rect(Screen.width/3, Screen.height*0.8f, Screen.width, Screen.height),"<size=40>Press 'UP' to enter.</size>");
	}


	//public void UpdateText()
	//{
	//	if(entered)
	//		text.text = "ENTER WITH 'UP'!";
	//	else 
	//	{
	//		text.text = "";
	//	}
	//}


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
			entered = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
			entered = false;
	}

}
