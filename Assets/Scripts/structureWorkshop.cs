using UnityEngine;
using System.Collections;

public class structureWorkshop : MonoBehaviour {

	public static structureWorkshop workshop;

	public int levelWorkshop = 1;

	//singleton stuff
	void Awake(){
		if(workshop == null)
		{
			DontDestroyOnLoad(gameObject);
			workshop = this;
		}

		else if (workshop != this)
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown() 
	{
		print ("clicked");
	}

	public int getLevel(){
		return levelWorkshop;
	}
}
