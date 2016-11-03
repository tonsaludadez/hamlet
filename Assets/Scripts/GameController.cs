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

	public StructureFarm farm;
	public StructureAcademy academy;
	public StructureWorkshop workshop;

	public HunterList listData;

	public void OnEnable(){
		if (!Load ()) {
			foodData = 0;
			goldData = 0;
			researchData = 0;
			suppliesData = 0;

			listData = new HunterList();
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

	// Use this for initialization
	void Start () {
		// if(listData == null)
		// 	listData = new HunterList ();
		farm = new StructureFarm ();
		academy = new StructureAcademy ();
		workshop = new StructureWorkshop ();

		// OnEnable();
	}

	//---------------------------------------------------------------------------------------------------

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
	//---------------------------------------------------------------------------------------------------

	public bool assignHunter(String job, int hunterID){
		if (job == "Farmer") {
			return farm.addToList (hunterID);
		} else if (job == "Researcher") {
			return academy.addToList (hunterID);
		} else if (job == "Worker") {
			return workshop.addToList (hunterID);
		} else
			return false;
	}

	//---------------------------------------------------------------------------------------------------

	public void addHunter(){
		listData.add ();
	}

	//---------------------------------------------------------------------------------------------------

	public void Upgrade(String structure) {
		Debug.Log ("Upgrade!");
		if (structure.Equals ("Upgrade Hamlet Farm")) {
			GameController.controller.farm.levelFarm++;
			Debug.Log (GameController.controller.farm.getLevel());
		} else if (structure.Equals ("Upgrade Hamlet Academy")) {
			GameController.controller.academy.levelAcademy++;
			Debug.Log (GameController.controller.academy.getLevel());
		} else if (structure.Equals ("Upgrade Hamlet Workshop")) {
			GameController.controller.workshop.levelWorkshop++;
			Debug.Log (GameController.controller.workshop.getLevel());
		}

	}

	//---------------------------------------------------------------------------------------------------

	public void consumeFood(){
		GameController.controller.subtractFoodData (listData.Count);
		//Debug.Log (listData.Count);
		//Debug.Log (GameController.controller.foodData);
	}

	//---------------------------------------------------------------------------------------------------



	// Update is called once per frame
	float nextTime = 3.0F;
	void Update () {
		if (Time.time > nextTime) {
			nextTime += 3;
			GameController.controller.consumeFood ();

			GameController.controller.addFoodData(GameController.controller.farm.produced());
			GameController.controller.addResearchData(GameController.controller.academy.produced());
		}
	}

	public void Save()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");

		Debug.Log("Save Success!");

		GameData data = new GameData();
		data.food = foodData;
		data.gold = goldData;
		data.research = researchData;
		data.supplies = suppliesData;
		data.list = new ListCast(listData);

		Debug.Log("Count is: " + data.list.Count);

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
			listData = new HunterList(data.list);

			Debug.Log("Load Success!");
			Debug.Log("Count is: " + data.list.Count);

			return true;
		}

		Debug.Log("Load Failed!");
		return false;
	}

}

[Serializable]
class GameData{
	public float food;
	public int gold;
	public int research;
	public int supplies;
	public ListCast list;
}