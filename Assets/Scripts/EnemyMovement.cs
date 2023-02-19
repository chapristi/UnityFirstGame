using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
 
    public float moveSpeed = 5f;
    [SerializeField] public Transform[] waypoints;
    public int damageOnCollision = 20;
    [SerializeField] public SpriteRenderer spriteRenderer;
    private Transform targetWaypoint;
    private int destPoint;
    
    void Start()
    {
        destPoint = 1;
        targetWaypoint = waypoints[destPoint];
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 displacement = targetWaypoint.position - transform.position;
        //displacement = displacement.normalized;
        if (Vector2.Distance (targetWaypoint.position, transform.position) > 0.1f) {
            transform.position = Vector2.MoveTowards(transform.position,targetWaypoint.transform.position,moveSpeed * Time.deltaTime);
        }
        else{
            //ou binaire comme j'ai un tableau à double entré
            destPoint = 1 ^ destPoint ;
            targetWaypoint = waypoints[destPoint];
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //throw new NotImplementedException();
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDammage( damageOnCollision);
        }
    }
}
