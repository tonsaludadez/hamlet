using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class StructureFarm : MonoBehaviour {

	//public static structureFarm farm;
	//public Text textHunterList;


	public List<int> farmerList;
	public int levelFarm;

	public StructureFarm(){
		farmerList = new List<int>();
		levelFarm = 1;
	}

	void Start () {
		Debug.Log (GameController.controller.foodData);
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	//lovely edited this
/*	public Hunter HunterArray (){
		if(hunterArray.length() != 0){
			int i = 0;
			for(; i<hunterArray.length()-1;)
		}
		
		return hunterArray;
	}*/




	void OnMouseDown() 
	{
		print ("clicked");
		//addFoodFromFarm(3);
		//getFarmers();
	}


	//this function calculates the cumulative level of all hunters currently working in the farm.
	public int countHunterLevel(){

		int lvl = 0;
		foreach (int hunterID in GameController.controller.farm.farmerList) {
			lvl += GameController.controller.listData.find (hunterID).FarmLvl;
		}

		return lvl;
	}

	public int produced(){
		int f = countHunterLevel ();

		Debug.Log ("f " + f);
		return f;
	}
		
	public int getLevel(){
		return levelFarm;
	}

	public int getCount(){
		return farmerList.Count;
	}

	public bool addToList(int id){
		if (farmerList.Count < getLevel () * 3) {
			farmerList.Add (id);
			return true;
		} else
			return false;
	}
}
