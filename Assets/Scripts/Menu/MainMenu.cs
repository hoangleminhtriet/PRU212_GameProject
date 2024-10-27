using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
     SceneManager.LoadScene(1);
    }
    public void HowToPlay()
    {
	 SceneManager.LoadScene("HowToPlay");
	}
	public void Settings()
    {
	 SceneManager.LoadScene("Settings");
		
	}
    public void Exitgame()
    {
#if UNITY_EDITOR
		// Nếu đang chạy trong Unity Editor
		UnityEditor.EditorApplication.isPlaying = false;
#else
            // Nếu đang chạy trong build game
            Application.Quit();
#endif
	}
}
