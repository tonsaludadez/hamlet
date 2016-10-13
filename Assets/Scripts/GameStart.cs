using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameStart : MonoBehaviour {

	Button currButton;

	void Awake()
	{
		currButton = GetComponent<Button> ();

		currButton.onClick.AddListener (() => {
			doBehavior ();
		});


	}

	void doBehavior()
	{
		SceneManager.LoadScene ("ResourceManagement");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
