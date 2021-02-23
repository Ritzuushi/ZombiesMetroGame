using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPowerUp : MonoBehaviour
{
    public playerStatusScript stats;
    public ScoreScript score;
    public TimerScript timeScript;
    public objectPooler objPooler;

    public Camera cam;

    private float width;
    private float height;

    public bool isSpawned;

    void Start()
    {
        float camSize = cam.orthographicSize;
        width = cam.orthographicSize * cam.aspect - 3f;
        height = camSize - 5f;

        isSpawned = true;
        StartCoroutine(SpawnHeartDelay());
    }

    void Update()
    {
        if (isSpawned != true) 
        {
            SpawnHeart();
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

        stats.Heal(10f);
        score.Heal(10f);

        FindObjectOfType<SoundManager>().Play("HeartPickup");

        objPooler.DespawnToPool ("HeartPU");
    }

    void SpawnHeart() 
    {
        objPooler.DespawnToPool ("HeartPU");
        objPooler.SpawnFromPool("HeartPU", new Vector3(Random.Range(-width, width), Random.Range(-height, height), 1f), Quaternion.identity);
        isSpawned = true;
        FindObjectOfType<SoundManager>().Play("HeartSpawn");
        StartCoroutine(SpawnHeartDelay());
    }

    IEnumerator SpawnHeartDelay()
    {
        yield return new WaitForSeconds(13f);
        isSpawned = false;
        yield break;
    }

}
