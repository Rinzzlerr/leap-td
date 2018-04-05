using System;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject TurretPrefab;
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
        var position = currentTower.transform.Find("TurretAttachPoint").transform.position;
        Instantiate(TurretPrefab, position, Quaternion.identity, currentTower.transform);
        currentTower = null;
        TowerPlacedEvent();
    }
}
