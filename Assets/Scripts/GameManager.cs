using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 playerInitialPosition;
    [SerializeField] private EnemySpawner enemySpawner;
    [SerializeField] private EnemySpawner starsSpawner;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    public bool isGamePaused;
    public static GameManager instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGamePaused = false;
        Instantiate(player, playerInitialPosition, player.transform.rotation);
        enemySpawner.StartEnemySpawn();
        starsSpawner.StartEnemySpawn();
        pauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
        pauseMenu.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        pauseMenu.SetActive(false);
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
