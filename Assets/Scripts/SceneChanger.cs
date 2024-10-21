using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger2D : MonoBehaviour
{
	// Tên của scene bạn muốn load
	public string Map2;

	// Hàm này sẽ được gọi khi một đối tượng khác va chạm với Trigger Collider 2D
	private void OnTriggerEnter2D(Collider2D other)
	{
		// Kiểm tra nếu đối tượng va chạm là nhân vật của bạn
		if (other.CompareTag("Player"))
		{
			// Chuyển scene
			SceneManager.LoadScene(Map2);
		}
	}
}

