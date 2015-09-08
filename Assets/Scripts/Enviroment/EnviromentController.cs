using UnityEngine;
using System.Collections;

public class EnviromentController : MonoBehaviour {
	[System.Serializable]
	public class daynight {
		[Header("Time Colors")]
		public Color DawnColor;
		public Color DayColor;
		public Color DuskColor;
		public Color NightColor;
		
		[Header("Day Variables (minutes)")]
		public float DayDuration = 24;
		public float StartingTime = 0;
		public float DawnToDay = 7;
		public float DayToDusk = 19;
		public float DuskToNight = 21;
		public float NightToDawn = 5;
		public float TransitionDuration = 1;
	}

	[System.Serializable]
	public class rain {
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
	}

	public daynight DayNightProperties;
	public rain RainProperties;
}
