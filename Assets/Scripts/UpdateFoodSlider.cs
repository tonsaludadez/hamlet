using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateFoodSlider : MonoBehaviour {

	public Canvas RMHud;
	public Slider sliderFood;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		sliderFood.value = GameController.controller.foodData;

	}
}
