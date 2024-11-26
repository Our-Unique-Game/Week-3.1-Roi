using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger2D : MonoBehaviour {
    [Tooltip("Every object tagged with this tag will count toward the destruction of this object")]
    [SerializeField] string triggeringTag;

    [Tooltip("Number of collisions required to destroy the object")]
    [SerializeField] int maxCollisions = 3; 

    private int collisionCount = 0; 

    private SpriteRenderer spriteRenderer;

    private void Start() {
       
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            collisionCount++; 

            Destroy(other.gameObject); 

           
            if (collisionCount < maxCollisions) {
                PerformActionOnCollision(); 
            }

           
            if (collisionCount >= maxCollisions) {
                Destroy(this.gameObject);
            }
        }
    }

    private void PerformActionOnCollision() {
        
        if (spriteRenderer != null) {
            float damageRatio = (float)collisionCount / maxCollisions;
            spriteRenderer.color = Color.Lerp(Color.white, Color.red, damageRatio); 
        }
    }

    private void Update() {
       
    }
}
