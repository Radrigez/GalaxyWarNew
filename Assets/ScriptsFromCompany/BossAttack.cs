using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private float intervalSpawnPrefab;
    private float delayPrefab;
    public GameObject PrefabAttack;
    void Start()
    {
        intervalSpawnPrefab = Random.Range(0.1f, 1f);
        delayPrefab = Random.Range(0.1f, 1f);
        InvokeRepeating("AttackEnemy1", intervalSpawnPrefab, delayPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void AttackEnemy1()
    {
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        Instantiate(PrefabAttack, position, PrefabAttack.transform.rotation);
    }
}
