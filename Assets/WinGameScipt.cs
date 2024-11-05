using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WinGameScipt : MonoBehaviour
{
    public UnityEvent<bool> isDoorCanOpen = new UnityEvent<bool>();
    public UnityEvent<int> totalEnemyKill = new UnityEvent<int>();

    // Start is called before the first frame update
    private void Update()
    {
        int currentEnemy = LevelControllerScript.instance.CurrentEnemy();
        KillEnemy(currentEnemy);

    }
    private void KillEnemy(int currentEnemy)
    {
        isDoorCanOpen.Invoke(currentEnemy > 0);
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 1; // Khôi phục thời gian game
        SceneManager.LoadScene("MainMenu"); // Thay "MainMenu" bằng tên chính xác của scene menu
    }

}
