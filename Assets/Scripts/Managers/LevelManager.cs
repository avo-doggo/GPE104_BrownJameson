using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [Header("Player")]
    public PlayerController playerController;

    [Header("Game")]
    public List<Obstacle> obstacleList;
    public int score;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text scoreWinText;

    [Header("Screen Boundaries")]
    public float topBorder = 1.5f;
    public float bottomBorder = 1.5f;

    [Header("Player Lives")]
    public int startingLives = 3;
    public int lives;
    public TMP_Text livesText;

    private Camera mainCamera;

    public float screenLeft;
    public float screenRight;
    public float screenTop;
    public float screenBottom;

    public GameObject gameOverPanel;
    public GameObject winPanel;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        obstacleList = new List<Obstacle>();

        mainCamera = Camera.main;

        CalculateScreenBounds();
    }

    private void Start()
    {
        lives = startingLives;
        UpdateLivesUI();
    }

    public void LoseLife()
    {
        lives--;

        UpdateLivesUI();

        if (lives <= 0)
        {
            GameOver();
        }
        else
        {
            RespawnPlayer();
        }
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = lives.ToString();
        }
    }

    public void GameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Destroy(playerController.gameObject);
        }
    }

    public void CheckForVictory()
    {
        // If there are still enemies alive, the player has not won.
        if (obstacleList.Count > 0)
        {
            return;
        }

        // Show the victory screen.
        if (winPanel != null)
        {
            winPanel.SetActive(true);
            scoreWinText.text = score.ToString();
        }

        Debug.Log("You Win!");
    }

    public void RespawnPlayer()
    {
        if (playerController != null)
        {
            playerController.Respawn();
        }
    }

    private void CalculateScreenBounds()
    {
        if (mainCamera == null)
        {
            return;
        }

        // Get the bottom-left corner of the camera
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(
            new Vector3(0, 0, -mainCamera.transform.position.z)
        );

        // Get the top-right corner of the camera
        Vector3 topRight = mainCamera.ViewportToWorldPoint(
            new Vector3(1, 1, -mainCamera.transform.position.z)
        );

        // Left and right edges of the screen
        screenLeft = bottomLeft.x;
        screenRight = topRight.x;

        // Top and bottom edges, leaving room for the UI bars
        screenBottom = bottomLeft.y + bottomBorder;
        screenTop = topRight.y - topBorder;
    }


    private void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        // Check for victory condition
        CheckForVictory();
    }


    public void AddScore(int amount)
    {
        score += amount;
    }


    public void AddObstacle(Obstacle obstacle)
    {
        if (obstacle != null && !obstacleList.Contains(obstacle))
        {
            obstacleList.Add(obstacle);
        }
    }


    public void RemoveObstacle(Obstacle obstacle)
    {
        if (obstacle != null && obstacleList.Contains(obstacle))
        {
            obstacleList.Remove(obstacle);
        }
    }
}