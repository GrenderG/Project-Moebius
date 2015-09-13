using UnityEngine;
using System.Collections;

public class DayNight : MonoBehaviour {

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

	private float actualTime;
	private float elapsedTransitionTime;
	private Color actualColor;
	private Color color1;
	private Color color2;
	private bool isTransitionFinished = false;

	void Start() {
		if(StartingTime > DayDuration) {
			StartingTime = DayDuration;
		}

		if(IsFixedColor(actualColor)) {
			switch(GetTimeRange(StartingTime)) {
				case Constants.DAYTIME:
					RenderSettings.ambientLight = DayColor;
					break;
				case Constants.DUSKTIME:
					RenderSettings.ambientLight = DuskColor;
					break;
				case Constants.NIGHTTIME:
					RenderSettings.ambientLight = NightColor;
					break;
				case Constants.DAWNTIME:
					RenderSettings.ambientLight = DawnColor;
					break;
			}
		} else {
			color1 = actualColor;

			switch(GetTimeRange(StartingTime)) {
				case Constants.DAYTIME:
					color2 = DuskColor;
					break;
				case Constants.DUSKTIME:
					color2 = NightColor;
					break;
				case Constants.NIGHTTIME:
					color2 = DawnColor;
					break;
				case Constants.DAWNTIME:
					color2 = DayColor;
					break;
			}
		}

		actualTime = StartingTime * 60;
		elapsedTransitionTime = 0;
	}

	void Update() {
		actualTime += Time.deltaTime;
		print(actualTime);

		if(Mathf.Floor(actualTime) == DawnToDay * 60) {
			isTransitionFinished = false;
			color1 = DawnColor;
			color2 = DayColor;
		}

		if(Mathf.Floor(actualTime) == DayToDusk * 60) {
			isTransitionFinished = false;
			color1 = DayColor;
			color2 = DuskColor;
		}

		if(Mathf.Floor(actualTime) == DuskToNight * 60) {
			isTransitionFinished = false;
			color1 = DuskColor;
			color2 = NightColor;
		}

		if(Mathf.Floor(actualTime) == NightToDawn * 60 ) {
			isTransitionFinished = false;
			color1 = NightColor;
			color2 = DawnColor;
		}

		if(Mathf.Floor(actualTime) == DayDuration * 60) {
			actualTime = 0;
		}

		if (elapsedTransitionTime >= (TransitionDuration * 60)) {
			elapsedTransitionTime = 0;
			isTransitionFinished = true;
		} else if(!isTransitionFinished) {
			elapsedTransitionTime += Time.deltaTime;
			actualColor = RenderSettings.ambientLight = Color.Lerp(color1, color2, elapsedTransitionTime / (TransitionDuration * 60));
		}
	}

	public float GetActualTime() {
		return actualTime;
	}

	public float GetDayDuration() {
		return DayDuration;	
	}

	private bool IsFixedColor(Color colorToTest) {
		return colorToTest == DawnColor || colorToTest == DayColor || colorToTest == DuskColor || colorToTest == NightColor;
	}

	private string GetTimeRange(float time) {
		if(time >= DawnToDay && time < DayToDusk) {
			return Constants.DAYTIME;
		}

		if(time >= DayToDusk && time < DuskToNight) {
			return Constants.DUSKTIME;
		}

		if(time >= DuskToNight && time < NightToDawn) {
			return Constants.NIGHTTIME;
		}

		return Constants.DAWNTIME;
	}
}