using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public List<GameObject> monsterPrefab;

    public float spawnTime = 5f;

    public Transform[] spawnPoints;

    public Transform t1;
    public Transform t2;

    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    void Update()
    {

    }

    IEnumerator SpawnMonster()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);

            Vector3 spawnPosition = new Vector3(
                Random.Range(t1.localPosition.x, t2.localPosition.x), 0.5f,
                Random.Range(t1.localPosition.z, t2.localPosition.z));

            if(monsterPrefab.Count > 0)
            {
                int randomIndex = Random.Range(0, monsterPrefab.Count);
                Instantiate(monsterPrefab[randomIndex], spawnPosition, Quaternion.identity);
            }
        }

    }
}
