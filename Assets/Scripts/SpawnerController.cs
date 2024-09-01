using System.Collections.Generic;
using Interfaces;
using ScriptableObjectP;
using UnityEngine;

public class SpawnerController : MonoBehaviour, ISpawnDependent
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

        for (int i = 0; i < number / 2; i++)
        {
            GameObject creaturePrefab = creaturesList[i];

            Vector3 randomPositionOne = ((ISpawnDependent)this).GetRandomPositionNearSpawnPoint();
            Vector3 randomPositionTwo = ((ISpawnDependent)this).GetRandomPositionNearSpawnPoint();

            Instantiate(creaturePrefab, randomPositionOne, Quaternion.identity);
            Instantiate(creaturePrefab, randomPositionTwo, Quaternion.identity);
        }
    }

    public Transform GetSpawnTransform()
    {
        return spawnPointSO.GetTransform();
    }
}