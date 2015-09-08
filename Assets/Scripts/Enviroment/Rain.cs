using UnityEngine;
using System.Collections;

public class Rain : MonoBehaviour {
	[Header("Rain variables (seconds)")]
	public ParticleSystem RainParticles;
	public AudioClip RainAudio;
	public float RainDuration = 60;
	public int HowMuchTimesInADayCanOccur = 1;
	[Range(0, 100)]public int ProbabilityOfRain = 0;
	public float TimeBetweenRainAndRain = 0;
	[Header("Thunder variables (seconds)")]
	public bool Thunders = false;
	public AudioClip ThundersAudio;
	public float ProbabilityOfThundersInARain = 0.25f;
	public float TimeBetweenThunderAndThunder = 0;
	[Header("Ambient variables")]
	[Range(0, 1)]public float AmbientIntensity = 0.7f;

	private float actualTime = 0;
	private AudioManager AudioManager;
	private bool rainFinished = true;
	private bool itRained = false;
	
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
