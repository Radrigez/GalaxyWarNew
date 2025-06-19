using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class GameManagerTwo : MonoBehaviour
{
    public PlayControllerTwo playControllerTwo;
    public Button pauseButton;
    public Button StartButton;
    public Button MenuButton;
    public Button restartButton;
    private AudioSource audioSource;
    public AudioClip sourceBoom;
    public AudioClip sparcBoom;
    public Image imagePause;
    public GameObject[] enemyShip;
    public GameObject[] allianseShip;
    public GameObject[] heart;
    public GameObject[] emptyHeart;
    public Text higtTimeText;
    public Text timerText;
    public Text gameOverText;
    public Text PauseText;
    private MoveEnemy moveEnemy;

    private int score;
    private int timeBack = 0;
    private int timeBest;
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
       // higtScoreText.text = PlayerPrefs.GetInt("Best", 0).ToString();
        higtTimeText.text = PlayerPrefs.GetInt("Best", 0).ToString();
        audioSource = GetComponent<AudioSource>();
        playControllerTwo = PlayControllerTwo.FindAnyObjectByType<PlayControllerTwo>();
        moveEnemy = MoveEnemy.FindFirstObjectByType<MoveEnemy>();
        StartGame();
        StartCoroutine(TimeToBoss());
  
    }

    IEnumerator TimeToBoss()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            timeBack++;
            timerText.text = $"Time: {timeBack}";
            if (timeBack >= PlayerPrefs.GetInt("Best", timeBack))
            {
                PlayerPrefs.SetInt("Best", timeBack);
                higtTimeText.text = $"Best time: " + timeBack.ToString();
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

    public void StartGame()
    {
        while (!isGameActive)
        {
            playControllerTwo.UpdateScore(0);
            
            isGameActive = true;
            isGameWar = true;

            InvokeRepeating("SpawnEnemy", timeRepitEnemy, intervalEnemy);
            InvokeRepeating("SpawnEnemy", timeRepitEnemy, intervalEnemy);
            InvokeRepeating("SpawnEnemy", timeRepitEnemy, intervalEnemy);
            InvokeRepeating("SpawnEnemy", timeRepitEnemy, intervalEnemy);
            InvokeRepeating("alliance", timeRepit, interval);
        }
    }
    public void TakeDamage(int d)
    {
        if (isGameWar)
        {
            health -= d;
            emtyHealth += d;
            emptyHeart[emtyHealth].SetActive(true);
            if (health == 0)
            {
                GameOver();
            }
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
        gameOverText .gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        isGameActive = false;
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
            imagePause.gameObject.SetActive(isPouse);
            StartButton.gameObject.SetActive(isPouse);
            pauseButton.gameObject.SetActive(!isPouse);
            MenuButton.gameObject.SetActive(isPouse);
            restartButton.gameObject.SetActive(isPouse);
            isPouse = !isPouse;
            Time.timeScale = isPouse ? 0 : 1;
        }
    }

    public void Play()
    {
        MenuButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(false);
        imagePause.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}