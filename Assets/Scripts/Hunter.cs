using UnityEngine;
using System.Collections;
using System;

public class Hunter : MonoBehaviour {
	public string hunterName;
	public bool hunterGender;	//true for male, False for female. Note: Bool is equivalent to 0 & 1

	private int hunterID; 		//unique identifier for Hunter instance, essentially a 'key'
	
	public int farmingLvl;		//Hunter's current level [Farming]
	public int researchLvl;		//Hunter's current level [Research]
	public int huntingLvl;		//Hunter's current level [Hunting]

	public int farmingExp;				//Hunter's current xp to NextLevel [Farming]
	public int researchExp;				//Hunter's current xp to NextLevel [Research]
	public int huntingExp;				//Hunter's current xp to NextLevel [Hunting]
	
	public int farmingToNextLvl;		//How many xp 'til NextLevel [Farming]
	public int researchToNextLvl;		//How many xp 'til NextLevel [Research]
	public int huntingToNextLvl;		//How many xp 'til NextLevel [Hunting]

	public int accumulatedFarmingExp;	//Total xp gained/accumulated [Farming]
	public int accumulatedResearchExp;	//Total xp gained/accumulated [Research]
	public int accumulatedHuntingExp;	//Total xp gained/accumulated [Hunting]

	public string hunterTitle;			//Hunter's 'title' based on current xp levels; May not be necessary [see: title()]

	//public static int MAX_EXP = 100; //don't use this
	public static int DEFAULT_LEVEL = 1;

	public Hunter(int id){		//*ATTENTION* requires Random Name Generator


		hunterID = id;

		farmingLvl = DEFAULT_LEVEL;
		researchLvl = DEFAULT_LEVEL;
		huntingLvl = DEFAULT_LEVEL;

		farmingToNextLvl = calculateNextLvl(farmingLvl);
		researchToNextLvl = calculateNextLvl(researchLvl);
		huntingToNextLvl = calculateNextLvl(huntingLvl);

		accumulatedFarmingExp = 0;
		accumulatedResearchExp = 0;
		accumulatedHuntingExp = 0;
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {

	}

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	/*Hunter Data Funtions [Excluding Level and Serial]*/

	public string getName(){				//getter function	
		return hunterName;
	}

	public void setHunterName(string n){	//setter function
		hunterName = n;
	}

	public string title(){					//getter function; determines title based on level comparison
		/*
		For Reference:
			Farmer			=	Farmer Level only
			Researcher		=	Research Level only
			Hunter			=	Hunter Level only

			Trapper			=	Hunter and Farmer Levels equal
			Agriculturist	=	Farmer and Researcher Levels equal
			Explorer		=	Researcher and Hunter Levels equal

			All-Rounder		=	[Default] All levels equal
		*/

		if((farmingLvl > researchLvl) && (farmingLvl > huntingLvl))
			hunterTitle = "Farmer";
		else if((researchLvl > farmingLvl) && (researchLvl > huntingLvl))
			hunterTitle = "Researcher";
		else if((huntingLvl > farmingLvl) && (huntingLvl > researchLvl))
			hunterTitle = "Hunter";

		else if((huntingLvl == farmingLvl) && (huntingLvl > researchLvl))
			hunterTitle = "Trapper";
		else if((farmingLvl == researchLvl) && (farmingLvl > huntingLvl))
			hunterTitle = "Agriculturist";
		else if((researchLvl == huntingLvl) && (researchLvl > farmingLvl))
			hunterTitle = "Explorer";

		else
			hunterTitle = "All-Rounder";

		return hunterTitle;
	}

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	/*Level Getting Functions*/

	public int getFarmingLvl(){				//getter function
		return farmingLvl;
	}

	public int getResearchLvl(){			//getter function	
		return researchLvl;
	}

	public int getHuntingLvl(){				//getter function	
		return huntingLvl;
	}

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	/*Level Setting Functions*/

	public void setFarmingLvl(int n){		//setter function
		farmingLvl = n;
	}

	public void setResearchLvl(int n){	//setter function
		researchLvl = n;
	}

	
	public void setHuntingLvl(int n){		//setter function
		huntingLvl = n;
	}

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	/*EXP Adding Functions*/

	public void addExp(int exp, string type){		//type refers to either Farming/Hunting/Research
		int levels = 0;			//for tracking number of Lvl Ups

		//Adding Farming Levels
		if(type == "farm")
		{
			accumulatedFarmingExp += exp;

			while(exp > 0)
			{
				if(farmingToNextLvl - exp <= 0)
				{
					exp -= farmingToNextLvl;

					farmingLvl++;
					farmingToNextLvl = calculateNextLvl(farmingLvl);

					Debug.Log("Farming Leveled Up!");	//for debugging:Tracking
					levels++;
				}
				else
				{
					farmingToNextLvl -= exp;
					exp = 0;
				}
			}

			Debug.Log("Gained " + levels + " Levels!");
		}

		//Adding Research Levels
		else if(type == "research")
		{
			accumulatedResearchExp += exp;

			while(exp > 0)
			{
				if(researchToNextLvl - exp <= 0)
				{
					exp -= researchToNextLvl;

					researchLvl++;
					researchToNextLvl = calculateNextLvl(researchLvl);

					Debug.Log("Research Leveled Up!");	//for debugging:Tracking
					levels++;
				}
				else
				{
					researchToNextLvl -= exp;
					exp = 0;
				}
			}

			Debug.Log("Gained " + levels + " Levels!");	//for debugging:Tracking
		}

		//Adding Hunting Levels
		else if(type == "hunt")
		{
			accumulatedHuntingExp += exp;

			while(exp > 0)
			{
				if(huntingToNextLvl - exp <= 0)
				{
					exp -= huntingToNextLvl;

					huntingLvl++;
					huntingToNextLvl = calculateNextLvl(huntingLvl);

					Debug.Log("Hunting Leveled Up!");	//for debugging:Tracking
					levels++;
				}
				else
				{
					huntingToNextLvl -= exp;
					exp = 0;
				}
			}

			Debug.Log("Gained " + levels + " Levels!");	//for debugging:Tracking
		}

		//Updates title when Lvl rises
		if(levels > 0)
			title();
		
	}

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	/*SerialID Functions*/

	public int serialID(){				//getter function
		return hunterID;
	}

	private void assignSerialID(int id){
		hunterID = id;
	}

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	/*Level Calculation Functions*/

	public int calculateNextLvl(int currentLvl){
		if(currentLvl == 25)
			return 0;
		else if(currentLvl <= 1)
			return 100;

		int adjustedLvl = currentLvl - 1;

		return 100 + (int)((41.25 *(adjustedLvl * adjustedLvl) )/2);
	}

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	/*Comparison Function [for sorting]*/

	public int compare(Hunter operand, string comparator){
		return new int();
	}
}
