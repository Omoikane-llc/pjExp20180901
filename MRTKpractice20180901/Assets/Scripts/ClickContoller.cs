using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class ClickContoller : MonoBehaviour, IInputClickHandler {
	private string objName;
	private GameObject uiController;
	// Use this for initialization
	void Start () {
		this.objName = gameObject.name;
		this.uiController = GameObject.Find ("UIController");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// 注視&クリック(AirTap)されると呼び出される 
	public void OnInputClicked(InputClickedEventData eventData) {
		Debug.Log ("OnInputClicked " + objName);
		uiController.GetComponent<UIMainController> ().OptionClicked = true;
		uiController.GetComponent<UIMainController> ().optionName = objName;
	}

}
