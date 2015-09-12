using UnityEngine;
using System.Collections;

public class AudioManager {

	public void PlaySoundOnCamera(string AudioName, AudioClip Clip, string Path, bool Looping) {

		AudioClip Sound;
		if(Clip != null) {
			Sound = Clip;
		}
		else {
			Sound = Resources.Load<AudioClip>(Path + AudioName);
		}

		GameObject MainCamera = GameObject.FindWithTag("MainCamera");
		GameObject SoundObject = new GameObject("Audio" + Sound.name);

		SoundObject.transform.position = MainCamera.transform.position;
		SoundObject.transform.parent = MainCamera.transform;

		AudioSource Source = SoundObject.AddComponent<AudioSource>();

		Source.GetComponent<AudioSource>().clip = Sound;
		Source.GetComponent<AudioSource>().Play();
		if(Looping) 
			Source.GetComponent<AudioSource>().loop  = true;
		else
			UnityEngine.Object.Destroy(SoundObject, Sound.length);
	}
}
