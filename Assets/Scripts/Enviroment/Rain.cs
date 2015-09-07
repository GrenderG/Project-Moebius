using UnityEngine;
using System.Collections;

public class Rain : MonoBehaviour {
	[Header("Rain variables (seconds)")]
	public ParticleSystem RainParticles;
	public AudioClip RainAudio;
	public float RainDuration = 60;
	public int HowMuchTimesInADayCanOccur = 1;
	public float ProbabilityOfRain = 0.25f;
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
	
	void Start () {
	}

	void Update () {
		actualTime += Time.deltaTime;

		if(Mathf.Floor(actualTime) >= RainDuration) {
			//Stop Raining
		}
	
	}
}
