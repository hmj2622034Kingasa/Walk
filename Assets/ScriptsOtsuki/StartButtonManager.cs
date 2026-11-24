using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour
{
	// Game Startƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚Æ‚«‚Ìˆ—
	public void OnButtonClick()
	{
		SceneManager.LoadScene("GameScene");
	}
}
