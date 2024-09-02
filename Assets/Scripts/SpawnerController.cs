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

        GameObject firstCreatedCreature = null;

        for (int i = 0; i < number / 2; i++)
        {
            GameObject creaturePrefab = creaturesList[i];

            Vector3 randomPositionOne = ((ISpawnDependent)this).GetRandomPositionNearSpawnPoint();
            Vector3 randomPositionTwo = ((ISpawnDependent)this).GetRandomPositionNearSpawnPoint();

            if (i == 0)
            {
                firstCreatedCreature = Instantiate(creaturePrefab, randomPositionOne, Quaternion.identity);
            }
            else
            {
                Instantiate(creaturePrefab, randomPositionOne, Quaternion.identity);
            }

            Instantiate(creaturePrefab, randomPositionTwo, Quaternion.identity);
        }

        if (firstCreatedCreature != null)
        {
            PlayerController playerController = firstCreatedCreature.GetComponent<PlayerController>();
            CreatureController creatureController = firstCreatedCreature.GetComponent<CreatureController>();

            if (playerController != null && creatureController != null)
            {
                playerController.EnableMoving();
                creatureController.DisablePatrol();
            }
        }
    }

    public Transform GetSpawnTransform()
    {
        return spawnPointSO.GetTransform();
    }
}