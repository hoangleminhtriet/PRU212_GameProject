using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Image heathl;
    private GameObject player;
    private PlayerHealth playerHealth;


    void Start()
    {
        heathl.fillAmount = 1;
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            Debug.Log("Health");
        }
        /*playerHealth.currentHealth = 100;*/
    }

    // Update is called once per frame
    void Update()
    {
        /*heathl.fillAmount = playerHealth.currentHealth;
        */
    }
}
