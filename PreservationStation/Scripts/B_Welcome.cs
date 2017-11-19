using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(Collider))]

public class B_Welcome : MonoBehaviour {

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
	// 20171114.0134 -->

	public void LoadSecondScene()
	{
		print ("LoadSecondScene()");
		//Use a coroutine to load the Scene in the background
		StartCoroutine(LoadSecondSceneAsync());

	}

	IEnumerator LoadSecondSceneAsync()
	{
		// The Application loads the Scene in the background at the same time as the current Scene.
		// This is particularly good for creating loading screens. You could also load the scene by build //number.
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

		//Wait until the last operation fully loads to return anything
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
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

		//Wait until the last operation fully loads to return anything
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}

	public void LoadEndScene()
	{
		//Use a coroutine to load the Scene in the background
		StartCoroutine(LoadEndSceneAsync());
	}

	IEnumerator LoadEndSceneAsync()
	{
		// The Application loads the Scene in the background at the same time as the current Scene.
		//This is particularly good for creating loading screens. You could also load the scene by build //number.
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(3);

		//Wait until the last operation fully loads to return anything
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}




	// night before...?
	/*
	public void LoadSecondScene()
	{
		//Use a coroutine to load the Scene in the background
		StartCoroutine(LoadSecondSceneAsync());
	}

	IEnumerator LoadSecondSceneAsync()
	{
		// The Application loads the Scene in the background at the same time as the current Scene.
		// This is particularly good for creating loading screens. You could also load the scene by build //number.
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);

		//Wait until the last operation fully loads to return anything
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
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
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);

		//Wait until the last operation fully loads to return anything
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}

	public void LoadEndScene()
	{
		//Use a coroutine to load the Scene in the background
		StartCoroutine(LoadEndSceneAsync());
	}

	IEnumerator LoadEndSceneAsync()
	{
		// The Application loads the Scene in the background at the same time as the current Scene.
		//This is particularly good for creating loading screens. You could also load the scene by build //number.
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);

		//Wait until the last operation fully loads to return anything
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}

*/
	/*
	public void SetGazedAt(bool gazedAt) {
		GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
	}


	#region IGvrGazeResponder implementation

	/// Called when the user is looking on a GameObject with this script,
	/// as long as it is set to an appropriate layer (see GvrGaze).
	public void OnGazeEnter() {
		SetGazedAt(true);
	}

	/// Called when the user stops looking on the GameObject, after OnGazeEnter
	/// was already called.
	public void OnGazeExit() {
		SetGazedAt(false);
	}

	/// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
	public void OnGazeTrigger() {
		// #nextAction: make this box a big START button and then do other stuff right in here too, like build the planes!
		//RenderSettings.skybox=mat2;		
		TeleportRandomly();
	}

	#endregion
	*/

}