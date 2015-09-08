using UnityEngine;
using System.Collections;

public class Rain : MonoBehaviour {

	private EnviromentController Enviroment;
	private float actualTime = 0;
	private AudioManager AudioManager;
	private float dayDuration;
	private DayNight daynight;
	private bool rainFinished = true;
	private bool itRained = false;

	void Start() {
		dayDuration = daynight.GetDayDuration();
	}
	
	void Update () {
		StartCoroutine(RainFunction());
	}

	IEnumerator RainFunction() {
		actualTime += Time.deltaTime;

		print(actualTime);
		print (itRained);

		/*if(itRained) {
			StopCoroutine("PlayRain");
		}*/

		if(Random.Range(0, 100) < ProbabilityOfRain) { //llueve
			if(itRained && Mathf.Floor(actualTime) >= TimeBetweenRainAndRain) {
				itRained = false;
			} else if(rainFinished && !itRained) {
				StartCoroutine("PlayRain");
				rainFinished = false;
				itRained = false;
			}
		}
		yield return new WaitForSeconds(1);
	}

	IEnumerator PlayRain() {
		while(itRained) {
			yield return new WaitForEndOfFrame();
		}

		RainParticles.Play();
		yield return new WaitForSeconds(RainDuration);
		RainParticles.Stop();
		rainFinished = true;
		actualTime = 0;
		itRained = true;
		yield return null;
	}
}
