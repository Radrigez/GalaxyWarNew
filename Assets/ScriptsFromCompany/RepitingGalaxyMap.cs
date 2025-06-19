using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class RepitingGalaxyMap : MonoBehaviour
{
    [SerializeField] float speed;
    private Vector2 position;
    private float repeatDown;
  
    void Start()
    {
        position = transform.position;
        repeatDown = GetComponent<BoxCollider2D>().size.y/2;
    }


    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        if (transform.position.y < -13.3 - repeatDown)
        {
            transform.position = position;
        }
    }
}
