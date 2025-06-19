using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public Button pauseButton;
    public Button StartButton;
    public Button MenuButton;
    public Button restartButton;
    public Button restartButton2;
    private AudioSource audioSource;
    public AudioClip sourceBoom;
    public AudioClip sparcBoom;
    public Image imageGameOver;
    public Image imagePause;
    public GameObject[] enemyShip;
    public GameObject[] allianseShip;
    public GameObject[] heart;
    public GameObject[] emptyHeart;
    public GameObject[] heartBoos;
    public GameObject[] emptyHeartBoss;
    public int healthBoss;
    public int emtyHealthBoss;
    public GameObject defeatPanel;
    public GameObject musicGame;
    public GameObject musicGameOver;
    public Text higtScoreText;
    public Text scoreText;
    public Text timerText;
    public Text gameOverText;
    private MoveEnemy moveEnemy;
    private MoveSpark moveSpark;
    public GameObject PanelbossEnemy;
    public GameObject bossEnemy;
    public GameObject particalBoss;
    public GameObject panelVictory;
    public GameObject musicVictory;
    public GameObject player;
    private int score;
    private int timeBack = 60;
    public int health;
    public int emtyHealth;

    public bool isGameActive;
    public bool isGameWar;

    private float boardY = 10f;
    private float boardX = 6.5f;
    private float timeRepit = 2f;
    private float interval = 2f;
    private float timeRepitEnemy = 0.5f;
    private float intervalEnemy = 1f;



    void Awake()
    {
        Pause();
        higtScoreText.text = PlayerPrefs.GetInt("best", 0).ToString();
        audioSource = GetComponent<AudioSource>();
        moveEnemy = MoveEnemy.FindFirstObjectByType<MoveEnemy>();
        StartGame();
        StartCoroutine(TimeToBoss());
    }


    IEnumerator TimeBoss()
    {
        yield return new WaitForSeconds(3);
        PanelbossEnemy.SetActive(true);
        bossEnemy.SetActive(true);
    }
    IEnumerator TimeToBoss()
    {
       while(isGameActive)
        {
            yield return new WaitForSeconds(1);
            timeBack -- ;
            timerText.text = $"Time: {timeBack}";

            if(timeBack <= 0)
            {
                StartCoroutine(TimeBoss());
                isGameActive = false;
                yield break;
            }
        }
    }

    public void AudioSource()
    {
        audioSource.PlayOneShot(sourceBoom);
    }
    public void AudioSourceBoom()
    {
        audioSource.PlayOneShot(sparcBoom);
    }

   
    public void defealPlot()
    {
        defeatPanel.gameObject.SetActive(true);
        restartButton2.gameObject.SetActive(true);
    }
    public void StartGame()
    {
         while (!isGameActive)
         {
            musicGame.gameObject.SetActive(true);
            score = 0;
            UpdateScore(0);
            isGameActive = true;
            isGameWar = true;
            InvokeRepeating("SpawnEnemy", timeRepitEnemy, intervalEnemy);
            InvokeRepeating("SpawnEnemy", timeRepitEnemy, intervalEnemy);
            InvokeRepeating("SpawnEnemy", timeRepitEnemy, intervalEnemy);
            InvokeRepeating("SpawnEnemy", timeRepitEnemy, intervalEnemy);

            InvokeRepeating("alliance", timeRepit, interval);
            InvokeRepeating("alliance", timeRepit, interval);
            Time.timeScale = 1f;
        }
    }
    public void TakeDamageBoss(int d)
    {
        Vector2 position = new Vector2(transform.position.x - 2, transform.position.y + 2);
        Vector2 position2 = new Vector2(transform.position.x + 2, transform.position.y - 2);
        Vector2 position3 = new Vector2(transform.position.x + 2, transform.position.y + 2);
        Vector2 position4 = new Vector2(transform.position.x - 2, transform.position.y - 2);
        Vector2 position5 = new Vector2(transform.position.x, transform.position.y);
        if (isGameWar)
        {
            healthBoss -= d;
            emtyHealthBoss += d;
            emptyHeartBoss[emtyHealthBoss].SetActive(true);
            if (healthBoss == 0)
            { 
                Instantiate(particalBoss, position, particalBoss.transform.rotation);
                Instantiate(particalBoss, position2, particalBoss.transform.rotation);
                Instantiate(particalBoss, position3, particalBoss.transform.rotation);
                Instantiate(particalBoss, position4, particalBoss.transform.rotation);
                Instantiate(particalBoss, position5, particalBoss.transform.rotation);
                PanelbossEnemy.SetActive(false);
                Destroy(bossEnemy);
                AudioSource();
                AudioSource();
                AudioSource();
                AudioSource();
                AudioSource();
                AudioSourceBoom();
                AudioSourceBoom();
                AudioSourceBoom();
                AudioSourceBoom();
                AudioSourceBoom();
                panelVictory.SetActive(true);
                musicGame.gameObject.SetActive(false);
                musicVictory.SetActive(true);
                
            }

        }
    }
    public void TakeDamage(int d)
    {
        if (isGameWar)
        {
            health -= d;
            emtyHealth += d;
            emptyHeart[emtyHealth].SetActive(true);
            if(health == 0)
            {
                GameOver();
            }
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;


        if (score > PlayerPrefs.GetInt("best", 0))
        {
            PlayerPrefs.SetInt("best", score);
            higtScoreText.text = $"Best score: " + score.ToString();
            higtScoreText.text = "Best score: " + score;
        }
    }


    private void SpawnEnemy()
    {
        if (isGameActive)
        {
            float randomX = Random.Range(-boardX, boardX);
            int indexEnemy = Random.Range(0, enemyShip.Length);
            Vector2 position = new Vector2(randomX, boardY);
            Instantiate(enemyShip[indexEnemy], position, enemyShip[indexEnemy].transform.rotation);

            float randomX2 = Random.Range(-boardX, boardX);
            int indexAllianse = Random.Range(0, allianseShip.Length);
            Vector2 position2 = new Vector2(randomX2, -boardY);
            Instantiate(allianseShip[indexAllianse], position2, allianseShip[indexAllianse].transform.rotation);

            Time.timeScale = 1f;
        }
        
    }


    public void GameOver()
    {
        player.gameObject.SetActive(false);
        PanelbossEnemy.SetActive(false);
        musicGame.gameObject.SetActive(false);
        musicGameOver.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        isGameActive = false;
        defealPlot();
        Time.timeScale = 0f;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void MoveMenu()
    {
        SceneManager.LoadScene(0);
    }

    private bool isPouse = false;
    void Update()
    {
        Pause();
    }
    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPouse = !isPouse;
            Time.timeScale = isPouse ? 0 : 1;
            imagePause.gameObject.SetActive(isPouse);
            StartButton.gameObject.SetActive(isPouse);
            //pauseButton.gameObject.SetActive(!isPouse);
            MenuButton.gameObject.SetActive(isPouse);
            restartButton.gameObject.SetActive(isPouse);
        }
    }
}
