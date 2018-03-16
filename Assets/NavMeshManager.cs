using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour
{
    private TowerPlacement towerPlacement;
    private NavMeshSurface navMeshSurface;

    private void Awake()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        towerPlacement = FindObjectOfType<TowerPlacement>();
        towerPlacement.TowerPlacedEvent += MeshWasModified;
    }

    private void MeshWasModified()
    {
        navMeshSurface.BuildNavMesh();
    }
}
