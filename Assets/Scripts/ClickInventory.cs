using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickInventory : MonoBehaviour {

    Button myButton;
    public GameObject dBox;
    public Text title;

    // Use this for initialization
    void Awake()
    {
        myButton = GetComponent<Button>();

        myButton.onClick.AddListener(() => { OpenInventory(); });
    }

    void OpenInventory()
    {
        Debug.Log(myButton.transform.parent.gameObject);
        dBox.SetActive(true);
        title.text = "Inventory";
    }
}
