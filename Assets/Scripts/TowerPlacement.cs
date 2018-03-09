using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject TowerPrefab;

    private GameObject currentTower;

    public void SelectTower()
    {
        currentTower = Instantiate(TowerPrefab);
    }

    public void ClearSelection()
    {
        Destroy(currentTower);
    }

    public void MoveCurrentTowerToPosition(Vector3 newPosition)
    {
        currentTower.transform.position = newPosition;
    }

    public void PlaceTower()
    {
        currentTower = null;
    }
}
