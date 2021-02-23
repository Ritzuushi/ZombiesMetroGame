using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawnerScript : MonoBehaviour
{
    public bool trigger = true;
    public int enemiesSpawned;

    public Camera cam;
    public GameObject enemy;
    objectPooler objPooler;
    public playerPrefs prefs;

    private float width;
    private float height;

    private int difficulty;

    void Awake()
    {
        difficulty = PlayerPrefs.GetInt("Difficulty");
    }
    // Start is called before the first frame update
    void Start()
    {
        objPooler = objectPooler.Instance;

        float camSize = cam.orthographicSize;
        width = cam.orthographicSize * cam.aspect + 1;
        height = camSize - 4f;
    }

    public void Update() 
    { 
        if(trigger == true && enemiesSpawned < 200) {
            StartCoroutine(EnemySpawnTimer());
            enemiesSpawned++;
            trigger = false;
        } 
        else if (enemiesSpawned >= 200)
        {
            enemiesSpawned = 0;
        }
    }

    IEnumerator EnemySpawnTimer() 
    {
        if (difficulty == 1)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 2f));
        }
        if (difficulty == 2)
        {
            yield return new WaitForSeconds(Random.Range(1f, 1.5f));
        }
        if (difficulty == 3)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
        }
        StartCoroutine(EnemySpawn());
        yield break;
    }
    IEnumerator EnemySpawn() 
    {  
        Vector3 mainEnemyScale = new Vector3(1f, 1f, 1f);
        Vector3 randEnemyScale = new Vector3(Random.Range(1.0f, 1.3f), Random.Range(0.7f, 1.0f), 1f);
        enemy.transform.localScale = randEnemyScale;

        #region SidePicker
        float randomSide = Random.Range(0f, 1000f);

        if (randomSide > 500f) {
            objPooler.SpawnFromPool("Enemy", new Vector3(width, Random.Range(-height, height), 1f), Quaternion.identity);
        } else {
            objPooler.SpawnFromPool("Enemy", new Vector3(-width, Random.Range(-height, height), 1f), Quaternion.identity);
        }
        #endregion

        enemy.transform.localScale = mainEnemyScale;

        trigger = true;
        yield break;
    }

}
