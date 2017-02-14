using UnityEngine;
using System.Collections;

public class NavigationController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void StartGame () {
		Application.LoadLevel("MainGame");
	}
	
	public void GoToMainMenu () {
		Application.LoadLevel("MainMenu");
	}

	public void GoToSettings () {
		Application.LoadLevel("SettingsMenu");
	}
}
