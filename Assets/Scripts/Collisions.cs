using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    public ManageScenes manageScenes;
    private bool gameHasEnded = false;
    private float delay = 1f;

    void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Friendly"))// || Fluel == 0)
        {
            EndGame();
            //destroy rocket
            //reload the level after 2 secs
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            print("You Win");
            manageScenes.LoadNextLevel();
        }
                
    }

    void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("End Game");
            EndGame();

            Invoke("Restart", delay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
