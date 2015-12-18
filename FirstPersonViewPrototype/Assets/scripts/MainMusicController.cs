﻿using UnityEngine;
using System.Collections;

public class MainMusicController : MonoBehaviour {

	public GameObject[] audioTracks;
	private float fadeTime = 2;
	private float maxVolumeAlarm;
	private float maxVolumeMachine;
	private float maxVolumeOffice;
	private float maxVolumeLab;
	private float maxVolumeReaktor;
	private float maxVolumeStorage;
	private float maxVolumeArchive;


	private int toFadeOut;

	// Use this for initialization
	void Start () {
		audioTracks = new GameObject[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			audioTracks[i] = transform.GetChild(i).gameObject;
			if (!(audioTracks[i].name == "Alarm")){
				audioTracks[i].gameObject.SetActive (false);
			}
		}

		maxVolumeAlarm = GameObject.Find ("MainMusicController").transform.FindChild("Alarm").GetComponent<AudioSource>().volume;
		maxVolumeMachine = GameObject.Find ("MainMusicController").transform.FindChild("MachineRoom").GetComponent<AudioSource>().volume;
		maxVolumeOffice = GameObject.Find ("MainMusicController").transform.FindChild("Office").GetComponent<AudioSource>().volume;
		maxVolumeLab = GameObject.Find ("MainMusicController").transform.FindChild("Laboratory").GetComponent<AudioSource>().volume;
		maxVolumeReaktor = GameObject.Find ("MainMusicController").transform.FindChild("Reaktor").GetComponent<AudioSource>().volume;
		maxVolumeStorage = GameObject.Find ("MainMusicController").transform.FindChild("Storage").GetComponent<AudioSource>().volume;
		maxVolumeArchive = GameObject.Find ("MainMusicController").transform.FindChild("Archive").GetComponent<AudioSource>().volume;
	}
	
	// Update is called once per frame
	void Update () {
		if (!(audioTracks[0].GetComponent<AudioSource>().isPlaying) && audioTracks[0].gameObject.activeSelf && Time.timeScale == 1) {
			FadeIn("Office");
		}
	}

	public void FadeIn(string track){
		for (int i = 1; i < transform.childCount; i++) {
			if (audioTracks[i].name == track){
				audioTracks[i].gameObject.SetActive(true);
				float maxVolume = getVolumeOf(track);
				StartCoroutine(FadeMusic (audioTracks[i].GetComponent<AudioSource>(), maxVolume, fadeTime));
			} else {
				if (audioTracks[i].gameObject.activeSelf == true){
					toFadeOut = i;
				}
				StartCoroutine(FadeMusic (audioTracks[i].GetComponent<AudioSource>(), 0, fadeTime));
			}
		}
	}

	private float getVolumeOf(string track){
		if (track == "Alarm") {
			return maxVolumeAlarm;
		} else if (track == "Office") {
			return maxVolumeOffice;
		} else if (track == "MachineRoom") {
			return maxVolumeMachine;
		} else if (track == "Lab") {
			return maxVolumeLab;
		} else if (track == "Storage") {
			return maxVolumeStorage;
		} else if (track == "Reaktor") {
			return maxVolumeReaktor;
		} else if (track == "Archive") {
			return maxVolumeArchive;
		} else {
			return 1.0f;
		}
	}

private IEnumerator FadeMusic(AudioSource audio, float targetVolume, float duration)
	{
		float startVolume = audio.volume;
		float inverseDuration = 1.0f / duration;
		float lerpFactor = 0.0f;
		while (lerpFactor <= 1.0f) {
			audio.volume = Mathf.Lerp(startVolume, targetVolume, lerpFactor);
			lerpFactor = lerpFactor + Time.deltaTime * inverseDuration;
			yield return null;
		}
		audio.volume = targetVolume;
		audioTracks [toFadeOut].SetActive (false);
	}

}
