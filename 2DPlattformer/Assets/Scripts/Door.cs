using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	[Tooltip("Player wir in der Start funktion jeder Tür festgelegt!")]
	public GameObject player;
	[Tooltip("Die Tür zu der es führen soll muss im Inspektor gesetzt werden.")]
	public GameObject goal;
	
	public AudioClip openDoor;
	
	[Tooltip("Ist diese Tür ein Eingang?")]
	public bool entrance = true;
	[Tooltip("Ist diese Tür das \"Ende\" des Levels?")]
	public bool isLevelExit = false;
	[Tooltip("True, wenn das Player Objekt im Trigger ist!")]
	public bool entered = false;

	void Start()
	{
		//Guckt ob die Tür "Door 2" heißt
		//Falls Ja, dann ist dies der "Ausgang"
		//Damit GUI ausgibt "...to leave"
		if(this.gameObject.name.Equals("Door_2"))
		{
			entrance = false;
		}
		initAll();
	}

	//Findet Player und setzt das Ziel der Tür
	public void initAll()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		if(this.gameObject.name.Equals("Door_1"))
		{
			goal = this.gameObject.transform.parent.FindChild("Door_2").gameObject;
		}
		else if(this.gameObject.name.Equals("Door_2"))
		{
			goal = this.gameObject.transform.parent.FindChild("Door_1").gameObject;
		}
	}

	void Update () 
	{
		letIn();
	}

	//Sofern Player sich in der Collider Box der Tür befindet und 'W' drückt geht er rein
	public void letIn()
	{
		if(Input.GetKeyDown(KeyCode.W) && entered)
		{
			player.transform.position = new Vector3(this.goal.transform.position.x+0.3f, this.goal.transform.position.y, this.goal.transform.position.z);
		}
	}

	//Einfach das GUI Label "Press 'UP' to enter"
	void OnGUI()
	{
		if(entered && entrance)
			GUI.Label(new Rect(Screen.width/3, Screen.height*0.8f, Screen.width, Screen.height),"<size=40>Press 'UP' to enter.</size>");

		if(entered && !entrance)
			GUI.Label(new Rect(Screen.width/3, Screen.height*0.8f, Screen.width, Screen.height),"<size=40>Press 'UP' to leave.</size>");
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
			entered = true;
		//Debug.Log(this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite);
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
			entered = false;
	}
}
