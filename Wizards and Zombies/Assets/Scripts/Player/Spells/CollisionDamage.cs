using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    [SerializeField] int dmg;
    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<EnemyHeath>().TakeDamage(dmg);
        Destroy(gameObject);
    }
}
