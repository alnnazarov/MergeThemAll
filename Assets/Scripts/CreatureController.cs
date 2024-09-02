using System.Collections;
using Interfaces;
using ScriptableObjectP;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class CreatureController : MonoBehaviour, ISpawnDependent
{
    [SerializeField] private bool isPatrolling = true;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private TransformScriptableObject spawnPointSO;

    private void Start()
    {
        if (isPatrolling)
        {
            StartCoroutine(PatrolCoroutine());
        }
    }

    private void Update()
    {
        if (!isPatrolling)
        {
            StopCoroutine(PatrolCoroutine());
        }
    }

    public void DisablePatrol()
    {
        isPatrolling = false;
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