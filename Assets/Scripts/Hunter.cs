using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

[Serializable()]
public class Hunter : IEquatable<Hunter> {
// public class Hunter : MonoBehaviour {
	public string hunterName;				//Hunter's Name
	public string hunterGender;				//uses Male/Female
	public string hunterProfession;			//indicator of what facility the hunter is in

	public int hunterID; 					//unique identifier for Hunter instance, essentially a 'key'
	
	public int farmingLvl;					//Hunter's current level [Farming]
	public int researchLvl;					//Hunter's current level [Research]
	public int huntingLvl;					//Hunter's current level [Hunting]

	public int farmingExp;					//Hunter's current xp to NextLevel [Farming]
	public int researchExp;					//Hunter's current xp to NextLevel [Research]
	public int huntingExp;					//Hunter's current xp to NextLevel [Hunting]
	
	public int farmingToNextLvl;			//How many xp 'til NextLevel [Farming]
	public int researchToNextLvl;			//How many xp 'til NextLevel [Research]
	public int huntingToNextLvl;			//How many xp 'til NextLevel [Hunting]

	public int accumulatedFarmingExp;		//Total xp gained/accumulated [Farming]
	public int accumulatedResearchExp;		//Total xp gained/accumulated [Research]
	public int accumulatedHuntingExp;		//Total xp gained/accumulated [Hunting]

	public string artReference;				//Reference for art {to be implemented}
	private string hunterTitle;				//Hunter's 'title' based on current xp levels; May not be necessary [see: title()]

	private static int DEFAULT_LEVEL = 1;
	private static string[] GENDER = new string[] {"Male","Female"};

	public Hunter(int id){		//*ATTENTION* requires Random Name Generator
		this.Serial = id;

		Gender = GENDER[Random.Range(0,GENDER.Length)];

		if(string.Compare(Gender,"Male") == 0)
			Name = Utility.RandomBoyName();
		else
			Name = Utility.RandomGirlName();

		if (Serial % 3 == 0)
			Job = "Farmer";
		else if(Serial % 3 == 1)
			Job = "Researcher";
		else if(Serial % 3 == 2)
			Job = "Worker";

//		farmingLvl = DEFAULT_LEVEL;
//		researchLvl = DEFAULT_LEVEL;
//		huntingLvl = DEFAULT_LEVEL;

		farmingLvl = Random.Range(1,3);
		researchLvl = Random.Range(1,3);
		huntingLvl = Random.Range(1,3);


		farmingToNextLvl = calculateNextLvl(farmingLvl);
		researchToNextLvl = calculateNextLvl(researchLvl);
		huntingToNextLvl = calculateNextLvl(huntingLvl);

		accumulatedFarmingExp = 0;
		accumulatedResearchExp = 0;
		accumulatedHuntingExp = 0;

		Debug.Log ("added");
		//return this;
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

		//Hunter Personal Data
		public string Name{
			get{
				return hunterName;
			}
			private set{
				hunterName = value;
			}
		}

		public string Gender{
			get{
				return hunterGender;
			}
			private set{
				hunterGender = value;
			}
		}

		public int Serial{
			get{
				return hunterID;
			}
			private set{				//Only the class can assign the value
				hunterID = value;
			}
		}

		public string Job{
			get{
				return hunterProfession;
			}
			set{
				hunterProfession = value;
				
			}
		}

		//Skill Levels
		public int FarmLvl
		{
			get{
				return farmingLvl;
			}
		}
		public int ResearchLvl
		{
			get{
				return researchLvl;
			}
		}
		public int HuntLvl
		{
			get{
				return huntingLvl;
			}
		}

		//Exp values::Current Level
		public int FarmExp
		{
			get{
				return farmingExp;
			}
		}
		public int ResearchExp
		{
			get{
				return researchExp;
			}
		}
		public int HuntExp
		{
			get{
				return huntingExp;
			}
		}
	
		//Exp values::To Next Level
		public int FarmNextLvl
		{
			get{
				return farmingToNextLvl;
			}
		}

		public int ResearchNextLvl{
			get{
				return researchToNextLvl;
			}
		}

		public int HuntNextLvl
		{
			get{
				return huntingToNextLvl;
			}
		}


		//Exp values::Total Accumulated Exp
		public int TotalFarmExp
		{
			get{
				return accumulatedFarmingExp;
			}
		}
		public int TotalResearchExp
		{
			get{
				return accumulatedResearchExp;
			}
		}
		public int TotalHuntExp
		{
			get{
				return accumulatedHuntingExp;
			}
		}

		//Hunter Title
		public string Title
		{
			get
			{
				return title();
			}
		}			//useless because of title()


	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/
	/*public bool addToProfession(string value){
		if (value == "Farmer") {
			if (structureFarm.farm.farmerList.Count < structureFarm.farm.getLevel () * 3) {
				structureFarm.farm.farmerList.Add (Serial);
				//FarmerListController.flcontroller.addHunterToUI (HunterList.find(Serial));
				return true;
			}
		} else if (value == "Researcher") {
			if (structureAcademy.academy.researcherList.Count < structureAcademy.academy.getLevel () * 3) {
				structureAcademy.academy.researcherList.Add (Serial);
			//	ResearcherListController.rlcontroller.addHunterToUI (HunterList.find(Serial));
				return true;
			}
		} else if (value == "Worker") {
			if (structureWorkshop.workshop.workerList.Count < structureWorkshop.workshop.getLevel () * 3) {
				structureWorkshop.workshop.workerList.Add (Serial);
			//	WorkerListController.wlcontroller.addHunterToUI (HunterList.find(Serial));
				return true;
			}
		} else
			return false;

		return false;
	}*/
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

	/*SerialID Functions*/ //fundamentally useless

	/*
	public int serialID(){				//getter function
		return hunterID;
	}

	private void assignSerialID(int id){
		hunterID = id;
	}
	*/

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

	/*For implementing IEquatable interface*/

	public override string ToString()			//outputs Serial [i.e. hunterID] when converted to String
    {
        return Serial.ToString();
    }

    public override bool Equals(object obj)		//overrides == & != [allows comparison with generic Object]
    {
        if (obj == null) return false;

        Hunter hunterObject = obj as Hunter;	//casts generic object to Hunter

        if (hunterObject == null) return false;
        else return Equals(hunterObject);
    }
    public override int GetHashCode()			//Serial is now the Object's Hashcode
    {
        return Serial;
    }

    public bool Equals(Hunter other)			//Compares Serial property, objects are the same if serialID are the same
    {
        if (other == null) return false;

        return (this.Serial.Equals(other.Serial));
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
			return compareValue(accumulatedFarmingExp, operand.accumulatedFarmingExp);
		}

		else if(comparator == "research"){
			return compareValue(accumulatedResearchExp, operand.accumulatedResearchExp);
		}

		else if(comparator == "hunt"){
			return compareValue(accumulatedHuntingExp, operand.accumulatedHuntingExp);
		}

		else if(comparator == "title"){
			return String.Compare(title(), operand.title(), false);
		}

		else if(comparator == "recent"){
			return compareValue(this.Serial, operand.Serial);
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
