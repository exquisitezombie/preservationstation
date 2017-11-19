using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class A_StartPreserving : MonoBehaviour {

	public GameObject GoogleVR;
	public GameObject EventSystem;

	void Awake () {
		//DontDestroyOnLoad (GoogleVR);
		//DontDestroyOnLoad (EventSystem);
	}

	// Use this for initialization
	void Start () {
		Scene scene = SceneManager.GetActiveScene();
		print ("Active Scene: " + scene);
		if (scene.name == "0_Start") {
			print ("restarting app...");
			RestartApp ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartApp()
	{
		//Use a coroutine to load the Scene in the background
		StartCoroutine(LoadWelcomeSceneAsync());
	}

	IEnumerator LoadWelcomeSceneAsync()
	{
		// The Application loads the Scene in the background at the same time as the current Scene.
		//This is particularly good for creating loading screens. You could also load the scene by build //number.
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
		print ("LoadWelcomeSceneAsync()");

		//Wait until the last operation fully loads to return anything
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}






}
