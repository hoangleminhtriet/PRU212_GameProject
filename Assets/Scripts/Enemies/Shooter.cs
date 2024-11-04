using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour, IEnemy
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float fireRate = 2f; // Tốc độ bắn bình thường
    [SerializeField] private int circleBulletCount = 10; // Số lượng đạn trong vòng tròn
    [SerializeField] private float circleInterval = 6f; // Thời gian giữa các lần bắn vòng tròn
    [SerializeField] private float bulletSpreadAngle = 10f; // Góc lệch giữa 2 viên đạn bình thường

    private float nextFireTime;

    private void Start()
    {
        // Bắt đầu Coroutine để bắn vòng tròn mỗi 6 giây
        StartCoroutine(ShootCircleRoutine());
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Attack(); // Gọi phương thức Attack() khi bắn bình thường
            nextFireTime = Time.time + fireRate;
        }
    }

    // Phương thức Attack() triển khai từ giao diện IEnemy
    public void Attack()
    {
        Vector2 targetDirection = (Playercontroller.Instance.transform.position - transform.position).normalized;

        // Bắn viên đạn thứ nhất với góc lệch
        GameObject bullet1 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Projectile projectile1 = bullet1.GetComponent<Projectile>();
        if (projectile1 != null)
        {
            projectile1.SetDirection(Quaternion.Euler(0, 0, bulletSpreadAngle) * targetDirection);
        }

        // Bắn viên đạn thứ hai với góc lệch ngược lại
        GameObject bullet2 = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Projectile projectile2 = bullet2.GetComponent<Projectile>();
        if (projectile2 != null)
        {
            projectile2.SetDirection(Quaternion.Euler(0, 0, -bulletSpreadAngle) * targetDirection);
        }
    }

    // Coroutine để bắn vòng tròn mỗi 6 giây
    private IEnumerator ShootCircleRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(circleInterval); // Chờ 6 giây
            ShootCircle();
        }
    }

    // Phương thức bắn vòng tròn 10 viên đạn
    private void ShootCircle()
    {
        float angleStep = 360f / circleBulletCount; // Góc giữa các viên đạn
        float angle = 0f;

        for (int i = 0; i < circleBulletCount; i++)
        {
            float bulletDirX = Mathf.Cos(angle * Mathf.Deg2Rad);
            float bulletDirY = Mathf.Sin(angle * Mathf.Deg2Rad);
            Vector2 bulletDirection = new Vector2(bulletDirX, bulletDirY).normalized;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Projectile projectile = bullet.GetComponent<Projectile>();
            if (projectile != null)
            {
                projectile.SetDirection(bulletDirection);
            }

            angle += angleStep; // Tăng góc cho viên đạn tiếp theo
        }
    }
}
