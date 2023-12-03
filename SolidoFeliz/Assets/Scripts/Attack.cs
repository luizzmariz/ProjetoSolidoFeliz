using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attackDuration;
    
    void Start()
    {
        //collider2d = GetComponent<Collider2D>();
        Destroy(this.gameObject, attackDuration);
    }

    void Update()
    {
        List<Collider2D> collisors = new List<Collider2D>();
        ContactFilter2D cf2D = new ContactFilter2D();
        if(GetComponent<Collider2D>().OverlapCollider(cf2D, collisors) > 0)
        {
            Debug.Log("Hit something");
        }
    }
}
