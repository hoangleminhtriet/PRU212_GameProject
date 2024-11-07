﻿using System.Net.WebSockets;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger2D : MonoBehaviour
{
    // Tên của scene bạn muốn load
    public string SceneLevel;
    public GameObject openDoor;
    public GameObject closeDoor;
    public int targetEnemy;
    public bool isDoorOpen = false;

    public UnityEvent<bool> isDoorCanOpen = new UnityEvent<bool>();
    public UnityEvent<int> totalEnemyKill = new UnityEvent<int>();

    public GameManagerScript gameManagerScript;
    public Text MessageOpen;
    public Text newMap;
    // Hàm này sẽ được gọi khi một đối tượng khác va chạm với Trigger Collider 2D

    private void OnEnable()
    {

        isDoorCanOpen.AddListener(OpenDoor);
        totalEnemyKill.AddListener(KillEnemy);
    }
    // Hàm này sẽ được gọi khi một đối tượng khác va chạm với Trigger Collider 2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng va chạm là nhân vật của bạn
        if (other.CompareTag("Player") && isDoorOpen)
        {
            Debug.Log("Player enter");
            // Chuyển scene
            LoadSceneManager.instance.LoadSceneByName(SceneLevel, () =>
            {
                var gameManager = GameManagerScript.instance;

                int currentLevel = GameManagerScript.instance.currentLevel;
                gameManager.newMap.text = "Arrive to new map " + SceneLevel;
                gameManager.newMap.gameObject.SetActive(true);
                gameManager.MessageOpen.gameObject.SetActive(false);
                gameManager.newMapEvent.Invoke();
            });
        }
    }
    private void Start()
    {
        targetEnemy = LevelControllerScript.instance.totalEnemy;
        isDoorCanOpen.AddListener(OpenDoor);
        totalEnemyKill.AddListener(KillEnemy);
        gameManagerScript = GameManagerScript.instance;


    }
    private void KillEnemy(int currentEnemy)
    {
        isDoorCanOpen.Invoke(currentEnemy > 0);
    }

    private void OpenDoor(bool isOpen)
    {
        openDoor.SetActive(!isOpen);
        closeDoor.SetActive(isOpen);
        isDoorOpen = !isOpen;
        GameManagerScript.instance.MessageOpen.gameObject.SetActive(!isOpen);

        string currentScene = SceneManager.GetActiveScene().name;
        if(currentScene.CompareTo("Map4") == 0 )
        {
            Debug.Log(" (currentScene.CompareTo(\"Map4\") == 0");
            var setting = GameObject.Find("PauseMenuPanel");
            setting.SetActive(true);
        }

    } 
        private void Update()
    {
        int currentEnemy = LevelControllerScript.instance.CurrentEnemy();
        KillEnemy(currentEnemy);
    }

}

