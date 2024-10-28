using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SceneChanger2D : MonoBehaviour
{
    // Tên của scene bạn muốn load
    public string SceneLevel;
    public GameObject openDoor;
    public GameObject closeDoor;
    public int targetEnemy;
    public bool isDoorOpen = false;

<<<<<<< Updated upstream
	public UnityEvent<bool > isDoorCanOpen = new UnityEvent<bool> ();
	public UnityEvent<int> totalEnemyKill = new UnityEvent<int> ();

	public GameManagerScript gameManagerScript;
=======
    public UnityEvent<bool> isDoorCanOpen = new UnityEvent<bool>();
    public UnityEvent<int> totalEnemyKill = new UnityEvent<int>();
    public Text MessageOpen;
    public Text newMap;
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
                newMap.text = "Arrive to new map " + SceneLevel;
                newMap.gameObject.SetActive(true);
                MessageOpen.gameObject.SetActive(false);
                Debug.Log("Loadddddddd" + newMap.isActiveAndEnabled);
                GameManagerScript.instance.newMapEvent?.Invoke();
>>>>>>> Stashed changes

            });
        }
    }
    private void OnEnable()
    {
        
        isDoorCanOpen.AddListener(OpenDoor);
        totalEnemyKill.AddListener(KillEnemy);

<<<<<<< Updated upstream
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
                gameManager.newMap.text = "Arrive to new map" + SceneLevel;
                gameManager.newMap.gameObject.SetActive(true);
                gameManager.MessageOpen.gameObject.SetActive(false);
				Vector3 playerPos = GameManagerScript.instance.loadMapPos[currentLevel];
				var player = GameManagerScript.instance.playerController;
				player.transform.position = transform.position = playerPos;
				Debug.Log("Loadddddddd"+ playerPos);
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
		openDoor.SetActive (!isOpen);
		closeDoor.SetActive (isOpen);
		isDoorOpen = !isOpen;
        GameManagerScript.instance.MessageOpen.gameObject.SetActive(!isOpen);
	}
	private void Update()
	{
		int currentEnemy = LevelControllerScript.instance.CurrentEnemy();
		KillEnemy(currentEnemy);

	}
=======
    }
 
    private void KillEnemy(int currentEnemy)
    {
        isDoorCanOpen.Invoke(currentEnemy > 0);
    }

    private void OpenDoor(bool isOpen)
    {
        MessageOpen = GameManagerScript.instance.doorOpen;
        newMap = GameManagerScript.instance.newMap;
        openDoor.SetActive(!isOpen);
        closeDoor.SetActive(isOpen);
        isDoorOpen = !isOpen;
        MessageOpen.gameObject.SetActive(!isOpen);
    }
    private void Start()
    {
        targetEnemy = LevelControllerScript.instance.totalEnemy;
    }
    private void Update()
    {
        int currentEnemy = LevelControllerScript.instance.CurrentEnemy();
        KillEnemy(currentEnemy);
    }
>>>>>>> Stashed changes

}

