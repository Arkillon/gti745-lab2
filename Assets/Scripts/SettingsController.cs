using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {
	public Button tactileButton;
	public Button accelerometreButton;
	public Button facileButton;
	public Button moyenButton;
	public Button difficileButton;
	public Text accelerometreSliderText;
	public Slider accelerometreSlider;
	private SettingsHolder settingsHolder;

	// Use this for initialization
	void Start () {
		GameObject settingsHolderGameObj = GameObject.Find("SettingsHolder");
		if (settingsHolderGameObj != null)
		{
			settingsHolder = settingsHolderGameObj.GetComponent<SettingsHolder>();
		}

		if(settingsHolder.mode == 0){
			setModeTactile();
		} 
		else if(settingsHolder.mode == 1) {
			setModeAccelerometre();
		}

		if (settingsHolder.diff == 0){
			setDiffFacile();
		}
		else if(settingsHolder.diff == 1){
			setDiffMoyen();
		}
		else if(settingsHolder.diff == 2){
			setDiffDifficile();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setModeTactile(){
		tactileButton.interactable = false;
		accelerometreButton.interactable = true;

		settingsHolder.setModeTactile ();
	}

	public void setModeAccelerometre() {
		tactileButton.interactable = true;
		accelerometreButton.interactable = false;

		settingsHolder.setModeAccelerometre ();
	}

	public void setDiffFacile() {
		facileButton.interactable = false;
		moyenButton.interactable = true;
		difficileButton.interactable = true;

		settingsHolder.setDiffFacile ();
	}

	public void setDiffMoyen() {
		facileButton.interactable = true;
		moyenButton.interactable = false;
		difficileButton.interactable = true;

		settingsHolder.setDiffMoyen ();
	}

	public void setDiffDifficile() {
		facileButton.interactable = true;
		moyenButton.interactable = true;
		difficileButton.interactable = false;

		settingsHolder.setDiffDifficile ();
	}

	public void setSensibiliteAccelerometre(){
		settingsHolder.setSensibiliteAccelerometre (accelerometreSlider.value);
	}
}
