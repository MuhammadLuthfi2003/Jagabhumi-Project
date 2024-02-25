using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;
    public Transform player;
    public float range;
    private float distToPlayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);
        if(distToPlayer <= range){

            Shoot();
            rb.velocity = Vector2.zero;
        }
    }

    void Shoot(){

    }
}
