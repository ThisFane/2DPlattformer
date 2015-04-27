using UnityEngine;
using System.Collections;

public class LockedDoor : Door 
{
	[Tooltip("GD: Muss gesetzt werden! True, wenn Locked Door!")]
	public bool hasLock = true; //obsolete
	[Tooltip("GD: Muss gesetzt werden! True, wenn Tür einen Schlüssel benötigt!")]
	public bool locked = true;
	
	[Tooltip("Welcher Schlüssel wird für die Tür benötigt!")]
	public int whichLock = 0;
	[Tooltip("GD: Müssen gesetzt werden! (NICHT WENN PREFAB: \"Locked Door\" benutzt wird!")]
	public Sprite[] keys = new Sprite[8];
	
	string keyString = "<size=40>To Enter you need a bronze Key!</size>";

	void Start()
	{
		initAll();
		setKeyString();
	}

	// Update is called once per frame
	void Update () 
	{
		letIn();
		setLockSprite();
	}

	public void letIn()
	{
		if(Input.GetKeyDown(KeyCode.W) && entered && hasLock && locked)
		{
			if(player.GetComponent<PlayerUtil>().keys[whichLock] >= 1)
			 unlock();
		}
		if(Input.GetKeyDown(KeyCode.W) && entered && hasLock && !locked)
		{
			player.transform.position = new Vector3(this.goal.transform.position.x+0.3f, this.goal.transform.position.y, this.goal.transform.position.z);
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

	void unlock()
	{
		if(locked && entered && player.GetComponent<PlayerUtil>().keys[whichLock] >= 1)
		{
			GameObject.Find("Main Camera").GetComponent<AudioSource>().clip = openDoor;
			GameObject.Find("Main Camera").GetComponent<AudioSource>().Play();
			player.GetComponent<PlayerUtil>().keys[whichLock] -= 1;
			locked = !locked;
		}
	}

	void OnGUI()
	{
		if(entered && locked && !(player.GetComponent<PlayerUtil>().keys[whichLock] >= 1))
			GUI.Label(new Rect(Screen.width/4, Screen.height*0.8f, Screen.width, Screen.height), keyString);
	
		if(entered && locked && player.GetComponent<PlayerUtil>().keys[whichLock] >= 1)
			GUI.Label(new Rect(Screen.width/3, Screen.height*0.8f, Screen.width, Screen.height),"<size=40>Press 'UP' to unlock.</size>");

		if(entered && entrance && !isLevelExit && !locked)
			GUI.Label(new Rect(Screen.width/3, Screen.height*0.8f, Screen.width, Screen.height),"<size=40>Press 'UP' to enter.</size>");
	}
}
