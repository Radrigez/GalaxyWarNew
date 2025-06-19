using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpark : MonoBehaviour
{
    private GameManager gameManager;
    private AudioSource sourceBoom;
    public AudioClip Spark;
    private float speed = 5f;
    private float topLimit = 5;
    public int damage = 1;

    void Start()
    {
        gameManager = GameManager.FindAnyObjectByType<GameManager>();
        sourceBoom = GetComponent<AudioSource>();
        sourceBoom.PlayOneShot(Spark);
    }

    void Update()
    {
        MoveSparkc();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boss"))
        {
            gameManager.TakeDamageBoss(damage);
            //other.gameObject.SetActive(false);
           // gameObject.SetActive(false);
            gameManager.AudioSource();
        }
    }

    private void MoveSparkc()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        if (transform.position.y > topLimit)
        {
            Destroy(gameObject);
        }
    }
}
