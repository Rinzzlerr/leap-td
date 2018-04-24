using System;
using UnityEngine;

public class TurretAiming : MonoBehaviour
{
    private GameObject currentEnemy;
    private Transform enemyTransform;

    private Action facingEnemy;
    private Action lookingForEnemy;

    private void OnDisable()
    {
        facingEnemy = null;
        lookingForEnemy = null;
        currentEnemy = null;
        enemyTransform = null;
    }

    private void OnDestroy()
    {
        facingEnemy = null;
        lookingForEnemy = null;
        currentEnemy = null;
        enemyTransform = null;
    }

    public void SubscribeToFacingEnemyEvent(Action callback)
    {
        if (facingEnemy == null)
        {
            facingEnemy = () => { };
        }
        facingEnemy += callback;
    }

    public void SubscribeToLookingForEnemy(Action callback)
    {
        if (lookingForEnemy == null)
        {
            lookingForEnemy = () => { };
        }
        lookingForEnemy += callback;
    }

    public void AimAtEnemy(GameObject enemy)
    {
        currentEnemy = enemy;
        enemyTransform = currentEnemy.transform;
    }

    public void StopAiming()
    {
        currentEnemy = null;
        enemyTransform = null;
    }
}
