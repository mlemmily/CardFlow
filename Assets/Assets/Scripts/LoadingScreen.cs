using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI progressText;
	[SerializeField]
	private Slider slider;

	private AsyncOperation operation;
	private Canvas canvas;

	//grabs all the parts inside of the canvas and tells the game to not destroy when the next scene loads load
	private void Awake()
	{
		canvas = GetComponentInChildren<Canvas>(true);
		DontDestroyOnLoad(gameObject);
	}

	//
	public void LoadScene(string sceneName)
	{
		UpdateProgressUI(0);
		canvas.gameObject.SetActive(true);

		StartCoroutine(BeginLoad(sceneName));
	}

	private IEnumerator BeginLoad(string sceneName)
	{
		operation = SceneManager.LoadSceneAsync(sceneName);

		while (!operation.isDone)
		{
			UpdateProgressUI(operation.progress);
			yield return null;
		}

		UpdateProgressUI(operation.progress);
		operation = null;
		canvas.gameObject.SetActive(false);
	}

	private void UpdateProgressUI(float progress)
	{
		slider.value = progress;
		progressText.text = (int)(progress * 100f) + "%";
	}
}
