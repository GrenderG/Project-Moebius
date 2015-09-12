using UnityEngine;
using System.Collections;

public class Rain : MonoBehaviour {
	
	public float DayDuration = 25;
	
	[Header("Rain variables (seconds)")]
	public ParticleSystem RainDropParticles;
	public ParticleSystem RainCollisionParticles;
	[Range(120, 1440)]public float RainDuration = 240;
	public int HowMuchTimesInADayCanOccur = 1;
	[Range(0, 100)]public int ProbabilityOfRain = 0;
	public float TimeBetweenRainAndRain = 0;
	
	[Header("Thunder variables (seconds)")]
	public bool Thunders = false;
	[Range(0, 100)]public int ProbabilityOfThundersInARain = 0;
	
	[Header("Ambient variables")]
	[Range(0, 1)]public float AmbientIntensity = 0.7f;
	
	private float dayTime = 0;
	private float rainTime = 0;
	private float timeWithoutRain = 0;
	private int lastMinute = 0;
	private int timesRained = 0;
	private bool isRaining = false;
	private float elapsedTransitionTime;
	private bool isTransitionFinished = false;
	private Color THUNDER_COLOR = new Color32(206, 222, 235, 0);
	private AudioManager audioManager = new AudioManager();
	private float AmbientIntensityBeforeRain;
	private bool itRained = false;
	
	void Start() {
		timeWithoutRain = TimeBetweenRainAndRain;
		RainDropParticles.enableEmission = false;
		RainCollisionParticles.enableEmission = false;
		RainDropParticles.Play();
		RainCollisionParticles.Play();
		AmbientIntensityBeforeRain = RenderSettings.ambientIntensity;
	}
	
	void Update() {
		if(lastMinute != (int)dayTime) {
			lastMinute = (int)dayTime;
			
			if(timesRained < HowMuchTimesInADayCanOccur 
			   && Random.Range(0,100) < ProbabilityOfRain 
			   && !isRaining 
			   && Mathf.Floor(timeWithoutRain) >= TimeBetweenRainAndRain) {

				StartCoroutine("RainSound");
				RainDropParticles.enableEmission = true;
				RainCollisionParticles.enableEmission = true;
				isRaining = true;
				itRained = true;
				isTransitionFinished = false;
				timesRained ++;
			}

			if (Thunders && isRaining) {
				if (Random.Range(0, 100) < ProbabilityOfThundersInARain){
					StartCoroutine("ThunderStrike");
				}
			}

		}
		
		if(isRaining) {
			rainTime += Time.deltaTime;

			if (elapsedTransitionTime >= 5) {
				elapsedTransitionTime = 0;
				isTransitionFinished = true;
			} else if(!isTransitionFinished) {
				elapsedTransitionTime += Time.deltaTime;
				RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, AmbientIntensity, elapsedTransitionTime / 10);
			}

			if(Mathf.Floor(rainTime) >= RainDuration - 7) { // OJO!
				rainTime = 0;
				RainDropParticles.enableEmission = false;
				RainCollisionParticles.enableEmission = false;
				timeWithoutRain = 0;
				isRaining = false;
				isTransitionFinished = false;
			}
		} else {
			timeWithoutRain += Time.deltaTime;

			if (RenderSettings.ambientIntensity < AmbientIntensityBeforeRain){
				print (RenderSettings.ambientIntensity);
				if (elapsedTransitionTime >= 10) {
					elapsedTransitionTime = 0;
					isTransitionFinished = true;
				} else if(!isTransitionFinished) {
					elapsedTransitionTime += Time.deltaTime;
					RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, AmbientIntensityBeforeRain, elapsedTransitionTime / 10);
				}
			}
		}
		
		if(Mathf.Floor (dayTime) >= DayDuration * 60) {
			dayTime = 0;
			timesRained = 0;
		}
		
		dayTime += Time.deltaTime;
	}

	IEnumerator ThunderStrike() {
		Color ambientLightBeforeThunder = RenderSettings.ambientLight;
		int random = Random.Range(1, 3);

		RenderSettings.ambientIntensity = 0.8f;
		RenderSettings.ambientLight = THUNDER_COLOR;

		yield return new WaitForSeconds(0.1f);

		audioManager.PlaySoundOnCamera("Thunder" + random, null, "Sounds/Weather/", false);
		RenderSettings.ambientIntensity = AmbientIntensity;
		RenderSettings.ambientLight = ambientLightBeforeThunder;

		yield return new WaitForSeconds(0.05f);

		RenderSettings.ambientIntensity = 1f;
		RenderSettings.ambientLight = THUNDER_COLOR;

		yield return new WaitForSeconds(0.08f);
		
		RenderSettings.ambientIntensity = AmbientIntensity;
		RenderSettings.ambientLight = ambientLightBeforeThunder;
	}

	IEnumerator RainSound() {
		audioManager.PlaySoundOnCamera("RainStart", null, "Sounds/Weather/", false);
		yield return new WaitForSeconds(59);

		if(RainDuration > 120) {
			audioManager.PlaySoundOnCamera("RainLoop", null, "Sounds/Weather/", true);
			yield return new WaitForSeconds(RainDuration - 59);			
			Destroy(GameObject.Find("AudioRainLoop"));
		}

		audioManager.PlaySoundOnCamera("RainEnd", null, "Sounds/Weather/", false);
	}
}