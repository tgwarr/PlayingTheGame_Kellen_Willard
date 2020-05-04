using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject enemyPrefab;
	private GameObject player;
	public GameObject powerUp;
	private float randRange = 9;
	public int waveNumber = 1;
	private int enemyCount;

    void Start()
    {
		player = GameObject.Find("Player");
    }
		
    void Update()
    {
		enemyCount = FindObjectsOfType<Enemy>().Length;
		if(enemyCount == 0)
		{
			SpawnEnemyWave(waveNumber++);
			Instantiate(powerUp, GenSpawnPos(), powerUp.transform.rotation);
		}
    }

	private Vector3 GenSpawnPos()
	{
		float spawnX = Random.Range(-randRange, randRange);
		float spawnZ = Random.Range(-randRange, randRange);
		Vector3 pos = new Vector3(spawnX, 0,spawnZ);
		return pos;
	}

	private void SpawnEnemyWave(int numEnemies)
	{
		for(int en = 0; en < numEnemies; en++)
		{
			Instantiate(enemyPrefab, GenSpawnPos(), enemyPrefab.transform.rotation);
		}
	}
}
