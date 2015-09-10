using UnityEngine;
using System.Collections;

public class Rain : MonoBehaviour {

	public float DayDuration = 25;
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

	private EnviromentController Enviroment;
	private float actualTime = 0;
	private float timeWithoutRaining = 0;
	private float rainingTimer = 0;
	private AudioManager AudioManager;
	private float dayDuration;
	private float[] TimesRained;
	private bool rainFinished = true;
	private bool itRained = false;

	void Start() {
		TimesRained = new float[HowMuchTimesInADayCanOccur];
	}

	void Update() {
		if(actualTime >= RainDuration) {
			RainParticles.Stop();
			actualTime = 0;
			timeWithoutRaining = 0;
		}

		if(timeWithoutRaining >= TimeBetweenRainAndRain) {
			if(actualTime == 0) {
				RainParticles.Play();
			}
		}

		timeWithoutRaining += Time.deltaTime;
		actualTime += Time.deltaTime;
	}


	/*void Start() {
		dayDuration = daynight.GetDayDuration();
	}
	
	void Update () {
		StartCoroutine(RainFunction());
	}

	IEnumerator RainFunction() {
		actualTime += Time.deltaTime;

		print(actualTime);
		print (itRained);

		//if(itRained) {
		//	StopCoroutine("PlayRain");
		//}

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
	}*/
}
