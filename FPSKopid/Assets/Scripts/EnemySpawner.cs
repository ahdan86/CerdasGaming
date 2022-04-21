using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject covidPrefab;

    List<Tuple<float, float>> respawnEnemy = new List<Tuple<float, float>>{
        new Tuple<float, float>(22, 34),
        new Tuple<float, float>(5, 34),
        new Tuple<float, float>(40, 34),
        new Tuple<float, float>(40, 30),
        new Tuple<float, float>(40, -1),
        new Tuple<float, float>(5, -1),
        new Tuple<float, float>(5, 30),
    };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawner());
    }

    private IEnumerator spawner(){
        yield return new WaitForSeconds(UnityEngine.Random.Range(2f, 10f));
        Tuple<float, float> newEnemyPos = respawnEnemy[UnityEngine.Random.Range(0, 6)];
        
        GameObject newCovid = Instantiate(covidPrefab, new Vector3(newEnemyPos.Item1, 1.3f, newEnemyPos.Item2), Quaternion.identity);
        StartCoroutine(spawner());
        Debug.Log("test");
    }
}