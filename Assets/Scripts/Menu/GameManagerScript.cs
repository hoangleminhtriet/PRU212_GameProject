/*<<<<<<< Updated upstream
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;
=======*/
using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public CinemachineVirtualCamera cameChine;
    public Playercontroller playerController;
    public List<Vector3> loadMapPos = new List<Vector3>();
    public int currentLevel = 1;
    public Text MessageOpen;
    public Text newMap;
    //khởi tạo gameOverUI 
    public GameObject gameOverUI;

    public UnityEvent newMapEvent = new();

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (gameOverUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    private void OnEnable()
    {
        newMapEvent.AddListener(OnNewMap);
    }


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
        Debug.LogWarning("inactive message");
        newMap.gameObject.SetActive(false);
    }

    //OverGame 
    public void GameOver()
    {
        gameOverUI.SetActive(true);
    }

    public void Restart()
    {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        gameOverUI.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("quit game");
    }
}