using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    public ManageScenes manageScenes;
    private bool gameHasEnded = false;
    private float delay = 1f;
    private GameObject player;
    RocketMovement rocketMovement;

    private AudioClip succsess;
    private AudioClip dead;
    public static AudioSource rocketSound;

    void Start()
    {
        player = gameObject;
        rocketMovement = player.GetComponent<RocketMovement>();
        succsess = rocketMovement.success;
        dead = rocketMovement.dead;
        rocketSound = player.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (gameHasEnded == true) { return; } // ignor collision when dead

        if (other.gameObject.CompareTag("Finish"))
        {
            rocketSound.PlayOneShot(player.GetComponent<RocketMovement>().success);            //need to check this sound it doesnt work gameObject.GetComponent<RocketMovement>().success
            rocketMovement.successParticles.Play();
            print("You Win");
            GetComponent<ManageScenes>().Invoke("LoadNextLevel", delay);
        }
        else if(!other.gameObject.CompareTag("Friendly"))// || Fluel == 0)
        {
            EndGame(gameObject);
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
            rocketMovement.deadParticles.Play();
            rocketSound.PlayOneShot(dead);            //need to check this sound it doesnt work

            //player.SetActive(false);
           // Destroy(player);

            Invoke("Restart", delay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
