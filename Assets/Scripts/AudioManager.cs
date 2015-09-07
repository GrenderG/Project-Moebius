using UnityEngine;
using System.Collections;

public class AudioManager {

	public void PlaySoundOnCamera(string AudioName, AudioClip Clip) {

		AudioClip Sound;
		if(Clip != null) {
			Sound = Clip;
		}
		else {
			Sound = Resources.Load<AudioClip>("Audio/" + AudioName);
		}

		GameObject MainCamera = GameObject.FindWithTag("MainCamera");
		GameObject SoundObject = new GameObject("Audio" + Sound.name);

		SoundObject.transform.position = MainCamera.transform.position;
		SoundObject.transform.parent = MainCamera.transform;

		AudioSource Source = SoundObject.AddComponent<AudioSource>();

		Source.GetComponent<AudioSource>().clip = Sound;
		Source.GetComponent<AudioSource>().Play();
		UnityEngine.Object.Destroy(SoundObject, Sound.length);
	}
}
