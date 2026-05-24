using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public AudioClip loseSound;

    private bool isGameOver = false;
    // Update is called once per frame
    void Update()
    {
        if (!isGameOver && GameObject.FindGameObjectWithTag("Player") == null)
        {
            isGameOver = true;

            gameOverPanel.SetActive(true);
            if (loseSound != null)
            {
                AudioSource.PlayClipAtPoint(loseSound, transform.position);
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
