using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    private GameObject currentEnemy;

    private List<GameObject> enemiesInRange = new List<GameObject>();

    public TurretShooting turretShooting;
    public TurretAiming turretAiming;
    public TurretShootingRange turretShootingRange;

    private void Awake()
    {
        turretShootingRange.SubscribeToEnemyEnteredShootingRange(EnemyEnteredShootingRange);
        turretShootingRange.SubscribeToEnemyExitedShootingRange(EnemyExitedShootingRange);
    }

    private void ChangeCurrentEnemy()
    {
        if (enemiesInRange.Count == 0)
            return;

        if (currentEnemy == null)
        {
            currentEnemy = enemiesInRange.GetClosestGameObject(gameObject);
            turretAiming.AimAtEnemy(currentEnemy);
        }
    }

    public void EnemyEnteredShootingRange(GameObject enemy)
    {
        Debug.Log(enemy);
        enemiesInRange.Add(enemy);
        ChangeCurrentEnemy();
    }

    public void EnemyExitedShootingRange(GameObject enemy)
    {
        enemiesInRange.RemoveGameObject(enemy);

        if (currentEnemy.GetInstanceID() == enemy.GetInstanceID())
        {
            currentEnemy = null;
            turretShooting.StopShooting();
            turretAiming.StopAiming();
        }

        ChangeCurrentEnemy();
    }
}
