using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugControlls : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.R))
            RestartGame();

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Tab))
            Application.Quit();
    }

    public void RestartGame()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
