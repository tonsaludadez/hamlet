using UnityEngine;
using System.Collections;

public class Hunter : MonoBehaviour {
	public string hunterName;
	public int hunterGender; //1 for male, 2 for female. Not  useful for now, but maybe the need for gender classification would arise in the future
	public int hunterFarmingLevel;
	public int hunterResearchLevel;
	public int hunterHuntingLevel;
	public int huntingExp;
	public int farmingExp;
	public int researchExp;
	public static int MAX_EXP = 100;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

	}
	public string getHunterName(){
		return hunterName;
	}

	public void setHunterName(string n){
		hunterName = n;
	}

	public int getFarmingLevel(){
		return hunterFarmingLevel;
	}

	public void setFarmingLevel(int n){
		hunterFarmingLevel = n;
	}

	public int getResearchLevel(){
		return hunterResearchLevel;
	}

	public void setResearchLevel(int n){
		hunterResearchLevel = n;
	}

	public int getHuntingLevel(){
		return hunterHuntingLevel;
	}

	public void setHuntingLevel(int n){
		hunterHuntingLevel = n;
	}

	public void addFarmingExp(int n){
		farmingExp += n;
		if (farmingExp >= MAX_EXP) {
			setFarmingLevel (hunterFarmingLevel + 1);
			farmingExp = farmingExp % MAX_EXP;
		}
	}

	public void addResearchExp(int n){
		researchExp += n;
		if (researchExp >= MAX_EXP) {
			setResearchLevel (hunterResearchLevel + 1);
			researchExp = researchExp % MAX_EXP;
		}
	}

	public void addHuntingExp(int n){
		huntingExp += n;
		if (huntingExp >= MAX_EXP) {
			setHuntingLevel (hunterHuntingLevel + 1);
			huntingExp = huntingExp % MAX_EXP;
		}
	}

}
