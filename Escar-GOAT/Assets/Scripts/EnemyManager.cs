using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using TMPro;
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
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < waveSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnLocations[Random.Range(0, spawnLocations.Count)].position, Quaternion.identity);
            enemy.GetComponent<Damageable>().health += (int)addedHealth;
            enemy.GetComponent<DamageSource>().damage += (int)addedDamage;
            enemy.GetComponent<Enemy>().manager = this;
            enemies.Add(enemy);
        }

        waveSize += enemiesAddedEachWave;
        addedHealth += enemyHealthAddedEachWave;
        addedDamage += enemyDamageAddedEachWave;
    }
}
