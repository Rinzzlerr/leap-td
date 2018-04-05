using System;
using UnityEngine;

public class TurretAiming : MonoBehaviour
{
    private GameObject currentEnemy;
    private Transform enemyTransform;

    private Action facingEnemy = new Action(() => { });
    private Action lookingForEnemy = new Action(() => { });

    private void OnEnable()
    {
        facingEnemy = new Action(() => { });
        lookingForEnemy = new Action(() => { });
    }

    private void OnDisable()
    {
        facingEnemy = null;
        lookingForEnemy = null;
    }

    private void OnDestroy()
    {
        facingEnemy = null;
        lookingForEnemy = null;
    }

    public void SubscribeToFacingEnemyEvent(Action callback)
    {
        facingEnemy += callback;
    }

    public void SubscribeToLookingForEnemy(Action callback)
    {
        lookingForEnemy += callback;
    }

    public void AimAtEnemy(GameObject enemy)
    {

    }

    public void StopAiming()
    {

    }
}
