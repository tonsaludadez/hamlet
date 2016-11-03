using UnityEngine;
using System.Collections;

public class TooltipContentController : MonoBehaviour {


	public static TooltipContentController tcontroller;
	//public Sprite [] AnimalImages;
	public GameObject tooltipPanel;
	public GameObject tooltipContentFarm;
	public GameObject tooltipContentAcademy;
	//public GameObject tooltipContentWorkshop;
	GameObject newContent;
	void Awake(){
		if(tcontroller == null)
		{
			DontDestroyOnLoad(gameObject);
			tcontroller = this;
		}

		else if (tcontroller != this)
		{
			Destroy(gameObject);
		}
	}

	void Start () {

		// 2. Iterate through the data, 
		//	  instantiate prefab, 
		//	  set the data, 
		//	  add it to panel

	}

	public void addContentToTooltip(GameObject newContent, Hunter hunter){
		/*Debug.Log ("IN");
		GameObject newHunter = Instantiate(ListItemPrefab) as GameObject;
		HunterListItemController controller= newHunter.GetComponent<HunterListItemController>();
		controller.hunterName.text = hunter.Name;
		controller.farmingLvl.value = hunter.farmingLvl;
		controller.researchLvl.value = hunter.researchLvl;
		controller.huntingLvl.value = hunter.huntingLvl;
		newHunter.transform.parent = newContent.transform;
		newHunter.transform.localScale = Vector3.one;
		newHunter.transform.localPosition = Vector3.one;*/
	}

	public void displayContent(string structureName){
		
		if (structureName == "Farm") {
			if (!newContent)
				newContent = Instantiate (tooltipContentFarm) as GameObject;
			FarmTooltipItemController controller = newContent.GetComponent<FarmTooltipItemController> ();
			controller.foodData.text = GameController.controller.getFoodData ().ToString ();
			controller.farmerData.text = GameController.controller.farm.getCount ().ToString ();
			newContent.transform.parent = tooltipPanel.transform;
			newContent.transform.localScale = Vector3.one;
			newContent.transform.localPosition = Vector3.one;
		} else if (structureName == "Academy") {
			if (!newContent)
				newContent = Instantiate (tooltipContentAcademy) as GameObject;
			AcademyTooltipItemController controller = newContent.GetComponent<AcademyTooltipItemController> ();
			controller.researchData.text = GameController.controller.getResearchData ().ToString ();
			controller.researcherData.text = GameController.controller.academy.getCount ().ToString ();
			newContent.transform.parent = tooltipPanel.transform;
			newContent.transform.localScale = Vector3.one;
			newContent.transform.localPosition = Vector3.one;
		
		}	
	//	} else if (structureName == "Workshop") {

//		}
	}

	public void closeDisplay(){
		Destroy (newContent);
	}
}
