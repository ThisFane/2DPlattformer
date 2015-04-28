using UnityEngine;
using System.Collections;

public class Drops : MonoBehaviour 
{
	public GameObject dropFab;
	private GameObject drop;

	private ushort minDrops=0;
	private ushort maxDrops=0;
	private short decayTime=-1;

	private bool canEnemyTake=false;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public bool isExp()
	{
		if(this.gameObject.name.Contains("exp") || this.gameObject.name.Contains("Exp"))
		 return true;
		else 
		 return false;
	}

	public bool isKey()
	{
		if(this.gameObject.name.Contains("key") || this.gameObject.name.Contains("Key"))
		 return true;
		else 
		 return false;
	}

	public void dropDrops(Transform tr)
	{
		for(int i=0; i<Random.Range(minDrops, maxDrops);i++)
		{
			drop = Instantiate(dropFab, new Vector3(tr.position.x, tr.position.y, tr.position.z), Quaternion.identity) as GameObject;
		}
	}
}
