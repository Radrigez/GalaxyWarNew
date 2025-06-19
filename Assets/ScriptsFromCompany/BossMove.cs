using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    private MoveSpark MoveSparkPlayer;
    public GameManager gameManager;
    private float x = 5f;
    private float speed = 1f;
    private bool moving;
    private float speedRight = 1;
    private float intervalSpawnPrefab;
    private float delayPrefab;



    void Start()
    {
        intervalSpawnPrefab = Random.Range(0.1f, 1f);
        delayPrefab = Random.Range(0.1f, 1f);
    
    }

    // Update is called once per frame
    void Update()
    {
        MoveBoss();
    }
   
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spark"))
        {
           
            Destroy(other.gameObject);
            gameManager.AudioSource();
        }
    }

    
    private void MoveBoss()
    {
        if (transform.position.x > x)
        {
            moving = false;

        }
        if (transform.position.x < -x)
        {
            moving = true;
            
        }
        if (moving)
        {
            transform.position = new Vector2(transform.position.x + speedRight * Time.deltaTime, transform.position.y);
            transform.Translate(Vector2.up * 0.1f * Time.deltaTime);
        }
        if (!moving)
        {
            transform.position = new Vector2(transform.position.x - speedRight * Time.deltaTime, transform.position.y);
            transform.Translate(Vector2.up * 0.1f * Time.deltaTime);
        }
    }

}
