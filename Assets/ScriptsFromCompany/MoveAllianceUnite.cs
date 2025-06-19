using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.UIElements;

public class MoveAllianceUnite : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject particalBoom;
    private float speed;
    private float speedRight;
    private float botLimit = 5;
    private float randX;
    public GameObject sparcPrefab;
    private float interval;
    private float delay;
    private bool moving;


    // Start is called before the first frame update
    void Start()
    {
        gameManager =  FindFirstObjectByType<GameManager>();
        interval = Random.Range(0.5f, 1.8f);
        delay = Random.Range(0.5f, 1.8f);
        InvokeRepeating("SpawnPrefabs", interval, delay);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
  
    }

    private void Move()
    {
        randX = Random.Range(5f, 8f);
        speed = Random.Range(1f, 3f);
        speedRight = Random.Range(1f, 3f);
        if (transform.position.x > randX)
        {
            moving = false;

        }
        if (transform.position.x < -randX)
        {
            moving = true;

        }
        if (moving)
        {
            transform.position = new Vector2(transform.position.x + speedRight * Time.deltaTime, transform.position.y);
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (!moving)
        {
            transform.position = new Vector2(transform.position.x - speedRight * Time.deltaTime, transform.position.y);
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        if (transform.position.y > botLimit)
        {
            Destroy(gameObject);
        }
    }


    private void SpawnPrefabs()
    {
       Vector2 positionSpark = new Vector2(transform.position.x, transform.position.y);
        Instantiate(sparcPrefab, positionSpark, sparcPrefab.transform.rotation);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemySpark"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(particalBoom, position, particalBoom.transform.rotation);
            gameManager.AudioSource();
        }
    }
    
}
