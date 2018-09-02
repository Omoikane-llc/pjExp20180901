using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionController : MonoBehaviour {

	private GameObject[] effectActions;
	private Vector3[] initPotions;
	// Use this for initialization
	void Start () {
		this.effectActions = GameObject.FindGameObjectsWithTag ("ActionObject");
		InitActions ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DoAction(string optionName){
		switch (optionName) {
		case "Option01":
			Debug.Log ("Option01 action");
			var action01 = GetAction ("Action01");
			StartMove (action01);
			StartCoroutine (PlayEffect(1.5f, action01));
			break;
		case "Option02":
			Debug.Log ("Option02 action");
			var action02 = GetAction ("Action02");
			StartMove (action02);
			StartCoroutine (PlayEffect(1.5f, action02));
			break;
		case "Option03":
			Debug.Log ("Option03 action");
			var action03 = GetAction ("Action03");
			StartMove (action03);
			StartCoroutine (PlayEffect(1.5f, action03));
			break;
		default:
			Debug.LogWarning ("invalid optionName " + optionName);
			break;
		}
	}
	private void InitActions(){
		if (effectActions == null || effectActions.Length == 0) {
			Debug.LogWarning ("No effectActions ");
		}

		initPotions = new Vector3[effectActions.Length];
		for (var i = 0; i < effectActions.Length; i++) {
			var obj = effectActions [i].transform;
			initPotions [i] = new Vector3 (obj.position.x, obj.position.y, obj.position.z);
			effectActions [i].SetActive (false);
		}
	}

	private GameObject GetAction(string ActionName){
		for (var i = 0; i < effectActions.Length; i++) {
			if (effectActions [i].name.Equals (ActionName)) {
				effectActions [i].SetActive (true);
				return effectActions [i];
			}
		}
		Debug.LogError ("Invalid ActionName " + ActionName);
		return null;
	}

	private void StartMove(GameObject actionObj){
		//var actionObj = GetAction (ActionName);
		var force = new Vector3 (0.0f, 0.0f, 10.0f);
		actionObj.GetComponent<Rigidbody> ().AddForce (force, ForceMode.Impulse);
	}

	private IEnumerator PlayEffect(float waitTime, GameObject actionObj){
		yield return new WaitForSeconds(waitTime);
		PlayEffect(actionObj);
	}

	private void PlayEffect(GameObject actionObj){
		actionObj.GetComponent<ParticleSystem> ().Play ();
		ResetPosition (actionObj.name);
	}

	private void ResetPosition(string ActionName){
		for (var i = 0; i < effectActions.Length; i++) {
			if (effectActions [i].name.Equals (ActionName)) {
				effectActions [i].transform.position = initPotions [i];
			}
		}
	}
}
