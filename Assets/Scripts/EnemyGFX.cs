using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aIPath;

    // Update is called once per frame
    void Update()
    {
        if (aIPath.desiredVelocity.x >= 0f){
            transform.localScale = new Vector2(1f, 1f);
        }

        if (aIPath.desiredVelocity.x < 0f){
            transform.localScale = new Vector2(-1f, 1f);
        }
    }

}
