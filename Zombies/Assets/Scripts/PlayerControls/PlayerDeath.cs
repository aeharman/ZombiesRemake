using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;  // Reference to the "You Died" screen (panel)
    [SerializeField] private GameObject deathText;    // Reference to the "You Died" text
    [SerializeField] private AudioSource deathSound;  // Reference to the AudioSource for the death sound

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("beeEnemy")) // Check if the object touching the player is tagged as "Enemy"
        {
            ShowDeathScreen();
        }
    }

    private void ShowDeathScreen()
    {
        // Show both the black panel and death text
        if (deathScreen != null)
        {
            deathScreen.SetActive(true);  // Show the black background panel
        }

        if (deathText != null)
        {
            deathText.SetActive(true);  // Show the death text
        }

        // Play the death sound
        if (deathSound != null)
        {
            deathSound.Play();  // Play the death sound effect
        }

        // Optionally, stop the game
        Time.timeScale = 0;  // Freeze the game
    }
}




