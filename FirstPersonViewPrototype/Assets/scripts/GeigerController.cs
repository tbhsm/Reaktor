using UnityEngine;
using System.Collections;

public class GeigerController : MonoBehaviour {
	
	private float playerDistance;

	private AudioSource GeigerAudioSource;
	public AudioClip GeigerLevel1;
	public AudioClip GeigerLevel2;
	public AudioClip GeigerLevel3;
	public AudioClip GeigerLevel4;

	private int audiolevel = 0;
	private bool canPlayAudio = true;
	public float GeigerParameter;

	void Start () {

		GeigerAudioSource = GetComponent<AudioSource> ();
		GeigerAudioSource.clip = GeigerLevel1;
		GeigerAudioSource.loop = true;
		GeigerAudioSource.Play();
	}

	void Update () {

		float radiodistance = DistanceToClosestRadioactive ();
		audiolevel = ChooseAudioClip (radiodistance, audiolevel);
	}

	float DistanceToClosestRadioactive(){
		GameObject[] radioactives;
		radioactives =  GameObject.FindGameObjectsWithTag("radioactive");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject radioactive in radioactives) {
			float curdistance = Vector3.Distance(radioactive.transform.position,transform.position);
			if (curdistance<distance){
				distance = curdistance;
			}
		}
		return distance;
	}
	
 	int ChooseAudioClip(float radiodistance, int previousaudiolevel){
		if (radiodistance < 20 && radiodistance > 12) {
			audiolevel = 2;
			if (audiolevel != previousaudiolevel){
			GeigerAudioSource.clip = GeigerLevel2;
			GeigerAudioSource.Play();
			}
				return audiolevel;
		}
		if (radiodistance < 12 && radiodistance > 8) {
			audiolevel = 3;
			if (audiolevel != previousaudiolevel){
				GeigerAudioSource.clip = GeigerLevel3;
				GeigerAudioSource.Play();
			}
				return audiolevel;
		}
		if (radiodistance < 8) {
			audiolevel = 4;
			if (audiolevel != previousaudiolevel){
				GeigerAudioSource.clip = GeigerLevel4;
				GeigerAudioSource.Play();
			}
				return audiolevel;
		}
		audiolevel = 1;
		if (audiolevel != previousaudiolevel){
			GeigerAudioSource.clip = GeigerLevel1;
			GeigerAudioSource.Play();
		}
		return audiolevel;

	}
}
