using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;

    public float CurrentHealth;
    private bool canTakeDamage = true;
    private Knockback knockback;
    private Flash flash;

    public Image healthBar;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        CurrentHealth = MaxHealth;
    }

    private void Start()
    {

    }

    private void Update()
    {
        UpdateHealthBar();
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();

        if (enemy)
        {
            TakeDamage(1, other.transform);
        }
    }

    public void TakeDamage(int damageAmount, Transform hitTransform)
    {
        if (!canTakeDamage) { return; }

        knockback.GetKnockedBack(hitTransform, knockBackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        CurrentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
