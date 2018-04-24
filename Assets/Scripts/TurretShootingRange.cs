using System;
using UnityEngine;

public class TurretShootingRange : MonoBehaviour
{
    private Action<GameObject> enemyEnteredShootingRange;
    private Action<GameObject> enemyExitedShootingRange;

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
        if (enemyEnteredShootingRange == null)
        {
            enemyEnteredShootingRange = (go) => { };
        }
        enemyEnteredShootingRange += callback;
    }

    public void SubscribeToEnemyExitedShootingRange(Action<GameObject> callback)
    {
        if (enemyExitedShootingRange == null)
        {
            enemyExitedShootingRange = (go) => { };
        }
        enemyExitedShootingRange += callback;
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
