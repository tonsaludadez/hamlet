using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class ClickStructure : MonoBehaviour, IPointerClickHandler {

    //public GameObject dBox;
	//public GameObject hList;
	//public GameObject fList;
	//public GameObject aList;
	//public GameObject wlist;
	//public GameObject content;
	public Text title;
    public string structureName;
	public Text upgradeTitle;

	public GameObject panel;

	#region IPointerClickHandler implementation

	public void OnPointerClick (PointerEventData eventData)
	{
		panel.SetActive (true);

		HunterListController.hlcontroller.displayHunters (structureName);// PUT THIS ON A SEPARATE BUTTON!
		title.text = structureName;

	/*if(!structureName.Equals("Hamlet Hall"))
			upgradeTitle.text = "Upgrade " + structureName;
		else
			upgradeTitle.text = "Upgrade";*/
	}

	#endregion

	// Use this for initialization
	void Awake () {
	    
	}
}
