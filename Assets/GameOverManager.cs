using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; // Kéo GameOverPanel từ Prefab vào đây
    [SerializeField] private PlayerHealth playerHealth; // Kéo đối tượng người chơi có PlayerHealth vào đây

    private void Start()
    {
        // Đảm bảo bảng Game Over ban đầu ở trạng thái ẩn
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("Game Over Panel is not assigned in the Inspector.");
        }

        // Tìm đối tượng PlayerHealth nếu chưa được gán
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth == null)
            {
                Debug.LogError("PlayerHealth component not found in the scene.");
            }
        }
    }

    private void Update()
    {
        // Kiểm tra nếu người chơi hết máu để hiển thị bảng Game Over
        if (playerHealth != null && playerHealth.CurrentHealth <= 0)
        {
            Debug.Log("Player health reached zero. Showing Game Over panel.");
            ShowGameOver();
        }
    }

    public void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Hiển thị bảng Game Over
            Time.timeScale = 0f; // Dừng thời gian trong game
        }
        else
        {
            Debug.LogError("Game Over Panel is missing. Check assignment in Inspector.");
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Khôi phục thời gian
        SceneManager.LoadScene(1); // Tải lại cảnh có index 1 (màn 1 trong Build Settings)
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f; // Khôi phục thời gian
        SceneManager.LoadScene("MainMenu"); // Đảm bảo có cảnh MainMenu trong Build Settings
    }

    public void ExitGame()
    {
        Application.Quit(); // Thoát game
        Debug.Log("Game is exiting"); // Thông báo khi chạy trong Unity Editor
    }
}
