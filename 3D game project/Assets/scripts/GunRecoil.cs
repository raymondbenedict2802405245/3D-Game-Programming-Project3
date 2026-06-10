using UnityEngine;

public class GunRecoil : MonoBehaviour
{
    public Transform gunTransform;
    public float recoilDistance = 0.1f;
    public float recoilSpeed = 10f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = gunTransform.localPosition;
    }

    public void DoRecoil()
    {
        // Mundur dikit
        gunTransform.localPosition = originalPosition - Vector3.forward * recoilDistance;
    }

    void Update()
    {
        // Balik ke posisi normal pelan-pelan
        gunTransform.localPosition = Vector3.Lerp(
            gunTransform.localPosition,
            originalPosition,
            Time.deltaTime * recoilSpeed
        );
    }
}
