using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloseDialogue : MonoBehaviour {

    Button myButton;
	//public GameObject content;

	// Use this for initialization
	void Awake() {
        myButton = GetComponent<Button>();

        myButton.onClick.AddListener(() => { CloseDialogueBox(); });
	}

    void CloseDialogueBox()
    {
        Debug.Log(myButton.transform.parent.gameObject);
        GameObject parent = myButton.transform.parent.gameObject;
        parent = parent.transform.parent.gameObject;
        parent = parent.transform.parent.gameObject;
        parent = parent.transform.parent.gameObject;
		parent.SetActive(false);
		HunterListController.hlcontroller.closeDisplay ();


    }

}
