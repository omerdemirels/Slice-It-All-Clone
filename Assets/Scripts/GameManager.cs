using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameOver;
    private int sceneIndex;
    public int SceneIndex { get { return sceneIndex; } }    

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject nextLevelPanel;
    private void Awake()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Start()
    {
        gameOver = false;
     
    }

    public void GameOverPanel()
    {
       gameOver = true;
        if (gameOver&&gameOverPanel!=null)
        {
            gameOverPanel.SetActive(true); 
        }

    }
    public void NextLevelPanel()
    {
        if (nextLevelPanel != null)
        {
            nextLevelPanel.SetActive(true);
        }
       
    }
    /// <summary>
    /// Ayn� level� yeniden ba�lat
    /// </summary>
    public void Restart()
    {
       
        SceneManager.LoadScene(sceneIndex);

    }
    /// <summary>
    /// Level ekran� de�i�tirir.
    /// </summary>
    public void NextLevel()
    {
        gameOver = true;//panel a��ld���nda karakter harekteti olmas�n

        
        if (sceneIndex + 1 <= SceneManager.sceneCountInBuildSettings - 1)
        {

            SceneManager.LoadScene(sceneIndex + 1);

        }
        else
        {
            SceneManager.LoadScene(sceneIndex);

        }


    }

    public void QuitGame()
    {
        gameOver = true;
        Application.Quit();
    }
}