using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class HunterList : MonoBehaviour {

	public List<Hunter> hunterList;
    private int NextSerial;

    /*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

    public HunterList()                 //HunterList Constructor
    {
        hunterList = new List<Hunter>(100); //Creates a list of size 100;
        NextSerial = 0;
    }

    /*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

    /*Hunter List Functions*/

    public Hunter find(int hunterID){       //Store keys in your Building then utilize this to get the hunter

        Predicate<Hunter> hunterFinder = (Hunter h) => { return h.Serial == hunterID; };

        return hunterList.Find(hunterFinder); //returns null if Hunter doesn't exist
    }

    public bool add(){
        return add(new Hunter(NextSerial));
    }

    public bool add(Hunter hunter)
    {
        if(hunterList.Count >= 100)
            return false;

        hunterList.Add(hunter);
        NextSerial++;
        
        return true;
    }

    public bool remove(Hunter hunter){
        return hunterList.Remove(hunter);
    }

    public bool remove(int hunterID){
        return remove(find(hunterID));
    }

	/*`````````````````````````````````````````````````````````````````````````````````````````````````````````````````````````*/

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