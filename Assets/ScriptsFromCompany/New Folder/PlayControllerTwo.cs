using UnityEngine;
using UnityEngine.UI;

public class PlayControllerTwo : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject prefabSpark;

    public GameManagerTwo gameManagerTwo;

    private int score;
    public Text scoreText;
    public Text higtScoreText;

    private float board = 6f;
    private float horizontalInput;



    void Start()
    {
        // gameManagerTwo = GameObject.Find("GameManagerTwo").GetComponent<GameManagerTwo>();
        higtScoreText.text = PlayerPrefs.GetInt("dest", 0).ToString();
    }


    void Update()
    {
        playController();
        MoveSpark();
    }

    void MoveSpark()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(prefabSpark, transform.position, prefabSpark.transform.rotation);
        }
    }




    public void playController()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * Time.deltaTime * speed * horizontalInput);

        if (transform.position.x > board)
        {
            transform.Translate(board - transform.position.x, 0, 0);
        }
        if (transform.position.x < -board)
        {
            transform.Translate(-board - transform.position.x, 0, 0);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EnemySpark"))
        {
            Destroy(other.gameObject);
            Debug.Log("Game Over!");
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;


        if (score > PlayerPrefs.GetInt("dest", 0))
        {
            PlayerPrefs.SetInt("dest", score);
            higtScoreText.text = $"dest score: " + score.ToString();
            higtScoreText.text = "dest score: " + score;
        }
    }

}
