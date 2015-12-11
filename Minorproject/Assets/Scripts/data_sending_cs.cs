﻿using UnityEngine;
using System.Collections;

public class data_sending_cs : MonoBehaviour {
	
	public string url = "http://drproject.twi.tudelft.nl:8086";
	
	// Use this for initialization
	
	
	IEnumerator Start() {
		//PlayerPrefs.SetInt ("ID", 0); //als er nog geen is aangemaakt
		
		
		if (PlayerPrefs.GetInt ("ID") == 0) {
			//PlayerPrefs.SetInt ("ID", 0);
			WWW www = new WWW (url + "/userid" );  //+ PlayerPrefs.GetInt ("ID"));
			yield return www;
			
			if (www.isDone) {
				int user_id = int.Parse (www.text);
				PlayerPrefs.SetInt ("ID", user_id); //DEZE MOET ER UIT BIJ TESTEN!
				Debug.Log ("Player ID = " + user_id);	
			}
		} 
		
		
	}
}