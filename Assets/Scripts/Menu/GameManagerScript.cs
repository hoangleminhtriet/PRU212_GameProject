<<<<<<< Updated upstream
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
=======
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
>>>>>>> Stashed changes
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
	public static GameManagerScript instance;
<<<<<<< Updated upstream
	public CinemachineVirtualCamera cameChine;
	public Playercontroller playerController;
	public List<Vector3> loadMapPos = new List<Vector3>();
	public int currentLevel = 1;
    public Text MessageOpen;
    public Text newMap;
=======
	public Text doorOpen;
	public Text newMap;
	public UnityEvent newMapEvent =  new();
    private void OnEnable()
    {
        newMapEvent.AddListener(OnNewMap);
    }



>>>>>>> Stashed changes
    private void Awake()
	{
		instance = this;
		DontDestroyOnLoad(gameObject);
		instance = this;
	}
    private void OnNewMap()
    {
        StartCoroutine(TurnOffMessage());
    }
    public IEnumerator TurnOffMessage()
    {
        yield return new WaitForSeconds(3);
        newMap.gameObject.SetActive(false);
    }
}
