using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Transform faceDirectionTransform; 
    public float cooldownTimer;
    [SerializeField] float attackDuration;
    Collider2D attackCollider;
    public float meleeAttackRange;
    public GameObject[] attacks;
    public float playerHeight;
    public Vector2 mousePositionInScreen;
    public Vector3 mousePositionInWorld;
    public Vector3 playerTransformPlusMouse;

    //public GameObject attackGameobject;

    void Start()
    {
        faceDirectionTransform = transform.GetChild(1).GetComponent<Transform>();
        cooldownTimer = 0;
        //attackDuration = 2;
    }

    void Update()
    {
        Vector2 secondLastOrientation = this.gameObject.GetComponent<PlayerMovement>().secondLastOrientation;
        //Vector2 lastOrientation = this.gameObject.GetComponent<PlayerMovement>().lastOrientation;
        //Vector2 orientation = this.gameObject.GetComponent<PlayerMovement>().orientation;

        // mousePositionInScreen = Input.mousePosition;
        // mousePositionInWorld = mousePositionInScreen;
        // mousePositionInWorld.z = 10;
        // mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionInWorld);
        // //playerTransformPlusMouse = mousePositionInWorld.normalized + playerTransform.position;
        // faceDirectionTransform.right = (mousePositionInWorld - faceDirectionTransform.position).normalized;

        //Debug.Log(v3);
        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else
        {
            cooldownTimer = 0;

            if(Input.GetButton("Fire1"))
            {
                mousePositionInScreen = Input.mousePosition;
                mousePositionInWorld = mousePositionInScreen;
                mousePositionInWorld.z = 10;
                mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionInWorld);
                //playerTransformPlusMouse = mousePositionInWorld.normalized + playerTransform.position;
                faceDirectionTransform.right = (mousePositionInWorld - faceDirectionTransform.position).normalized;

                //attackGameobject.SetActive(true);




                //GameObject IntantiatedAttack = Instantiate(attacks[0], Vector3.zero, Quaternion.identity, faceDirectionTransform);

                GameObject IntantiatedAttack = Instantiate(attacks[0], faceDirectionTransform.position, faceDirectionTransform.rotation, faceDirectionTransform);

                IntantiatedAttack.GetComponent<Attack>().attackDuration = attackDuration;

                //IntantiatedAttack.transform.localPosition = Vector3.zero;




                //Instantiate(attacks[0], new Vector3((v3.x - playerTransform.position.x), (v3.y - playerTransform.position.y) + playerHeight, 0).normalized * meleeAttackRange, Quaternion.identity);
                //Instantiate(attacks[0], new Vector3((playerTransform.position.x - v3.x), (playerTransform.position.y - v3.y), 0).normalized, Quaternion.identity);
                cooldownTimer = attackDuration;
                //Debug.Log(new Vector3((v3.x - playerTransform.position.x), (v3.y - playerTransform.position.y) + playerHeight, 0).normalized * meleeAttackRange);
                
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
