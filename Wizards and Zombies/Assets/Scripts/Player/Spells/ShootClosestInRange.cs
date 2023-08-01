using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootClosestInRange : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] float cooldown;
    [SerializeField] float proyectileSpeed;
    [SerializeField] GameObject proyectile;
    [SerializeField] LayerMask layerMask;
    bool attackLocked = false;
    float attackTime = 0;
    GameObject target;
    // Start is called before the first frame update
    private void Update()
    {
        if (!attackLocked)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, range, layerMask);
            if (colliders.Length > 0)
            {
                Attack(colliders);
            }
        }
        else
        {
            attackTime += Time.deltaTime;
            if (attackTime >= cooldown)
            {
                attackTime -= cooldown;
                attackLocked = false;
            }
        }
    }
    private void Attack(Collider2D[] colliders)
    {
        Vector2 pos2D;
        float closestDist = range;
        float dist;
        target = colliders[0].gameObject;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (i == 0)
            {
                pos2D = colliders[i].gameObject.transform.position - transform.position;
                closestDist = pos2D.magnitude;
                target = colliders[i].gameObject;
            }
            else
            {
                pos2D = colliders[i].gameObject.transform.position - transform.position;
                dist = pos2D.magnitude;
                if (dist < closestDist)
                {
                    closestDist = dist;
                    target = colliders[i].gameObject;
                }
            }
        }
        attackLocked = true;
        GameObject proyectileInstance = Instantiate(proyectile, transform.position, Quaternion.identity);
        pos2D = target.transform.position - transform.position;
        proyectileInstance.GetComponent<Rigidbody2D>().velocity = pos2D.normalized * proyectileSpeed;
    }
}

