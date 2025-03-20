using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [Header("Vars to Set")]
    [SerializeField] private float spawnTimer;
    [SerializeField] private int waveSize;
    [SerializeField] private int enemiesAddedEachWave;
    [SerializeField] private float enemyHealthAddedEachWave;
    [SerializeField] private float enemyDamageAddedEachWave;

    [Header("Objects To Reference")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject timerUI;
    [SerializeField] private GameObject player;

    [Header("Debugs")]
    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private float timer;
    private float addedHealth;
    private float addedDamage;

    // Start is called before the first frame update
    void Start()
    {
        if(waveSize <= 0)
        {
            waveSize = 5;
        }

        if (player == null)
        {
            player = GameObject.Find("Player");
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnEnemies();
            timer = spawnTimer;
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < waveSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.GetComponent<Damageable>().health += (int)addedHealth;
            enemy.GetComponent<DamageSource>().damage += (int)addedDamage;

            enemies.Add(enemy);
        }

        waveSize += enemiesAddedEachWave;
        addedHealth += enemyHealthAddedEachWave;
        addedDamage += enemyDamageAddedEachWave;
    }
}
