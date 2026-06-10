using UnityEngine;

public class GunController : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;   // Prefab peluru
    public Transform firePoint;           // Posisi ujung senjata
    public float projectileForce = 20f;   // Kekuatan dorong peluru

    [Header("Input Settings")]
    public KeyCode fireKey = KeyCode.Mouse0; // Tombol tembak (klik kiri)

    void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Spawn projectile di posisi firePoint
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Tambahkan gaya ke Rigidbody projectile
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);
        }
    }
}
