using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void OpenOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}