using System.Collections;
using Interfaces;
using ScriptableObjectP;
using UnityEngine;

public class CreatureController : MonoBehaviour, ISpawnDependent
{
    public float moveSpeed = 2f;

    [SerializeField] private TransformScriptableObject spawnPointSO;

    private void Start()
    {
        StartCoroutine(PatrolCoroutine());
    }

    public Transform GetSpawnTransform()
    {
        return spawnPointSO.GetTransform();
    }

    IEnumerator PatrolCoroutine()
    {
        while (true)
        {
            Vector3 targetPosition = ((ISpawnDependent)this).GetRandomPositionNearSpawnPoint();

            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }

            yield return new WaitForSeconds(2f);
        }
    }
}