using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
{
    // Destroy(other.gameObject); // hancurkan target
    Destroy(gameObject);       // hancurkan peluru
}

}
