using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickStructure : MonoBehaviour {

    public GameObject dBox;
    public Text title;
    public string structureName;

	// Use this for initialization
	void Awake () {
	    
	}
	
	// Update is called once per frame
	void OnMouseDown () {
        dBox.SetActive(true);
        title.text = structureName;
	}
}
