using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class structureAcademy : MonoBehaviour {

	public static int levelAcademy = 1;
	public Canvas RMHud;
	public Text textResearch;

	// Use this for initialization
	void Start () {

		GameController.controller.setResearchData (101);
		Debug.Log (GameController.controller.researchData);
	
		textResearch.text = GameController.controller.researchData.ToString();
	
	}


	// Update is called once per frame
	void Update () {
	
	}
}
