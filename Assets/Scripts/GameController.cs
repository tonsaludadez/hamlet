using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;	
using System.IO;

public class GameController : MonoBehaviour {

	//public Slider sliderFood;
	public static GameController controller;

	public float foodData = 0;
	public int goldData = 0;
	public int researchData = 0;
	public int suppliesData = 0;

	public void OnEnable(){
		if (!Load ()) {
			foodData = 0;
			goldData = 0;
			researchData = 0;
			suppliesData = 0;
		}
	}

	public void OnDisable(){
		Save ();
	}
	//singleton stuff
	void Awake(){
		if(controller == null)
		{
			DontDestroyOnLoad(gameObject);
			controller = this;
		}

		else if (controller != this)
		{
			Destroy(gameObject);
		}
	}


	public void setFoodData(float n){
		foodData = n;
	}

	public void setGoldData(int n){
		goldData = n;
	}

	public void setResearchData(int n){
		researchData = n;
	}

	public void setSuppliesData(int n){
		suppliesData = n;
	}

	public float getFoodData(){
		return foodData;
	}

	public int getGoldData(){
		return goldData;
	}

	public int getResearchData(){
		return researchData;
	}

	public int getSuppliesData(){
		return suppliesData;
	}

	public void addFoodData(float n){
		foodData = foodData + n;
	}

	public void addGoldData(int n){
		goldData += n;
	}

	public void addResearchData(int n){
		researchData += n;
	}

	public void addSuppliesData(int n){
		suppliesData += n;
	}

	public void subtractFoodData(int n){
		foodData -= n;
	}

	public void subtractGoldData(int n){
		goldData -= n;
	} 	

	public void subtractResearchData(int n){
		researchData -= n;
	}

	public void subtractSuppliesData(int n){
		suppliesData -= n;
	}
	/*
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");

		GameData data = new GameData();
		data.food = foodData;
		data.gold = goldData;
		data.research = researchData;
		data.supplies = suppliesData;

		bf.Serialize(file, data);
		file.Close();
	}

	public bool Load()
	{
		Debug.Log (Application.persistentDataPath);
		if(File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);

			GameData data = (GameData)bf.Deserialize(file);
			file.Close();

			foodData = data.food;
			goldData = data.gold;
			researchData = data.research;
			suppliesData = data.supplies;

			return true;
		}

		return false;
	}

}

[Serializable]
class GameData{
	public float food;
	public int gold;
	public int research;
	public int supplies;
}