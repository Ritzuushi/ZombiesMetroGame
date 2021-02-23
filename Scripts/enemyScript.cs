using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class enemyScript : MonoBehaviour
{
    public Transform player;
    public Rigidbody2D rb;
    public TilemapCollider2D wallCollider;
    public BoxCollider2D enemyCollider;

    void Start() {
        Physics2D.IgnoreCollision(enemyCollider, wallCollider);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
    }

    
}
