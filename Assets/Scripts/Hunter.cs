using UnityEngine;
using System.Collections;
using System;

public class Hunter : MonoBehaviour {
	private string hunterName;
	public bool hunterGender;			//true for male, False for female. Note: Bool is equivalent to 0 & 1

	public int hunterID; 				//unique identifier for Hunter instance, essentially a 'key'
	
	public int farmingLvl;				//Hunter's current level [Farming]
	public int researchLvl;				//Hunter's current level [Research]
	public int huntingLvl;				//Hunter's current level [Hunting]

	public int farmingExp;				//Hunter's current xp to NextLevel [Farming]
	public int researchExp;			//Hunter's current xp to NextLevel [Research]
	public int huntingExp;				//Hunter's current xp to NextLevel [Hunting]
	
	public int farmingToNextLvl;		//How many xp 'til NextLevel [Farming]
	public int researchToNextLvl;		//How many xp 'til NextLevel [Research]
	public int huntingToNextLvl;		//How many xp 'til NextLevel [Hunting]

	public int accumulatedFarmingExp;	//Total xp gained/accumulated [Farming]
	public int accumulatedResearchExp;	//Total xp gained/accumulated [Research]
	public int accumulatedHuntingExp;	//Total xp gained/accumulated [Hunting]

	private string hunterTitle;			//Hunter's 'title' based on current xp levels; May not be necessary [see: title()]

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

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	//Properties

		/*
			Note: Use like a variable.
				i.e. name = Hunter.HunterName	//getter

			Message:
				"I just made some in case we'd rather use properties.
				We can remove them later in the final project"
													-Santino
		*/

		//Hunter Name
		public string HunterName{ get; set;}

		//Skill Levels
		public int FarmingLvl{ get; set;}
		public int ResearchLvl{ get; set;}
		public int HuntingLvl{ get; set;}

		//Exp values::Current Level
		public int FarmingExp{ get; set;}
		public int ResearchExp{ get; set;}
		public int HuntingExp{ get; set;}
	
		//Exp values::To Next Level
		public int FarmingToNextLvl
		{
			get{
				return farmingToNextLvl;
			}
		}

		public int ResearchToNextLvl{
			get{
				return researchToNextLvl;
			}
		}

		public int HuntingToNextLvl
		{
			get{
				return huntingToNextLvl;
			}
		}


		//Exp values::Total Accumulated Exp
		public int AccumulatedFarmingExp
		{
			get{
				return accumulatedFarmingExp;
			}
		}
		public int AccumulatedResearchExp
		{
			get{
				return accumulatedResearchExp;
			}
		}
		public int AccumulatedHuntingExp
		{
			get{
				return accumulatedHuntingExp;
			}
		}

		//Hunter Title
		public string HunterTitle{ get; set;}			//useless because of title()


	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

	/*Hunter Data Funtions [Excluding Level and Serial]*/

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

	//Compares 'this' with another Hunter instance
	//Comparator defines what is compared (i.e. sort by name, strength, level)
	public int compare(Hunter operand, string comparator){
		/*
		Comparators
			name		=	Compares Hunter Names
			farm		=	Compares Farming Levels
			research	=	Compares Research Levels
			hunt		=	Compares Hunter Levels
			title		=	Compares Titles
			recent		=	Compares recency (based on SerialID)
		*/

		if(comparator == "name")
		{

		}

		else if(comparator == "farm"){
			return compareValue(accumulatedFarmingExp, operand.AccumulatedFarmingExp);
		}

		else if(comparator == "research"){
			return compareValue(accumulatedResearchExp, operand.AccumulatedResearchExp);
		}

		else if(comparator == "hunt"){
			return compareValue(accumulatedHuntingExp, operand.AccumulatedHuntingExp);
		}

		else if(comparator == "title"){
			return String.Compare(title(), operand.title(), false);
		}

		else if(comparator == "recent"){
			return compareValue(serialID(), operand.serialID());
		}

		return 0;
	}

	//Helps in comparing int values; output is madeto be similar to String.Compare
	private int compareValue(int a, int b){
		if (a < b)
			return -1;
		else if (a > b)
			return 1;
		else
			return 0;
	}
}
