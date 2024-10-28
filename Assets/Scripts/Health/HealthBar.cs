using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar  : MonoBehaviour
{
    private RectTransform bar;
    private Image barImage;

    // Start is called before the first frame update
void Start()
    {
        bar = GetComponent<RectTransform>();
        barImage = GetComponent<Image>();
        if (Health.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }
        SetSize(Health.totalHealth);
    }

    public void Damage(float damage)
    {
        Health.totalHealth -= damage; // Trừ máu một lần duy nhất

        // Đảm bảo totalHealth không âm
        if (Health.totalHealth < 0f)
        {
            Health.totalHealth = 0f;
        }

        if (Health.totalHealth < 0.3f)
        {
            barImage.color = Color.red;
        }

        SetSize(Health.totalHealth);
    }

    public void SetSize(float size)
    {
        bar.localScale = new Vector3(size, 1f, 1f);
    }
}
