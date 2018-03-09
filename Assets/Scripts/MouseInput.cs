using UnityEngine;

[RequireComponent(typeof(TowerPlacement))]
public class MouseInput : MonoBehaviour
{
    private TowerPlacement towerPlacement;
    private bool towerPlacementActive = false;

    [SerializeField]
    private KeyCode newTowerHotkey = KeyCode.A;

    private void Start()
    {
        towerPlacement = FindObjectOfType<TowerPlacement>();
    }

    private void Update()
    {
        PositionTower();

        if (towerPlacementActive == false)
            return;

        SendMousePosition();
        PlaceTowerOnLeftClick();
    }

    private void SendMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            towerPlacement.MoveCurrentTowerToPosition(hitInfo.point);
        }
    }

    private void PositionTower()
    {
        if (Input.GetKeyDown(newTowerHotkey))
        {
            if (towerPlacementActive == true)
            {
                towerPlacement.ClearSelection();
                towerPlacementActive = false;
            }
            else
            {
                towerPlacement.SelectTower();
                towerPlacementActive = true;
            }
        }
    }

    private void PlaceTowerOnLeftClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            towerPlacement.PlaceTower();
            towerPlacementActive = false;
        }
    }
}
