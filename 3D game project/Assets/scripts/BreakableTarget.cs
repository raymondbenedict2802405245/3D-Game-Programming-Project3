using UnityEngine;

public class BreakableTarget : MonoBehaviour
{
    public GameObject breakEffect;
    public int scoreValue = 100;

    public AudioSource audioSource;
    public AudioClip breakSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Instantiate(breakEffect, transform.position, Quaternion.identity);

            GameManager.instance.AddScore(scoreValue);

            // 🔊 Play sound
            if (audioSource != null && breakSound != null)
            {
                audioSource.PlayOneShot(breakSound);
            }

            Destroy(gameObject);
        }
    }
}
