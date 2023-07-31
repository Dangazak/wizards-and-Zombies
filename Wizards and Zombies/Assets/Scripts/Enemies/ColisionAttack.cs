using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionAttack : MonoBehaviour
{
    [SerializeField] int dmg;
    [SerializeField] float attackDelay;
    float attackTime;
    bool attackReady;
    // Start is called before the first frame update
    void Start()
    {
        attackTime = 0;
        attackReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!attackReady)
        {
            attackTime += Time.deltaTime;
            if (attackTime >= attackDelay)
            {
                attackTime -= attackDelay;
                attackReady = true;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && attackReady)
        {

            HitPlayer(other.gameObject);

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            HitPlayer(other.gameObject);

        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            attackReady = true;
            attackTime = 0;
        }
    }
    private void HitPlayer(GameObject player)
    {

        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        playerStats.TakeDamage(dmg);
        attackReady = false;

    }
}
