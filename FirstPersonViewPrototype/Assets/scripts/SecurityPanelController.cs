﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class SecurityPanelController : MonoBehaviour {

	public GameObject codeDisplayPanel;
	public Text codeDisplayText;
	public string correctCode;
	public GameObject MachineRoomDoor;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++) {
			if (transform.GetChild(i).name == "CodePanel"){
				codeDisplayPanel = transform.GetChild (i).gameObject;
				codeDisplayText = codeDisplayPanel.transform.GetChild(0).GetComponent<Text>();
			}
		}
		codeDisplayText.text = "";
		gameObject.SetActive(false);
		MachineRoomDoor = GameObject.Find ("MachineRoomDoor");
	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			gameObject.SetActive(false);
		}

		if (isActiveAndEnabled) {
			GameObject.Find ("FPSController").GetComponent<FirstPersonController>().enabled = false;
		} else {
			GameObject.Find ("FPSController").GetComponent<FirstPersonController>().enabled = true;
		}
	}

	public void GetDigitInput(Text input){
		if (codeDisplayText.text.Length < 4) {
			codeDisplayText.text += input.text;
			StartCoroutine (UpdateTextField ());
		}
	}

	public void UndoInput(){
		if (codeDisplayText.text.Length > 0 && codeDisplayText.text.Length != 4){
			codeDisplayText.text = codeDisplayText.text.Remove(codeDisplayText.text.Length - 1);
			StartCoroutine(UpdateTextField ());
		}
	}

	IEnumerator UpdateTextField(){
		if (codeDisplayText.text.Length > 3) {
			if (codeDisplayText.text == correctCode) {
				codeDisplayPanel.GetComponent<Image> ().color = Color.green;
				yield return StartCoroutine (WaitForRealSeconds (2.0f));
				codeDisplayText.text = "";
				gameObject.SetActive(false);
				MachineRoomDoor.GetComponent<Animation>().Play();
				codeDisplayPanel.GetComponent<Image> ().color = new Color (255, 255, 255, 100);
			}
			else {
				codeDisplayPanel.GetComponent<Image> ().color = Color.red;
				yield return StartCoroutine (WaitForRealSeconds (2.0f));
				codeDisplayText.text = "";
				codeDisplayPanel.GetComponent<Image> ().color = new Color (255, 255, 255, 100);
			}
		}
	}

	private IEnumerator WaitForRealSeconds(float waitTime)
	{
		float endTime = Time.realtimeSinceStartup + waitTime;
		
		while (Time.realtimeSinceStartup < endTime)
		{
			yield return null;
		}
	}

}
