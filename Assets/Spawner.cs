using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour {

    public float spawnDelay = 1f;
    public GameObject enemyPrefab;
    public Transform destination;
    public Transform spawnPoint;

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpawnEnemy()
    {
        while(true)
        {
            yield return new WaitForSeconds(spawnDelay);

            var enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemy.GetComponent<EnemyMove>().SetDestination(destination.position);
        }
    }
}
