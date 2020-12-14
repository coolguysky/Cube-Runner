using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemy;
    public static GameManager instance;
    public Transform spawnPoint;
    public float maxSpawnPointX;
    private int score;
    private int highScore;
    public Text scoreText;
    public Text highScoreText;
    private bool gameStarted = false;
    public GameObject menuPanel;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }
    private void Update()
    {
        if (!gameStarted && Input.anyKeyDown)
        {
            menuPanel.SetActive(false);
            scoreText.gameObject.SetActive(true);
            StartCoroutine(nameof(SpawnEnemies));
            gameStarted = true;
        }
    }
    public void Spawn()
    {
        float randomSpawnX = Random.Range(-maxSpawnPointX, maxSpawnPointX);
        Vector3 enemySpawnPos = spawnPoint.position;
        enemySpawnPos.x = randomSpawnX;
        Instantiate(enemy, enemySpawnPos, Quaternion.identity);
    }
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Spawn();
        }
    }
    public void Retart()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        SceneManager.LoadScene(0);
    }
    public void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
