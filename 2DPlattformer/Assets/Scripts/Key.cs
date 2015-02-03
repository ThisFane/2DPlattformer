using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour 
{

	GameObject key;
	public int whichKey = 0;
	public Sprite[] keySprites = new Sprite[4];

	// Use this for initialization
	void Start () 
	{
		WhatKey();
		key = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void WhatKey()
	{
		if(whichKey == 0)
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = keySprites[whichKey];
		}
		if(whichKey == 1)
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = keySprites[whichKey];
		}
		if(whichKey == 2)
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = keySprites[whichKey];
		}
		if(whichKey == 3)
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = keySprites[whichKey];
		}
	}

}
