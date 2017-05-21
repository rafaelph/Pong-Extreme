using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour {

	private float volume;

	private Image image;

	public Sprite muteSprite;
	public Sprite soundSprite;

	public void Awake() {
		this.image = GetComponent<Image> ();
		if (isMute()) {
			setDisabledSoundSprite ();
		} else {
			setSoundEnabledSprite ();
		}
	}

	public void onSoundToggleClick() {
		if (isMute()) {
			enableSound ();
			setSoundEnabledSprite ();
		} else {
			setDisabledSoundSprite();
			disableSound ();
		}
	}

	private void disableSound() {
		AudioListener.volume = 0;
	}

	private void enableSound() {
		AudioListener.volume = 1.0f;
	}

	private void setSoundEnabledSprite() {
		image.sprite = soundSprite;
	}

	private void setDisabledSoundSprite() {
		image.sprite = muteSprite;
	}

	private bool isMute() {
		return AudioListener.volume <= 0.0f;
	}
		
}
