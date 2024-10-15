using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
	public AudioMixer audioMixer;
	public Slider volumeSlider;

	void Start()
	{
		// Đặt giá trị ban đầu của slider
		volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.75f);
	
	}

	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20); // Logarithmic scale cho âm lượng
		PlayerPrefs.SetFloat("Volume", volume); // Lưu lại giá trị âm lượng
	}

	public void BackToMainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}
}
