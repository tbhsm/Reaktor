﻿/// <summary>
/// Start animation synchronous to audio
/// </summary>

using UnityEngine;
using System.Collections;

public class SyncMusicWithAnimation : MonoBehaviour {

	private Animator animator;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("animating")){
			animator.SetBool ("startedAudio", false);
		}

		animator.SetBool ("playingAudio", audio.isPlaying);

		if (!audio.isPlaying) {
			audio.Play();
			animator.SetBool ("startedAudio", true);
		}
	}
}
