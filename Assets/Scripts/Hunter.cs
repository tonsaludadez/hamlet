using UnityEngine;
using System.Collections;

public class Hunter : MonoBehaviour {
	public string hunterName;
	public bool hunterGender;	//true for male, False for female. Note: Bool is equivalent to 0 & 1

	private int hunterID; 		//unique identifier for Hunter instance, essentially a 'key'
	
	public int hunterFarmingLvl;
	public int hunterResearchLvl;
	public int hunterHuntingLvl;

	public int huntingExp;
	public int farmingExp;
	public int researchExp;

	public int huntingToNextLvl;
	public int farmingToNextLvl;
	public int researcTohNextLvl;


	public int accumulatedHuntingExp;
	public int accumulatedFarmingExp;
	public int accumulatedResearchExp;

	//public static int MAX_EXP = 100; //don't use this

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

	}
	public string hunterName(){			//Let's make it a convention that getters have no gets as if you're accessing the thing itself
		return hunterName;
	}

	public void setHunterName(string n){
		hunterName = n;
	}

	public int farmingLevel(){			//Let's make it a convention that getters have no gets as if you're accessing the thing itself
		return hunterFarmingLevel;
	}

	public void setFarmingLevel(int n){
		hunterFarmingLevel = n;
	}

	public int researchLevel(){			//Let's make it a convention that getters have no gets as if you're accessing the thing itself
		return hunterResearchLevel;
	}

	public void setResearchLevel(int n){
		hunterResearchLevel = n;
	}

	public int huntingLevel(){			//Let's make it a convention that getters have no gets as if you're accessing the thing itself
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

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	public int serialID(){
		return hunterID;
	}

	public void assignSerialID(int id){
		
	}

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	public int calculateNextLevel(int currentLvl){
		return new int;
	}
}
