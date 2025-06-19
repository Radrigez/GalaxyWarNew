using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Net.NetworkInformation;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject prefabSpark;
    private GameManager gameManager;
   

   
    private float board = 6f;
    private float horizontalInput;
  
 

    void Start()
    { 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
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
            Instantiate(prefabSpark,transform.position, prefabSpark.transform.rotation);   
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


}

