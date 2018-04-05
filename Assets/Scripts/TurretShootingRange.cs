using System;
using UnityEngine;

public class TurretShootingRange : MonoBehaviour
{
    private Action<GameObject> enemyEnteredShootingRange = new Action<GameObject>((go) => { });
    private Action<GameObject> enemyExitedShootingRange = new Action<GameObject>((go) => { });

    public LayerMask TargetedLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Mathf.RoundToInt(Mathf.Log(TargetedLayer.value, 2)))
        {
            enemyEnteredShootingRange(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == Mathf.RoundToInt(Mathf.Log(TargetedLayer.value, 2)))
        {
            enemyExitedShootingRange(other.gameObject);
        }
    }

    public void SubscribeToEnemyEnteredShootingRange(Action<GameObject> callback)
    {
        enemyEnteredShootingRange += callback;
    }

    public void SubscribeToEnemyExitedShootingRange(Action<GameObject> callback)
    {
        enemyExitedShootingRange += callback;
    }

    private void OnEnable()
    {
        enemyEnteredShootingRange = new Action<GameObject>((go) => { });
        enemyExitedShootingRange = new Action<GameObject>((go) => { });
    }

    private void OnDisable()
    {
        enemyEnteredShootingRange = null;
        enemyExitedShootingRange = null;
    }

    private void OnDestroy()
    {
        enemyEnteredShootingRange = null;
        enemyExitedShootingRange = null;
    }
}
