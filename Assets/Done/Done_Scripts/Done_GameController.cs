using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Done_GameController : MonoBehaviour
{
	private SettingsHolder settingsHolder;

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public Text scoreText;
	//  public Text restartText;
	public Text gameOverText;
	public GameObject restartButton;
	public GameObject menuButton;
	
	private bool gameOver;
	//  private bool restart;
	private int score;

	private int weapon2Charge = 0;
	public Scrollbar weapon2ScrollBar;
	public GameObject weapon2Button;
	
	void Start ()
	{
		GameObject settingsHolderGameObj = GameObject.Find("SettingsHolder");
		if (settingsHolderGameObj != null)
		{
			settingsHolder = settingsHolderGameObj.GetComponent<SettingsHolder>();
		}

		if(settingsHolder.diff == 2){
			spawnWait = (float)(spawnWait / 1.5);
			hazardCount = (int)(hazardCount * 1.5);
		}

		gameOver = false;
		//      restart = false;
		//      restartText.text = "";
		gameOverText.text = "";
		restartButton.SetActive (false);
		menuButton.SetActive (false);
		weapon2Button.SetActive (false);
		score = 0;
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
		InvokeRepeating("ChargeWeapon2", 2.0f, 0.5f);
	}
	
	//  void Update ()
	//  {
	//      if (restart)
	//      {
	//          if (Input.GetKeyDown (KeyCode.R))
	//          {
	//              Application.LoadLevel (Application.loadedLevel);
	//          }
	//      }
	//  }
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard;
				if(settingsHolder.diff == 0){
					hazard = hazards [Random.Range (0, hazards.Length-1)];
				}
				else{
					hazard = hazards [Random.Range (0, hazards.Length)];
				}
					
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartButton.SetActive (true);
				menuButton.SetActive (true);
				//              restartText.text = "Press 'R' for Restart";
				//              restart = true;
				break;
			}
		}
	}
	void ChargeWeapon2 ()
	{
		
		if (!gameOver){
			weapon2Charge = weapon2Charge + 5;
			if(weapon2Charge>100){
				weapon2Charge = 100;
			}
			weapon2ScrollBar.size = (float)weapon2Charge/100;
			if(weapon2Charge == 100){
				weapon2Button.SetActive(true);
			}
			else {
				weapon2Button.SetActive(false);
			}
		}
		else {
			weapon2Button.SetActive(false);
		}
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();

		weapon2Charge = weapon2Charge + 10;
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}
	
	public void RestartGame () {
		Application.LoadLevel (Application.loadedLevel);
	}

	public void Weapon2Shot () {
		weapon2Charge = 0;
		weapon2ScrollBar.size = (weapon2Charge);

		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

		foreach(GameObject item in enemies)
		{
			Destroy(item);
		}
	}
}