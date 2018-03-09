using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;

    public Transform destination;

    private void Start()
    {
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        SetDestination();
    }

    private void SetDestination()
    {
        Vector3 targetVector = destination.transform.position;
        navMeshAgent.SetDestination(targetVector);
    }
}
