using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Transform playerTransform; 
    public float cooldownTimer;
    [SerializeField] float attackDuration;
    Collider2D attackCollider;
    public float meleeAttackRange;
    public GameObject[] attacks;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        cooldownTimer = 0;
        //attackDuration = 2;
    }

    void Update()
    {
        Vector2 secondLastOrientation = this.gameObject.GetComponent<PlayerMovement>().secondLastOrientation;
        Vector2 lastOrientation = this.gameObject.GetComponent<PlayerMovement>().lastOrientation;
        Vector2 orientation = this.gameObject.GetComponent<PlayerMovement>().orientation;

        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            cooldownTimer = 0;
            if(Input.GetButton("Fire1"))
            {
                Instantiate(attacks[0], new Vector3(playerTransform.position.x + secondLastOrientation.x * meleeAttackRange, playerTransform.position.y + secondLastOrientation.y * meleeAttackRange, 0), Quaternion.identity);
                cooldownTimer = attackDuration;
                // Collider2D[] entitiesAttacked;
                // attackCollider.OverlapCollider(ContactFilter2D.NoFilter, entitiesAttacked);
                // if(entitiesAttacked != null)
                // {
                //     Debug.Log("Hit something");
                // }
            }
        }
    }
}
