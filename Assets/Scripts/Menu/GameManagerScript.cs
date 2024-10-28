using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
	public static GameManagerScript instance;
	public CinemachineVirtualCamera cameChine;
	public Playercontroller playerController;
	public List<Vector3> loadMapPos = new List<Vector3>();
	public int currentLevel = 1;
    public Text MessageOpen;
    public Text newMap;
    private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		instance = this;
	}

}
