﻿using UnityEngine;
using System.Collections;

public class HamletHall : MonoBehaviour {

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
		
	public void viewData(){
		
		GameController.controller.getFoodData ();
		GameController.controller.getGoldData ();
		GameController.controller.getResearchData();
		GameController.controller.getSuppliesData();

		//farm
		structureFarm.farm.getLevel();

		//academy
		structureAcademy.academy.getLevel();
	}
}
