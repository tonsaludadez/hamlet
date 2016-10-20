using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class structureAcademy : MonoBehaviour {

	public static structureAcademy academy;

	public int levelAcademy = 1;
//	public Canvas RMHud;
//	public Text textResearch;

	//singleton stuff
	void Awake(){
		if(academy == null)
		{
			DontDestroyOnLoad(gameObject);
			academy = this;
		}

		else if (academy != this)
		{
			Destroy(gameObject);
		}
	}

	// Use this for initialization
	void Start () {

		GameController.controller.setResearchData (101);
		Debug.Log (GameController.controller.researchData);
	
	//	textResearch.text = GameController.controller.researchData.ToString();
	
	}


	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() 
	{
		print ("clicked");
	}

	public int getLevel(){
		return levelAcademy;
	}
}
