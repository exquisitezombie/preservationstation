using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class C_SVT : MonoBehaviour {

	public Material frontPlane;
	public Material mediaMat;
	public Material mediaCheckMat;

	public GameObject vidSphere;
	//public GameObject videoPlayer;

	public Material mat1;
	public Material mat2;
	public Material mat3;
	/*
	public Material mat4;
	public Material mat5;
	public Material mat6;
	public Material mat7;
	public Material mat8;
	public Material mat9;
	public Material mat10;
	*/

	private Button art_button01;
	private Button art_button02;
	private Button art_button03;
	public Button restart_button;
	public Button lastRoom_button;

	public AudioSource music01;
	public AudioSource narration01;
	public AudioSource narration02;
	public AudioSource narration03;
	public AudioSource narration04;
	public AudioSource narration05;

	public AudioSource audio_artifact01;

	public GameObject GoogleVR;

	private Vector3 startingPosition;

	private GameObject art_plane01;
	private GameObject art_plane02;
	private GameObject art_plane03;

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

		RenderSettings.skybox=mat1;

		vidSphere.GetComponent<Renderer>().enabled = false;
		lastRoom_button.interactable = false;

		music01.Play ();
		narration01.Play ();

		art_plane01 = GameObject.CreatePrimitive(PrimitiveType.Plane);
		art_plane02 = GameObject.CreatePrimitive(PrimitiveType.Plane);
		art_plane03 = GameObject.CreatePrimitive(PrimitiveType.Plane);


		art_plane01.transform.Rotate(-91.5f,99.7f,90f);
		art_plane01.transform.Rotate(0,180,0);
		art_plane01.transform.localPosition = new Vector3 (-3.95f, 3.66f, -24.2f);
		//plane.transform.localScale = new Vector3 (.15F, .1F, .1F);
		art_plane01.GetComponent<Renderer>().material = mediaMat;
		art_plane01.AddComponent<Button> ();
		art_button01 = art_plane01.GetComponent<Button>(); 
		art_button01.onClick.AddListener(delegate() { PlayArt(art_plane01); });


		art_plane02.transform.Rotate(-90,0,0);
		art_plane02.transform.Rotate(0,180,0);
		art_plane02.transform.localPosition = new Vector3 (0, 0, 20);
		art_plane02.GetComponent<Renderer>().material = mediaMat;
		art_plane02.AddComponent<Button> ();
		art_button02 = art_plane02.GetComponent<Button>(); 
		art_button02.onClick.AddListener(delegate() { PlayArt02(art_plane02); });
		art_plane02.GetComponent<Renderer>().enabled = false;
		art_button02.GetComponent<Renderer>().enabled = false;
		art_button02.GetComponent<Collider>().enabled = false;
		//art_button02.interactable = false;
	

		art_plane03.transform.Rotate(-91.5f,99.7f,90f);
		art_plane03.transform.Rotate(0,180,0);
		art_plane03.transform.localPosition = new Vector3 (6.2f, 24.1f, -25.61f);//5.8f, 9, -26.42f);
		art_plane03.GetComponent<Renderer>().material = mediaMat;
		art_plane03.AddComponent<Button> ();
		art_button03 = art_plane03.GetComponent<Button>(); 
		art_button03.onClick.AddListener(delegate() { PlayArt03(art_plane03); });
		art_plane03.GetComponent<Renderer>().enabled = false;
		art_button03.GetComponent<Renderer>().enabled = false;
		art_button03.GetComponent<Collider>().enabled = false;
		//art_button03.interactable = false;



	}

	public void NextRoom()
	{

		if (RenderSettings.skybox == mat1) {
			RenderSettings.skybox = mat2;
			lastRoom_button.interactable = true;
			audio_artifact01.Stop ();
			narration01.Stop ();
			music01.Stop ();
			narration02.Play ();
			art_plane01.GetComponent<Renderer>().enabled = false;
			art_button01.GetComponent<Renderer>().enabled = false;
			art_button01.GetComponent<Collider>().enabled = false;
			//art_button01.interactable = false;
			art_plane02.GetComponent<Renderer>().enabled = true;
			art_button02.GetComponent<Renderer>().enabled = true;
			art_button02.GetComponent<Collider>().enabled = true;
			art_button02.interactable = true;

		} else if (RenderSettings.skybox == mat2) {
			RenderSettings.skybox = mat3;
			narration02.Stop ();
			narration03.Stop ();
			narration04.Play ();
			vidSphere.GetComponent<Renderer>().enabled = false;
			art_plane02.GetComponent<Renderer>().enabled = false;
			art_button02.GetComponent<Renderer>().enabled = false;
			art_button02.GetComponent<Collider>().enabled = false;
			//art_button02.interactable = false;
			art_plane03.GetComponent<Renderer>().enabled = true;
			art_button03.GetComponent<Renderer>().enabled = true;
			art_button03.GetComponent<Collider>().enabled = true;
			//art_button03.interactable = true;

		} else if (RenderSettings.skybox == mat3) {
			art_plane03.GetComponent<Renderer>().enabled = false;
			art_button03.GetComponent<Renderer>().enabled = false;
			art_button03.GetComponent<Collider>().enabled = false;
			art_button03.interactable = false;
			narration04.Stop ();

			LoadEndScene ();

		};

		/*
		RenderSettings.skybox = mat4; }
		else if (RenderSettings.skybox == mat4) { RenderSettings.skybox = mat5; }
		else if (RenderSettings.skybox == mat5) { RenderSettings.skybox = mat6; }
		else if (RenderSettings.skybox == mat6) { RenderSettings.skybox = mat7; }
		else if (RenderSettings.skybox == mat7) { RenderSettings.skybox = mat8; }
		else if (RenderSettings.skybox == mat8) { RenderSettings.skybox = mat9; }
		else if (RenderSettings.skybox == mat9) { LoadEndScene(); };
		*/

	}

	public void LastRoom()
	{

		if (RenderSettings.skybox == mat1) {
			RenderSettings.skybox = mat3;
			narration01.Stop ();
			narration04.Play ();
			music01.Stop ();
			vidSphere.GetComponent<Renderer>().enabled = false;
			art_plane01.GetComponent<Renderer>().enabled = false;
			art_button01.GetComponent<Renderer>().enabled = false;
			art_button01.GetComponent<Collider>().enabled = false;
			//art_button01.interactable = false;
			art_plane03.GetComponent<Renderer>().enabled = true;
			art_button03.GetComponent<Renderer>().enabled = true;
			art_button03.GetComponent<Collider>().enabled = true;
			//art_button03.interactable = true;

		} else if (RenderSettings.skybox == mat2) {
			RenderSettings.skybox = mat1;
			narration02.Stop ();
			narration01.Play ();
			music01.Play ();
			art_plane01.GetComponent<Renderer>().enabled = true;
			art_button01.GetComponent<Renderer>().enabled = true;
			art_button01.GetComponent<Collider>().enabled = true;
			art_plane02.GetComponent<Renderer>().enabled = false;
			art_button02.GetComponent<Renderer>().enabled = false;
			art_button02.GetComponent<Collider>().enabled = false;
			//art_button02.interactable = false;

		} else if (RenderSettings.skybox == mat3) {
			RenderSettings.skybox = mat2;
			narration03.Stop ();
			narration02.Play ();
			art_plane03.GetComponent<Renderer>().enabled = false;
			art_button03.GetComponent<Renderer>().enabled = false;
			art_button03.GetComponent<Collider>().enabled = false;
			//art_button03.interactable = false;
			art_plane02.GetComponent<Renderer>().enabled = true;
			art_button02.GetComponent<Renderer>().enabled = true;
			art_button02.GetComponent<Collider>().enabled = true;
			//art_button02.interactable = true;
		};

		/*
		else if (RenderSettings.skybox == mat4) { RenderSettings.skybox = mat3; }
		else if (RenderSettings.skybox == mat5) { RenderSettings.skybox = mat4; }
		else if (RenderSettings.skybox == mat6) { RenderSettings.skybox = mat5; }
		else if (RenderSettings.skybox == mat7) { RenderSettings.skybox = mat6; }
		else if (RenderSettings.skybox == mat8) { RenderSettings.skybox = mat7; }
		else if (RenderSettings.skybox == mat9) { RenderSettings.skybox = mat8; };
		*/

	}



	public void PlayArt(GameObject obj) {
		print ("PlaySoundArt");

		obj.GetComponent<Renderer>().material = mediaCheckMat;
		narration01.Stop ();
		music01.Pause ();
		audio_artifact01.Play ();

		//if (RenderSettings.skybox==mat3) { RenderSettings.skybox = mat2; } else {RenderSettings.skybox=mat3; };
		/*
		Vector3 direction = Random.onUnitSphere;
		direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
		float d	istance = 2 * Random.value + 1.5f;
		obj.transform.localPosition = direction * distance;
		*/
	}

	public void PlayArt02(GameObject obj) {
		print ("Play360");

		obj.GetComponent<Renderer>().material = mediaCheckMat;

		//narration01.Pause ();
		//audio_artifact01.Play ();

		narration02.Stop ();

		// SHOW / HIDE
		if (vidSphere.GetComponent<Renderer>().enabled) {
			vidSphere.GetComponent<Renderer>().enabled = false;
			narration03.Stop ();
		}else {
			vidSphere.GetComponent<Renderer>().enabled = true;
			narration03.Play ();
		}

	}

	public void PlayArt03(GameObject obj) {
		print ("PlayVidya?");
		obj.GetComponent<Renderer>().material = mediaCheckMat;
		narration04.Stop ();
		narration05.Play ();
	}





	//* SCENE SWITCHING

	// 20171114.0134 -->


	public void LoadSecondScene()
	{
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

1111*/





	public void LoadWebURL(string textURL)
	{
		Application.OpenURL(textURL);
	}




	public void TeleportRandomly() {
		Vector3 direction = Random.onUnitSphere;
		direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
		float distance = 2 * Random.value + 1.5f;
		transform.localPosition = direction * distance;
	}






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
		RenderSettings.skybox=mat2;		
		TeleportRandomly();
	}

	#endregion

}



