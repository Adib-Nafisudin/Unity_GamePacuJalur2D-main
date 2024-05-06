using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    [SerializeField] private List<GameObject> itemPrefabsList;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform startPoint;
    [SerializeField] private float rangeY = 1.4f;
    [SerializeField] private float initialX = 5f;
    [Tooltip("Kepadatan Item dan Obstacle yang akan muncul, semakin kecil semakin padat dan semakin banyak semakin sedikit")]
    [SerializeField] private float itemDensity = 10;


    private void Start()
    {
        GenerateItemAndObstacle();
    }

    void GenerateItemAndObstacle()
    {
        float raceDistance = endPoint.position.x-startPoint.position.x;
        float itemPerRaceDistance = raceDistance/itemDensity;
        Debug.Log($"generated Item = {Mathf.Floor(itemPerRaceDistance)}");
        float stepX = initialX;
        for (int i = 1; i <= Mathf.Floor(itemPerRaceDistance); i++)
        {
            GameObject itemPrefab = itemPrefabsList[Random.Range(0, itemPrefabsList.Count)];
            // float randomX = Random.Range(endPoint.position.x + initialX , startPoint.position.x);
            stepX += itemDensity;
            float randomY = Random.Range(-rangeY, rangeY);
            Vector3 spawnPosition = new Vector3(stepX, randomY, 0);

            Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
