using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalMap : MonoBehaviour
{
    public RectTransform pause;
    public LevelControllerScript level;
    public UnityEvent<bool> finished = new UnityEvent<bool>();
    private void OnEnable()
    {
        finished.AddListener(OnFinished);
    }


    private void Start()
    {
        StartCoroutine(CheckLevelComplete());
    }

    private IEnumerator CheckLevelComplete()
    {
        // Loop until no enemies remain
        while (level.CurrentEnemy() > 0)
        {
            var total = level.CurrentEnemy();  // Get the current number of enemies
            Debug.Log("Checking level complete, enemies remaining: " + total);
            yield return null;  // Wait until the next frame before checking again
        }

        // Once all enemies are cleared, trigger the finished event
        finished?.Invoke(true);
    }


    private void Update()
    {
    }
    private void OnFinished(bool isFinish)
    {
        pause.gameObject.SetActive(isFinish);
    }
}
