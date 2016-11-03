using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable()]
public class ListCast{
	public List<Hunter> hunterList;
	public int nextSerial;

    public ListCast(HunterList list){
    	this.hunterList = list.hunterList;
    	this.nextSerial = list.NextSerial;
    }

    public int Count{
    	get{
    		return hunterList.Count;
    	}
    }
}