using UnityEngine;
using TMPro;

public class ScorePopup : MonoBehaviour
{
    public float moveUpSpeed = 2f;
    public float fadeDuration = 1f;
    private TextMeshPro text;

    void Start()
    {
        text = GetComponent<TextMeshPro>();
        Destroy(gameObject, fadeDuration);
    }

    void Update()
    {
        transform.Translate(Vector3.up * moveUpSpeed * Time.deltaTime);
    }
}
