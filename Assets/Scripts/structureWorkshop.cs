using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StructureWorkshop : MonoBehaviour {

	//public static structureWorkshop workshop;
	public List<int> workerList;

	public int levelWorkshop;

	public StructureWorkshop(){
		workerList = new List<int>();
		levelWorkshop = 1;
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

	public int getCount(){
		return workerList.Count;
	}

	public bool addToList(int id){
		if (workerList.Count < getLevel () * 3) {
			workerList.Add (id);
			return true;
		} else
			return false;
	}
}
