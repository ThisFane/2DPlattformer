using UnityEngine;
using System.Collections;

public class Key : Drops 
{
	GameObject key;

	public enum KeyType{BRONZE=0, SILVER=1, GOLD=2, SPECIALGOLD=3};
	public KeyType kt;

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
		if(this.kt.Equals(KeyType.BRONZE))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = keySprites[(int)kt];
		}
		if(this.kt.Equals(KeyType.SILVER))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = keySprites[(int)kt];
		}
		if(this.kt.Equals(KeyType.GOLD))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = keySprites[(int)kt];
		}
		if(this.kt.Equals(KeyType.SPECIALGOLD))
		{
			this.gameObject.GetComponent<SpriteRenderer>().sprite = keySprites[(int)kt];
		}
	}

}
