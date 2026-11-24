using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButtonManager : MonoBehaviour
{
	public void OnButtonClick()
	{
		UnityEditor.EditorApplication.isPlaying = false;

		Application.Quit();
	}
}
