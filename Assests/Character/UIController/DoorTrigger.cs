using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    public string sceneToLoad;  // Name of the scene to load
    public bool isPlayerInRange = false;
    private GolemEnemy golemEnemy;

    // Static variables to store the position and rotation
    private static Vector3 targetPosition;
    private static Quaternion targetRotation;
    private static bool shouldMovePlayer = false;

    void Start()
    {
        golemEnemy = FindObjectOfType<GolemEnemy>();

        // Check if the player needs to be moved
        if (shouldMovePlayer)
        {
            MovePlayerToStoredPosition();
            shouldMovePlayer = false; // Reset the flag
        }
    }

    void Update()
    {
        if (isPlayerInRange && golemEnemy != null && golemEnemy.enemyHealth <= 0)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Save the player's current position and rotation
                GameObject player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    targetPosition = player.transform.position;
                    targetRotation = player.transform.rotation;
                    shouldMovePlayer = true;
                }

                // Load the specified scene
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void MovePlayerToStoredPosition()
    {
        // Set the player's position and rotation to the stored values
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            player.transform.position = targetPosition;
            player.transform.rotation = targetRotation;
        }
    }
}
