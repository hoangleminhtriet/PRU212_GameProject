using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 20f; // Giá trị máu tối đa của người chơi
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTime = 1f;

    public float CurrentHealth; // Lượng máu hiện tại của người chơi
    private bool canTakeDamage = true;
    private Knockback knockback;
    private Flash flash;

    public Image healthBar;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockback = GetComponent<Knockback>();
        CurrentHealth = MaxHealth; // Đảm bảo máu hiện tại bắt đầu bằng giá trị tối đa
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

        // Gọi knockback nếu có component Knockback
        if (knockback != null)
        {
            knockback.GetKnockedBack(hitTransform, knockBackThrustAmount);
        }

        // Bắt đầu hiệu ứng flash nếu có component Flash
        if (flash != null)
        {
            StartCoroutine(flash.FlashRoutine());
        }

        canTakeDamage = false;
        CurrentHealth -= damageAmount;
        CurrentHealth = Mathf.Max(CurrentHealth, 0); // Đảm bảo CurrentHealth không xuống dưới 0
        StartCoroutine(DamageRecoveryRoutine());
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    void UpdateHealthBar()
    {
        // Kiểm tra nếu healthBar không null trước khi cập nhật
        if (healthBar != null)
        {
            healthBar.fillAmount = Mathf.Clamp01(CurrentHealth / MaxHealth); // Đảm bảo fillAmount luôn trong khoảng từ 0 đến 1
        }
    }
}
