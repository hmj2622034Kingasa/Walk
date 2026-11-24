using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour
{

	public void OnButtonClick()
	{
		SceneManager.LoadScene("GameScene");
	}
}
