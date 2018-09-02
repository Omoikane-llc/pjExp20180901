using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainController : MonoBehaviour {
	public float scrollRate;

	[HideInInspector]
	public bool UpScroll;

	[HideInInspector]
	public bool DownScroll;

	[HideInInspector]
	public bool OptionClicked;

	[HideInInspector]
	public string optionName;

	private GameObject actController;
	private int currentIndex;
	private GameObject[] selectOptions;
	private float timeCount;

	// Use this for initialization
	void Start () {
		if (scrollRate == 0.0f) {
			this.scrollRate = 1.0f;
		}
		this.UpScroll = false;
		this.DownScroll = false;
		this.OptionClicked = false;
		this.currentIndex = 0;
		this.selectOptions = GameObject.FindGameObjectsWithTag ("SelectOption");
		this.actController = GameObject.Find ("ActController");
		InitSelectOptions (selectOptions);
	}
	
	// Update is called once per frame
	void Update () {
		timeCount += Time.deltaTime;

		if (UpScroll && timeCount > scrollRate) {
			Debug.Log ("UpScroll " + currentIndex);
			DisplayOption ();
			this.timeCount = 0.0f;
			CountUpIndex ();
		}

		if (DownScroll && timeCount > scrollRate) {
			Debug.Log ("DownScroll " + currentIndex);
			DisplayOption ();
			this.timeCount = 0.0f;
			CountDownIndex ();
		}

		if (OptionClicked) {
			Debug.Log ("OptionClicked " + optionName);
			actController.GetComponent<ActionController> ().DoAction (optionName);
			OptionClicked = false;
		}
	}

	private void InitSelectOptions(GameObject[] selectOptions){
		if (selectOptions == null || selectOptions.Length == 0) {
			Debug.LogWarning ("No SelectOptions ");
		}

		DisplayOption ();
	}

	private void DisplayOption(){
		for (var i = 0; i < selectOptions.Length; i++) {
			if (i == currentIndex) {
				selectOptions [i].SetActive (true);
			} else {
				selectOptions [i].SetActive (false);
			}
		}
	}

	private void CountUpIndex(){
		CountIndex (1);
	}

	private void CountDownIndex(){
		CountIndex (-1);
	}

	private void CountIndex(int step){
		if (currentIndex > 0 && currentIndex < (selectOptions.Length - 1)) {
			currentIndex += step;
		} else if (currentIndex == 0 && step > 0) {
			currentIndex += step;
		} else if (currentIndex == (selectOptions.Length - 1) && step < 0) {
			currentIndex += step;
		} else if (currentIndex == 0 && step < 0) {
			currentIndex = (selectOptions.Length - 1);
		} else if (currentIndex == (selectOptions.Length - 1) && step > 0) {
			currentIndex = 0;
		}
	}
}
