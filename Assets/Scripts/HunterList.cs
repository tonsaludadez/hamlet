using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class HunterList : MonoBehaviour {

	public List<Hunter> hunterList;
    private int nextSerial;

    public int NextSerial{
        get{
            return nextSerial;
        }
    }

	public int Count{
		get{
			return hunterList.Count;
		}
	}

    /*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

    public HunterList()                 //HunterList Constructor
    {
        hunterList = new List<Hunter>(100); //Creates a list of size 100;
        nextSerial = 0;
    }

    public HunterList(ListCast cast){
        hunterList = cast.hunterList;
        nextSerial = cast.nextSerial;
    }

    /*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

    /*Hunter List Functions*/

    public Hunter find(int hunterID){       //Store keys in your Building then utilize this to get the hunter

        Predicate<Hunter> hunterFinder = (Hunter h) => { return h.Serial == hunterID; };

        return hunterList.Find(hunterFinder); //returns null if Hunter doesn't exist
    }

    public bool add(){
        return add(new Hunter(nextSerial));
    }

    public bool add(Hunter hunter)
    {
        
		if (hunter.Serial % 2 == 0) {
			hunter.Job = "Farmer";
			GameController.controller.assignHunter(hunter.Job, hunter.hunterID);

		} else {
			hunter.Job = "Researcher";
			GameController.controller.assignHunter(hunter.Job, hunter.hunterID);

		}
		if(hunterList.Count >= 100)
            return false;

        hunterList.Add(hunter);
	 	nextSerial++;
        
        return true;
    }
	
    public bool remove(Hunter hunter){
        return hunterList.Remove(hunter);
    }

    public bool remove(int hunterID){
        return remove(find(hunterID));
    }

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/
	/*
	void Update(){
		if (Time.time %2  == 0) {
			GameController.controller.subtractFoodData (hunterList.Count);
			Debug.Log (hunterList.Count);
			Debug.Log (GameController.controller.foodData);
		}
	}*/

	//Sorting Function

	/**
	*
	* @author francis1
 	*/

 	//On first call, put 0 as lower and array.size - 1 as higher
	private void sortBy(int lowerIndex, int higherIndex, string sortType) {
         
        int i = lowerIndex;
        int j = higherIndex;
        // calculate pivot number, I am taking pivot as middle index number
        Hunter pivot = hunterList[lowerIndex+(higherIndex-lowerIndex)/2];
        // Divide into two arrays
        while (i <= j) {
            /**
             * In each iteration, we will identify a number from left side which 
             * is greater then the pivot value, and also we will identify a number 
             * from right side which is less then the pivot value. Once the search 
             * is done, then we exchange both numbers.
             */
            while (hunterList[i].compare(pivot,sortType) < 0) {
                i++;
            }
            while (hunterList[j].compare(pivot,sortType) > 0) {
                j--;
            }
            if (i <= j) {
                exchangeNumbers(i, j);
                //move index to next position on both sides
                i++;
                j--;
            }
        }
        // call quickSort() method recursively
        if (lowerIndex < j)
            sortBy(lowerIndex, j, sortType);
        if (i < higherIndex)
            sortBy(i, higherIndex, sortType);
    }
    private void exchangeNumbers(int i, int j) {
        Hunter temp = hunterList[i];
        hunterList[i] = hunterList[j];
        hunterList[j] = temp;
    }

}