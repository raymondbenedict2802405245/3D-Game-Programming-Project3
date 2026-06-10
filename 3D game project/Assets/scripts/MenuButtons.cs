using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    // Fungsi untuk tombol Play
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene"); 
        // ganti "LevelDifficulty" dengan nama scene level kamu
    }

    // Fungsi untuk tombol Quit
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Closed"); // hanya terlihat di editor
    }
}
