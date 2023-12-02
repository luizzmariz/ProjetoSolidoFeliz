using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //Collider2D collider2d;
    
    void Start()
    {
        //collider2d = GetComponent<Collider2D>();
        Destroy(this.gameObject, 0.75f);
    }

    void Update()
    {
        // Collider2D[] collisors = new Collider2D[];
        // if(GetComponent<Collider2D>().OverlapCollider(new ContactFilter2D.NoFilter, collisors) > 0)
        // {
        //     Debug.Log("Hit something");
        // }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision != null)
        {
            Debug.Log("Hit someone");
        }
    }
}
