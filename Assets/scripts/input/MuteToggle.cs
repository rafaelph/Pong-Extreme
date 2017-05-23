using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour {

	private float volume;

	private Image image;

	public Sprite muteSprite;
	public Sprite soundSprite;

	private GeneralRepository repository;

	public void Awake() {
		repository = new GeneralRepository ();
		this.image = GetComponent<Image> ();
		if (isMute()) {
			setDisabledSoundSprite ();
			disableSound ();
		} else {
			setSoundEnabledSprite ();
			enableSound ();
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
		repository.enableMute ();
		AudioListener.volume = 0;
	}

	private void enableSound() {
		repository.disableMute ();
		AudioListener.volume = 1.0f;
	}

	private void setSoundEnabledSprite() {
		image.sprite = soundSprite;
	}

	private void setDisabledSoundSprite() {
		image.sprite = muteSprite;
	}

	private bool isMute() {
		return repository.getMuteStatus () == 1 ? true : false;
	}
		
}
