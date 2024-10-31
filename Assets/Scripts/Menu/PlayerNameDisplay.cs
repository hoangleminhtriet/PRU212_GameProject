using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerNameDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text playerNameText;
    void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerNameText.text = PlayerPrefs.GetString("PlayerName");
        }
        else
        {
            playerNameText.text = "Player";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
