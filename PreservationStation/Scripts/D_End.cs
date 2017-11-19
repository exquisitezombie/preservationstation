using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Collider))]

public class D_End : MonoBehaviour {

	public GameObject GoogleVR;

	void Awake() {
		//DontDestroyOnLoad (GoogleVR);
	}
	 
	void Update() {
		// Click anywhere
		/*if (Input.GetMouseButtonDown(0)) {
			SwitchSpheres();
		}*/

	}

	// Use this for initialization
	void Start () {

	}

	//* SCENE SWITCHING

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

		//Wait until the last operation fully loads to return anything
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}

}