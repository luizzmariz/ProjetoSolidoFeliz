using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStateMachine : StateMachine
{
    [HideInInspector]
    public IdleState idleState;
    [HideInInspector]
    public ChaseState chaseState;

    // [HideInInspector]
    // public Chasing chasingState;

    // [HideInInspector]
    // public Stun stunState;
    // [HideInInspector]
    // public Fallen fallenState;

    // public List<GameObject> targets;
    // public GameObject curTarget;

    //public Rigidbody2D rigidBody;
    
    [Header("Holder Components")]

    public Rigidbody2D rigidBody2D;
    public Pathfinding pathfinding;

    [Header("Base Stats")]

    [Range(0f,10f)] 
    public float rangeOfView;
    [Range(0f,5f)] 
    public float movementSpeed;
    //public Vector2 movementSpeed;
    public float life;
    public float damage;

    [Header("Other's Components")]

    public GameObject playerGameObject;
    public Grid grid;

    private void Awake() {
        GetInfo();

        idleState = new IdleState(this);
        chaseState = new ChaseState(this);
        // stunState = new Stun(this);
        // fallenState = new Fallen(this);
    }

    public void GetInfo()
    {
        playerGameObject = GameObject.Find("Player");
        grid = GameObject.Find("Grid").GetComponent<Grid>();

        rigidBody2D = GetComponent<Rigidbody2D>();
        pathfinding = GetComponent<Pathfinding>();
    }

    protected override BaseState GetInitialState() {
        // targets.AddRange(GameObject.FindGameObjectsWithTag("Ally"));
        // tf = GetComponent<Transform>();
        // chasingState.FindCurrentTarget();
        return idleState;
    }

    // void OnCollisionEnter2D(Collision2D collisionInfo) {
    //     if (collisionInfo.gameObject.tag == "Ally") {
    //         if(collisionInfo.gameObject.GetComponent<NPCAllySM>() != null) {
    //             life -= collisionInfo.gameObject.GetComponent<NPCAllySM>().damage;
    //         } else if(collisionInfo.gameObject.GetComponent<AllyBT>() != null) {
    //             life -= collisionInfo.gameObject.GetComponent<AllyBT>().damage;
    //         }
    //         rigidBody.velocity = new Vector3(0,0,0);
    //         ChangeState(stunState);
    //     }
    //     if (collisionInfo.gameObject.tag == "AllyBaseWall") {
    //         ChangeState(stunState);
    //         rigidBody.velocity = speed*(tf.position -collisionInfo.gameObject.transform.position).normalized/2;
    //     }
    // }

    // void OnTriggerEnter2D(Collider2D collisionInfo) {
    //     if (collisionInfo.gameObject.tag == "Ally" && currentState != fallenState) {
    //         if(collisionInfo.gameObject.GetComponent<NPCAllySM>() != null) {
    //             life -= collisionInfo.gameObject.GetComponent<NPCAllySM>().damage;
    //         } else if(collisionInfo.gameObject.GetComponent<AllyBT>() != null) {
    //             life -= collisionInfo.gameObject.GetComponent<AllyBT>().damage;
    //         }
    //         rigidBody.velocity = 2*speed*(tf.position -collisionInfo.gameObject.transform.position).normalized;
    //         ChangeState(stunState);
    //     }
    // }

    // public void LeaveStun() {
    //     if (currentState != fallenState) {
    //         idleState.UpdateLogic();
    //     }
    // }
    /*
    private void Update() {
        targets.clear();
        targets = new List<GameObject>();
        targets.AddRange(GameObject.FindGameObjectsWithTag("Ally"));
    }*/

    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndArea();
    }
}
