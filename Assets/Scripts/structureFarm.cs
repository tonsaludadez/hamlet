using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class structureFarm : MonoBehaviour {

	public static structureFarm farm;
	public Text textHunterList;

	public Hunter[] farmerArray;

	public int levelFarm;
	//public Canvas RMHud;
	//public Slider sliderFood;

	// Use this for initialization

	void Start () {
	//	GameController.controller.setFoodData (50);
		Debug.Log (GameController.controller.foodData);
		levelFarm = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	//	sliderFood.value = GameController.controller.foodData;

	}

	//singleton stuff
	void Awake(){
		if(farm == null)
		{
			DontDestroyOnLoad(gameObject);
			farm = this;
		}

		else if (farm != this)
		{
			Destroy(gameObject);
		}
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
	private int countHunterLevel(){
		// return <retrievedNumberOfHuntersWorkingInTheFarm>;
		return 0;
	}

	public void setFoodFromFarm(float n){
		GameController.controller.setFoodData (n);
		Debug.Log (GameController.controller.foodData);
	}

	public void addFoodFromFarm(float n){
		GameController.controller.addFoodData (n);
		Debug.Log (GameController.controller.foodData);
	}

	public int getLevel(){
		return levelFarm;
	}
}