// extra stuff...

/*
	private IEnumerator DownloadAndPlay(string url)
	{
		WWW www = new WWW(url);
		yield return www;
		if(string.IsNullOrEmpty(www.error) == false)
		{
			Debug.Log("Did not work"); 
			yield break;
		}
		source = GetComponent<AudioSource>();
		source.clip = www.GetAudioClip(false,true);
	}*/




//() => {TestScript();} );
//plane.GetComponent<Button>().onClick.AddListener(()=>TestScript());
//startingPosition = transform.localPosition;
//SetGazedAt(false);


//StartCoroutine(DownloadAndPlay("http://ferstenfeld.com/data/prj/preservation/chopin.ogg"));  

/*
		 * GameObject camera = GameObject.Find("Main Camera");
		var videoPlayer = camera.AddComponent<UnityEngine.Video.VideoPlayer>();*/

//videoPlayer = vidSphere.GetComponent<VideoPlayer> ();
//vidSphere.GetComponent<VideoPlayer>
//vidSphere.VideoPlayer.Pause ();

//GameObject title = GameObject.CreatePrimitive(PrimitiveType.Plane);
//GameObject moveScene = GameObject.CreatePrimitive(PrimitiveType.Plane);
/*
		moveScene.transform.Rotate(-90,0,0);
		moveScene.transform.Rotate(0,180,-90);
		moveScene.transform.localPosition = new Vector3(20,0,-10);
		moveScene.GetComponent<Renderer>().material = frontPlane;
		moveScene.AddComponent<Button> ();
		move_button = moveScene.GetComponent<Button>(); 
		//move_button.onClick.AddListener(delegate() { EnterSpace(); });
		*/



/*
	public void EnterSpace() {
		print ("hi!");

		if (RenderSettings.skybox == mat1) {
			RenderSettings.skybox = mat2;
		} else if (RenderSettings.skybox == mat2) {
			RenderSettings.skybox = mat3;
		} else if (RenderSettings.skybox == mat3) {
			RenderSettings.skybox = mat4;
		} else if (RenderSettings.skybox == mat4) {
			RenderSettings.skybox = mat5;
		} else if (RenderSettings.skybox == mat5) {
			RenderSettings.skybox = mat6;
		} else if (RenderSettings.skybox == mat6) {
			RenderSettings.skybox = mat7;
		} else if (RenderSettings.skybox == mat7) {
			RenderSettings.skybox = mat8;
		} else if (RenderSettings.skybox == mat8) {
			RenderSettings.skybox = mat9;
		} else if (RenderSettings.skybox == mat9) {
			RenderSettings.skybox = mat10;
		} else if (RenderSettings.skybox == mat10) {
			RenderSettings.skybox = mat2; };				
	}
	*/