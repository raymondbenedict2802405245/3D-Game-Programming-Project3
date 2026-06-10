using UnityEngine;

public class LaserSight : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform firePoint;
    public float maxDistance = 50f;

    void Update()
    {
        // Raycast ke depan
        Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hit;

        Vector3 endPosition;
        if (Physics.Raycast(ray, out hit, maxDistance))
        {
            endPosition = hit.point; // kena object
        }
        else
        {
            endPosition = firePoint.position + firePoint.forward * maxDistance; // lurus aja
        }

        // Update Line Renderer
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, endPosition);
    }
}
