using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScenes : MonoBehaviour
{

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
