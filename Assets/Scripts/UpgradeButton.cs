using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour {

	Button myButton;
	public Text t;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake () {
		myButton = GetComponent<Button>();

		myButton.onClick.AddListener(() => { GameController.controller.Upgrade(t.text); });
	}


}
