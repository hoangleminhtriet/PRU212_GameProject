using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class LevelControllerScript : MonoBehaviour
{
	// Start is called before the first frame update

	public static LevelControllerScript instance;
	public List<GameObject> enemys;
	public int totalEnemy;
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
}
