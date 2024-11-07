using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.UI;

public class LevelControllerScript : MonoBehaviour
{
	// Start is called before the first frame update

	public static LevelControllerScript instance;
	public List<GameObject> enemys;
	public int totalEnemy;
	public int currentLevel;
	public Transform enemyParent;
	private void Awake()
	{
		instance = this;
	}
	private void OnEnable()
	{
		totalEnemy = enemyParent.childCount;
	}
  
    public int CurrentEnemy()
	{
		return enemyParent.childCount;
	}
	public int CurrentLevel()
	{
		return currentLevel;
	}
	
}
