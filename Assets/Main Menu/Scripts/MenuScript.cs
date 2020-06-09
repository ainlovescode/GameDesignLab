using UnityEngine;
using UnityEngine.UI;
using System.Collections;


// Hi! This script presents the overlay info for our tutorial content, linking you back to the relevant page.
public class MenuScript : MonoBehaviour 
{


	// store the GameObject which renders the overlay info
	public GameObject overlay;
	// store a reference to the audio listener in the scene, allowing for muting of the scene during the overlay
	public AudioListener mainListener;
	public AudioSource mainSound;


	void Awake()
	{
			ShowLaunchScreen();
	}

	// show overlay info, pausing game time, disabling the audio listener 
	// and enabling the overlay info parent game object
	public void ShowLaunchScreen()
	{
		Time.timeScale = 0f;
		mainListener.enabled = false;
		overlay.SetActive (true);
	}

	// continue to play, by ensuring the preference is set correctly, the overlay is not active, 
	// and that the audio listener is enabled, and time scale is 1 (normal)
	public void StartGame()
	{		
		overlay.SetActive (false);
		mainListener.enabled = true;
		mainSound.Play();
		Time.timeScale = 1f;
	}

}
