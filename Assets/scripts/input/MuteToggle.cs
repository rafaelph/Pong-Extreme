using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour {

	private bool isMute = false;
	private float volume;

	private Image image;

	public Sprite muteSprite;
	public Sprite soundSprite;

	public void Awake() {
		this.volume = AudioListener.volume;
		this.image = GetComponent<Image> ();
	}

	public void onSoundToggleClick() {
		if (isMute) {
			enableSound ();
			setSoundEnabledSprite ();
			isMute = false;
		} else {
			setDisabledSoundSprite();
			disableSound ();
			isMute = true;
		}
	}

	private void disableSound() {
		AudioListener.volume = 0;
		isMute = true;
	}

	private void enableSound() {
		AudioListener.volume = volume;
		isMute = false;
	}

	private void setSoundEnabledSprite() {
		image.sprite = soundSprite;
	}

	private void setDisabledSoundSprite() {
		image.sprite = muteSprite;
	}
		
}
