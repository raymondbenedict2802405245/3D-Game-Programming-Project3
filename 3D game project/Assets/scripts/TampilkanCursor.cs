using UnityEngine;

public class TampilkanCursor : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // bebas
        Cursor.visible = true;                  // tampilkan cursor
    }
}
