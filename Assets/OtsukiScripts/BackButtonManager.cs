using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtonManager : MonoBehaviour
{
	// Backƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚Æ‚«‚Ìˆ—
	public void OnButtonClick()
	{
		SceneManager.LoadScene("OtsukiScene");
	}
}
