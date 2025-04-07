using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    [Header("Vars to Set")]
    [SerializeField] private float spawnTimer;
    [SerializeField] private float waveSize;
    [SerializeField] private float enemiesAddedEachWave;
    [SerializeField] private float enemyHealthAddedEachWave;
    [SerializeField] private float enemyDamageAddedEachWave;
    [SerializeField] private float spawnRadius;
    [SerializeField] private int initialWaveScore = 10;
    [SerializeField] private int waveScoreMultiplier = 1;
    [SerializeField] private int smallEnemySpawnChance;

    [Header("Objects To Reference")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject smallEnemyPrefab;
    [SerializeField] private TextMeshProUGUI timerUI;
    [SerializeField] private GameObject player;
    [SerializeField] private List<Transform> spawnLocations;

    [Header("Debugs")]
    public List<GameObject> enemies;
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

        if (timerUI == null)
        {
            timerUI = GameObject.Find("Wave Timer").GetComponent< TextMeshProUGUI>();
        }

        if (spawnLocations == null || spawnLocations.Count <= 0)
        {
            foreach (Transform child in player.transform.GetChild(0))
            {
                spawnLocations.Add(child);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        timerUI.text = "Next Wave: " + (int)timer;

        if (timer <= 0 || enemies.Count <= 0)
        {
            SpawnEnemies();
            timer = spawnTimer;
            PlayerStats.ScoreCount += initialWaveScore * waveScoreMultiplier;
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < (int)waveSize; i++)
        {

            Vector3 SpawnLocation = spawnLocations[Random.Range(0, spawnLocations.Count)].position;
            SpawnLocation.x += Random.Range(-spawnRadius, spawnRadius);
            SpawnLocation.y += Random.Range(-spawnRadius, spawnRadius);

            GameObject enemy = null;

            if (waveSize >= 15 && Random.Range(0, 100) < smallEnemySpawnChance)
            {
                enemy = Instantiate(smallEnemyPrefab, SpawnLocation, Quaternion.identity);
                enemy.GetComponent<Enemy>().SetHealth((int)addedHealth - 1);

            }
            else
            {
                enemy = Instantiate(enemyPrefab, SpawnLocation, Quaternion.identity);
                enemy.GetComponent<Enemy>().SetHealth((int)addedHealth);
            }

            enemy.GetComponent<Enemy>().manager = this;
            enemy.GetComponent<DamageSource>().damage += (int)addedDamage;

            enemies.Add(enemy);
        }

        waveSize += enemiesAddedEachWave;
        addedHealth += enemyHealthAddedEachWave;
        addedDamage += enemyDamageAddedEachWave;
    }

    public void PlayerHit()
    {

        for(int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i] != null)
            {
                enemies[i].GetComponent<Enemy>().KnockBack(50);
            }
            else
            {
                enemies.RemoveAt(i);
                i--;
            }
        }
    }
}
