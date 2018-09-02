using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;


public class GazeController : MonoBehaviour, IFocusable{
	private GameObject uiController;
	private string objName;
	// Use this for initialization
	void Start () {
		this.uiController = GameObject.Find ("UIController");
		this.objName = gameObject.name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// フォーカス(注視)し始めたとき時 
	public void OnFocusEnter() {
		Debug.Log ("Start OnFocusEnter " + objName);
		if(objName.StartsWith("Up")) {
			uiController.GetComponent<UIMainController> ().UpScroll = true;
		}

		if(objName.StartsWith("Down")) {
			uiController.GetComponent<UIMainController> ().DownScroll = true;
		}
	}
	// フォーカス(注視)が外れた 
	public void OnFocusExit() {
		Debug.Log ("Start OnFocusExit " + objName);
		if(objName.StartsWith("Up")) {
			uiController.GetComponent<UIMainController> ().UpScroll = false;
		}

		if(objName.StartsWith("Down")) {
			uiController.GetComponent<UIMainController> ().DownScroll = false;
		}
	}

}
