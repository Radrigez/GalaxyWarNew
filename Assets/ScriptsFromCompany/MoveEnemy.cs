using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MoveEnemy : MonoBehaviour
{
    public PlayControllerTwo playControllerTwo;
    private float speedUp;
    private float speedRight;
    private float randX; 
    public GameObject PrefabAttack;
    private GameManager gameManager;
    public GameObject particle;
    private float botLimit = -6f;
    private float botLimitEnemy = 6f;
    private float intervalSpawnPrefab;
    private float delayPrefab;
    public int score;
    public int glasses;
    private bool moving;

    void Start()
    {
        score = 0;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager = GameObject.FindAnyObjectByType<GameManager>();
        intervalSpawnPrefab = Random.Range(0.1f, 1f);
        delayPrefab = Random.Range(0.1f, 1f);
        InvokeRepeating("AttackEnemy", intervalSpawnPrefab, delayPrefab);

    }

   
   
    void Update()
    {
        MoveEnemytrue();
      
    }

    private void AttackEnemy()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Instantiate(PrefabAttack, position, PrefabAttack.transform.rotation);
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);

        if (other.gameObject.CompareTag("Spark") || other.gameObject.CompareTag("AllianceSpark"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(particle, position, particle.transform.rotation);
            gameManager.AudioSource();
        }
        
    }

    private void AudioSource()
    {
        throw new System.NotImplementedException();
    }


    private void MoveEnemyDown()
    {
        randX = Random.Range(5f, 8f);
        speedUp = Random.Range(1f, 4f);
        speedRight = Random.Range(1f, 4f);

        transform.Translate(Vector2.up * speedUp * Time.deltaTime);

        if (transform.position.y < botLimit)
        {
            Destroy(gameObject);
        }
    }

    private void MoveEnemytrue()
    {
        randX = Random.Range(5f,8f);
        speedUp = Random.Range(1f, 4f);
        speedRight = Random.Range(1f, 4f);
        if (transform.position.x > randX)
        {
           moving = false;

        }
        if (transform.position.x < -randX)
        {
            moving = true;
 
        }
        if(moving)
        {
            transform.position = new Vector2(transform.position.x + speedRight * Time.deltaTime, transform.position.y);
            transform.Translate(Vector2.up * speedUp * Time.deltaTime);
        }
        if (!moving)
        {
            transform.position = new Vector2(transform.position.x - speedRight * Time.deltaTime, transform.position.y);
            transform.Translate(Vector2.up * speedUp * Time.deltaTime);
        }

        if (transform.position.y < botLimit)
        {
            Destroy(gameObject);
        }
    }
}
