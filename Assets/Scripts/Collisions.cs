using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    public ManageScenes manageScenes;
    private bool gameHasEnded = false;
    private float delay = 1f;
    private GameObject player;
    RocketMovement rocketMovement;

    //private AudioClip succsess;
    //private AudioClip dead;
    public static AudioSource rocketSound;


    void Start()
    {
        player = gameObject;
        rocketMovement = player.GetComponent<RocketMovement>();
       // succsess = rocketMovement.success;
      //  dead = rocketMovement.dead;
        rocketSound = player.GetComponent<AudioSource>();
        //rocketSound.PlayOneShot(dead);
    }

    void OnCollisionEnter(Collision other)
    {
        
        if (!other.gameObject.CompareTag("Friendly"))// || Fluel == 0)
        {
            EndGame(gameObject);
        }
        
        if (gameHasEnded == true) { return; } // ignor collision when dead

        if (other.gameObject.CompareTag("Finish"))
        {
            rocketSound.PlayOneShot(gameObject.GetComponent<RocketMovement>().success);            //need to check this sound it doesnt work
            print("You Win");
            manageScenes.LoadNextLevel();
        }
                
    }

    void EndGame(GameObject player)
    {
        if (gameHasEnded == false)
        {
           // rocketSound.Stop();
            gameHasEnded = true;
            Debug.Log("Game Over");
            EndGame(player);

            rocketSound.PlayOneShot(player.GetComponent<RocketMovement>().dead);                //need to check this sound it doesnt work

            player.SetActive(false);
            //Destroy(player);

            Invoke("Restart", delay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
