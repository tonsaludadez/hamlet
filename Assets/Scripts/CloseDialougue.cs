using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CloseDialougue : MonoBehaviour {

    Button myButton;

	// Use this for initialization
	void Awake() {
        myButton = GetComponent<Button>();

        myButton.onClick.AddListener(() => { CloseDialougeBox(); });
	}

    void CloseDialougeBox()
    {
        Debug.Log(myButton.transform.parent.gameObject);
        GameObject parent = myButton.transform.parent.gameObject;
        parent = parent.transform.parent.gameObject;
        parent = parent.transform.parent.gameObject;
        parent = parent.transform.parent.gameObject;
        parent.SetActive(false);
    }

}
