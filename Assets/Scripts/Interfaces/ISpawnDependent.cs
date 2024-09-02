using UnityEngine;

namespace Interfaces
{
    public interface ISpawnDependent
    {
        const int XBorder = 5;
        const int YBorder = 4;

        Transform GetSpawnTransform();

        Vector3 GetRandomPositionNearSpawnPoint()
        {
            Vector3 spawnPosition = GetSpawnTransform().position;

            float x = Random.Range(spawnPosition.x - XBorder, spawnPosition.x + XBorder);
            float y = Random.Range(spawnPosition.y - YBorder, spawnPosition.y + YBorder);

            return new Vector3(spawnPosition.x + x, spawnPosition.y + y, spawnPosition.z);
        }
    }
}