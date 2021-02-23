using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPowerUp : MonoBehaviour
{
    public objectPooler objPooler;

    public Camera cam;

    private float width;
    private float height;
    public float delay;

    public bool isSpawned;

    // Start is called before the first frame update
    void Start()
    {
        float camSize = cam.orthographicSize;
        width = cam.orthographicSize * cam.aspect - 3f;
        height = camSize - 5f;

        isSpawned = true;

        int difficulty = PlayerPrefs.GetInt("Difficulty");

        if (difficulty == 1)
        {
            delay = 60f;
        }
        else if (difficulty == 2)
        {
            delay = 50f;
        }
        else if (difficulty == 3)
        {
            delay = 40f;
        }

        StartCoroutine(SpawnBombDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (isSpawned != true) 
        {
            SpawnBomb();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup();
        }
    }

    void Pickup()
    {
        // Effect
        for (int i = 0; i < 200; i++)
        {
            objPooler.DespawnToPool("Enemy");
        }
        FindObjectOfType<SoundManager>().Play("Explosion");
        objPooler.DespawnToPool ("BombPU");
        
    }

    void SpawnBomb() 
    {
        objPooler.DespawnToPool ("BombPU");
        objPooler.SpawnFromPool("BombPU", new Vector3(Random.Range(-width, width), Random.Range(-height, height), 1f), Quaternion.identity);
        isSpawned = true;
        FindObjectOfType<SoundManager>().Play("BombSpawn");
        StartCoroutine(SpawnBombDelay());
    }

    IEnumerator SpawnBombDelay()
    {
        yield return new WaitForSeconds(delay);
        isSpawned = false;
        yield break;
    }
}
