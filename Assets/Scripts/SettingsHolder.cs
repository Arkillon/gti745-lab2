using UnityEngine;
using System.Collections;

public class SettingsHolder : MonoBehaviour {

	public int mode = 0;
	public int diff = 1;
	public float sensibiliteAccelerometre = 1;

	void Awake() {
		DontDestroyOnLoad(this);
		
		/*if (FindObjectsOfType(GetType()).Length > 1)
		{
			Destroy(gameObject);
		}*/
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void setModeTactile(){
		mode = 0;
	}
	
	public void setModeAccelerometre() {
		mode = 1;
	}
	
	public void setDiffFacile() {
		diff = 0;
	}
	
	public void setDiffMoyen() {
		diff = 1;
	}
	
	public void setDiffDifficile() {
		diff = 2;
	}
	
	public void setSensibiliteAccelerometre(float newValue){
		sensibiliteAccelerometre = newValue;
	}
}
