﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* CREDIT WHERE CREDIT IS DUE

    The code written in this file was created with the asistance of a tutorial 
    made by Mix and Jam. The video is available on YouTube. 

    Mix and Jam - Celeste Movement: https://www.youtube.com/watch?v=STyY26a_dPY&t=6s

    in conjunction with Board to Bits Games tutorial on better 2D jumping

    Board to Bits Games - Better Jumping in Unity: https://www.youtube.com/watch?v=7KiK0Aqtmzc 

 */

public class CollisionDetection : MonoBehaviour
{
    [Header("Component Reference")]
        [SerializeField] private AudioSource LandSound;
        [SerializeField] private ParticleManager LandEffect;

    [Header("Results")]
        public bool grounded;
        public bool onWall;
        public int Wall;
        public bool TopOfWall;


    [Header("Collision Controllers")]
        public LayerMask CollisionLayer; 
        [Range(0,1f)] public float collisionRadius = 0.25f;
        [Range(0,2f)] public float groundCollisionBoxSize = 0.5f;
        [Range(0,1f)] public float TopOfWallColliderSize = 0.2f;
        public Vector2 bottomOffset, rightOffset, leftOffset;


    // Update is called once per frame
    void Update()
    {
        bool prevStatus = grounded;
        grounded = Physics2D.OverlapBox((Vector2)transform.position + bottomOffset, new Vector2(groundCollisionBoxSize, 0.2f), 0, CollisionLayer);
        if (!prevStatus && grounded) {
            LandSound.Play();
            LandEffect.playEffect();
        }
        Wall = Physics2D.OverlapBox((Vector2)transform.position + rightOffset, new Vector2(0.2f, collisionRadius), 0, CollisionLayer) ? 1 : 0;
        Wall = Physics2D.OverlapBox((Vector2)transform.position + leftOffset,  new Vector2(0.2f, collisionRadius), 0, CollisionLayer) ? -1 : Wall;

        onWall = Wall != 0;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireCube((Vector2)transform.position + bottomOffset, new Vector2 (groundCollisionBoxSize, 0.2f));
        Gizmos.DrawWireCube((Vector2)transform.position + rightOffset,  new Vector2(0.2f, collisionRadius));
        Gizmos.DrawWireCube((Vector2)transform.position + leftOffset, new Vector2(0.2f, collisionRadius));

    }
}
