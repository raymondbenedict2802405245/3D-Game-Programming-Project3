using UnityEngine;

public class GunController2 : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileForce = 20f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;
    public CameraShake cameraShake; // drag kamera ke sini

    public AudioSource audioSource;   // komponen AudioSource di senjata
    public AudioClip shootSound;      // file suara tembakan



    // Tambahan: prefab particle
    public GameObject muzzleFlashPrefab;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Spawn peluru
        GameObject bullet = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * projectileForce, ForceMode.Impulse);

        // Spawn particle effect di ujung senjata
        Instantiate(muzzleFlashPrefab, firePoint.position, firePoint.rotation);
        GetComponent<GunRecoil>().DoRecoil();

        audioSource.PlayOneShot(shootSound);

        // StartCoroutine(cameraShake.Shake(0.1f, 0.05f));


    }
}
