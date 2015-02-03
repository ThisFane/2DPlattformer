using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DoorMech : MonoBehaviour
{
	[Tooltip("Player !AUS DER HIERACHY! muss hier eingefügt werden!")]
	public GameObject player;
	[Tooltip("Die Tür zu der es führen soll muss im Inspektor gesetzt werden.")]
	public GameObject goal;

	[Tooltip("Ist diese Tür ein Eingang?")]
	public bool entrance = true;
	[Tooltip("Ist diese Tür das \"Ende\" des Levels?")]
	public bool isLevelExit = false;
	[Tooltip("True, wenn das Player Objekt im Trigger ist!")]
	public bool entered = false;
	[Tooltip("GD: Muss gesetzt werden! True, wenn Locked Door!")]
	public bool hasLock = false;
	[Tooltip("GD: Muss gesetzt werden! True, wenn Tür einen Schlüssel benötigt!")]
	public bool locked = false;

	[Tooltip("Welcher Schlüssel wird für die Tür benötigt!")]
	public int whichLock = 0;
	[Tooltip("GD: Müssen gesetzt werden! (NICHT WENN PREFAB: \"Locked Door\" benutzt wird!")]
	public Sprite[] keys = new Sprite[8];

	string keyString = "<size=40>To Enter you need a bronze Key!</size>";

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.W) && entered && !hasLock)
		{
			player.transform.position = new Vector3(this.goal.transform.position.x+0.3f, this.goal.transform.position.y, this.goal.transform.position.z);
		}
		if(Input.GetKeyDown(KeyCode.W) && entered && hasLock && locked)
		{
			if(player.GetComponent<PlayerUtil>().keys[whichLock] >= 1)
				unlock();
		}
		if(Input.GetKeyDown(KeyCode.W) && entered && hasLock && !locked)
		{
			player.transform.position = new Vector3(this.goal.transform.position.x+0.3f, this.goal.transform.position.y, this.goal.transform.position.z);
		}
		if(hasLock)
		{
			setKeyString();
			setLockSprite();
		}
	}

	void setKeyString()
	{
		if(whichLock == 0)
			keyString = "<size=40>To Enter you need a bronze Key!</size>";
		if(whichLock == 1)
			keyString = "<size=40>To Enter you need a silver Key!</size>";
		if(whichLock == 2)
			keyString = "<size=40>To Enter you need a gold Key!</size>";
		if(whichLock == 3)
			keyString = "<size=40>To Enter you need a <i>special</i> gold Key!</size>";
	}

	void setLockSprite()
	{
		if(whichLock == 0 && locked)
			this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = keys[whichLock];
		if(whichLock == 1 && locked)
			this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = keys[whichLock];
		if(whichLock == 2 && locked)
			this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = keys[whichLock];
		if(whichLock == 3 && locked)
			this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = keys[whichLock];
		if(whichLock == 0 && !locked)
			this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = keys[whichLock+4];
		if(whichLock == 1 && !locked)
			this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = keys[whichLock+4];
		if(whichLock == 2 && !locked)
			this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = keys[whichLock+4];
		if(whichLock == 3 && !locked)
			this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = keys[whichLock+4];

	}

	void OnGUI()
	{
		if(entered && !entrance)
			GUI.Label(new Rect(Screen.width/3, Screen.height*0.8f, Screen.width, Screen.height),"<size=40>Press 'UP' to leave.</size>");
	
		if(entered && locked && !(player.GetComponent<PlayerUtil>().keys[whichLock] >= 1))
			GUI.Label(new Rect(Screen.width/4, Screen.height*0.8f, Screen.width, Screen.height), keyString);

		if(entered && locked && player.GetComponent<PlayerUtil>().keys[whichLock] >= 1)
			GUI.Label(new Rect(Screen.width/3, Screen.height*0.8f, Screen.width, Screen.height),"<size=40>Press 'UP' to unlock.</size>");

		if(entered && entrance && !isLevelExit && !locked)
			GUI.Label(new Rect(Screen.width/3, Screen.height*0.8f, Screen.width, Screen.height),"<size=40>Press 'UP' to enter.</size>");
	
	
	
	}

	void unlock()
	{
		if(locked && entered && player.GetComponent<PlayerUtil>().keys[whichLock] >= 1)
		{
			player.GetComponent<PlayerUtil>().keys[whichLock] -= 1;
			locked = !locked;
		}
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
