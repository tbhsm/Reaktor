﻿using UnityEngine;
using System.Collections;

public class InventoryManager : MonoBehaviour {

	public GameObject SecurityCodeNote;
	public GameObject ScaryNote;
	public GameObject Key;
	public GameObject Crowbar;

	public GameObject SecurityCodeNoteButtonObject;
	public GameObject ScaryNoteButtonObject;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SecurityNoteButton(){
		if (SecurityCodeNote.activeSelf) {
			SecurityCodeNote.SetActive (false);
		} else {
			SecurityCodeNote.SetActive (true);
		}
	}

	public void ScaryNoteButton(){
		if (ScaryNote.activeSelf) {
			ScaryNote.SetActive (false);
		} else {
			ScaryNote.SetActive (true);
		}
	}
}
