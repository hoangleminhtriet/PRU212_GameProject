using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerNameInput;

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerNameInput.text = PlayerPrefs.GetString("PlayerName");
        }
    }
    public void PlayGame()
    {
        string playerName = playerNameInput.text;
        PlayerPrefs.SetString("PlayerName", playerName);
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
