using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class structureFarm : MonoBehaviour {

	public static int levelFarm = 1;
	public Canvas RMHud;
	public Slider sliderFood;

	// Use this for initialization

	void Start () {
	//	GameController.controller.setFoodData (50);
		Debug.Log (GameController.controller.foodData);
	}
	
	// Update is called once per frame
	void Update () {
		
		sliderFood.value = GameController.controller.foodData;

	}

	void OnMouseDown() 
	{
		print ("clicked");
		addFoodFromFarm(3);

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
