using System;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private TransformScriptableObject spawnPointSO;
    [SerializeField] private ListScriptableObject creaturesListSO;

    public void SpawnCreatures(int number)
    {
        List<GameObject> creaturesList = creaturesListSO.GetList();
        
        if (creaturesList == null || creaturesList.Count == 0)
        {
            Debug.LogWarning("CreaturesList is Empty");
            return;
        }

        if (number <= 1)
        {
            Debug.LogWarning("Creatures must be more than 1");
            return;
        }
        
        for (int i = 0; i < number/2; i++)
        {
            GameObject creaturePrefab = creaturesList[i];
            
            Vector3 randomPositionOne = GetRandomPositionNearSpawnPoint();
            Vector3 randomPositionTwo = GetRandomPositionNearSpawnPoint();
            
            Instantiate(creaturePrefab, randomPositionOne, Quaternion.identity);
            Instantiate(creaturePrefab, randomPositionTwo, Quaternion.identity);
        }
    }
    
    private Transform GetSpawnTransform()
    {
        return spawnPointSO.GetTransform();
    }

    private Vector3 GetRandomPositionNearSpawnPoint()
    {
        Random random = new Random();
        float x = (float)(random.NextDouble() * 10 - 5);
        float y = (float)(random.NextDouble() * 8 - 4);
        return new Vector3(x, y, 0.0f);
    }
}
