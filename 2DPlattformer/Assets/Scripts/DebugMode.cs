using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugMode : MonoBehaviour 
{

	public static bool DebugModus = false;
	public static bool onPause = false;
	public static bool flyingMode = false;
	public static bool NoClippingMode = false;
	public static bool infHealth = false;
	public static bool infKey = false;
	public static bool instantKill = false;

	GameObject ui;

	[SerializeField] private Button infiHealth = null;
	[SerializeField] private Button instaKill = null;
	[SerializeField] private Button infiKeys = null;
	[SerializeField] private Button FlyButton = null;
	[SerializeField] private Button NoClip = null;

	// Use this for initialization
	void Start ()
	{
		ui = GameObject.Find("Debug UI");

		infiHealth.onClick.AddListener(() => {infHP();});
		instaKill.onClick.AddListener(() => {instaKilling();});
		infiKeys.onClick.AddListener(() => {infKeys();});
		NoClip.onClick.AddListener(() => {noClippCheat();});
		FlyButton.onClick.AddListener(() => {Flying();});

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P) && DebugModus)
		{
			//Debug.Log(Time.timeScale);
			onPause = !onPause;
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
			}
			else if(Time.timeScale == 0)
			{
				Time.timeScale = 1;
			}

		}
		if(Input.GetKeyDown(KeyCode.L) && !onPause)
		{
			ui.GetComponent<Canvas>().enabled = !ui.GetComponent<Canvas>().enabled;
			Debug.Log("Debug Mode"+ !DebugModus);
			DebugModus = !DebugModus;
		}
		if(Input.GetKeyDown(KeyCode.L) && onPause)
		{
			Debug.Log("<size=15>DEBUG MODE CAN ONLY BE EXITED WHEN NOT IN PAUSE</size>");
		}
	}

	void infHP()
	{
		infHealth = !infHealth;
		Debug.Log("Inf Health "+infHealth);
	}

	void instaKilling()
	{
		instantKill = !instantKill;
		Debug.Log("Instant Kill "+instantKill);
	}

	void infKeys()
	{
		infKey = !infKey;
		GameObject player = GameObject.Find("Sprite_Player");
		for(int i = 0; i < player.GetComponent<PlayerUtil>().keys.Length; i++)
		{
			player.GetComponent<PlayerUtil>().keys[i] = 999;
		}
		Debug.Log("Infinite Keys "+infKey);
	}

	void noClippCheat()
	{
		NoClippingMode = !NoClippingMode;
		GameObject player = GameObject.Find("Sprite_Player");
		for(int i = 0; i < player.GetComponents<Collider2D>().Length; i++)
		{
			player.GetComponents<Collider2D>()[i].isTrigger = !player.GetComponents<Collider2D>()[i].isTrigger;
		}
		Debug.Log("No Clipping "+NoClippingMode);
	}

	void Flying()
	{
		flyingMode = !flyingMode;		
		Debug.Log("FLYING "+flyingMode);
	}
}
