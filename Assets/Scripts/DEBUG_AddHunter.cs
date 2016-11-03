using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
public class DEBUG_AddHunter : MonoBehaviour, IPointerClickHandler {

	//public GameObject dBox;
	//public Text title;
	//public string structureName;


	#region IPointerClickHandler implementation

	public void OnPointerClick (PointerEventData eventData)
	{
		GameController.controller.listData.add ();
	}

	#endregion

	// Use this for initialization
	void Awake () {

	}
	/*
	void OnMouseDown () {
		if (!EventSystem.current.IsPointerOverGameObject ()) {
			
		}
	}*/
}
