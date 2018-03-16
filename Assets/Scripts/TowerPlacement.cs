using System;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject TowerPrefab;
    private GameObject currentTower;

    public Action TowerPlacedEvent = new Action(() => { });

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
        TowerPlacedEvent();
    }
}
