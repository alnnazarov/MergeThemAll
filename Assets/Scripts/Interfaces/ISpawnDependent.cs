using UnityEngine;

namespace Interfaces
{
    public interface ISpawnDependent
    {
        Transform GetSpawnTransform();

        Vector3 GetRandomPositionNearSpawnPoint()
        {
            Vector3 spawnPosition = GetSpawnTransform().position;

            float x = Random.Range(spawnPosition.x - 5, spawnPosition.x + 5);
            float y = Random.Range(spawnPosition.y - 4, spawnPosition.y + 4);

            return new Vector3(spawnPosition.x + x, spawnPosition.y + y, spawnPosition.z);
        }
    }
}