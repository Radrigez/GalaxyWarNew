using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSparkTwo : MonoBehaviour
{
    private AudioSource sourceBoom;
    public AudioClip Spark;

    private float speed = 6f;
    private float topLimit = 5;


    void Start()
    {
        sourceBoom = GetComponent<AudioSource>();
        sourceBoom.PlayOneShot(Spark);
    }

    void Update()
    {
        MoveSparkc();
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
