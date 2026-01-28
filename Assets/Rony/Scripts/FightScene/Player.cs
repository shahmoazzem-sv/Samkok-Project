using UnityEngine;
using System.Collections.Generic;

using Unity.VisualScripting;
using System.Diagnostics;
public class Player : MonoBehaviour
{
    private List<GameObject> enemyLocations;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    public float speed = 0.0001f;
    Transform original;
    System.Random prng;
    StateMachine stateMachine;
    GameState currentState;

    Enemy targetToAttack;

    public void SetTarget(Enemy target)
    {
        targetToAttack = target;
    }

    public GameState gameState;
    public float life = 100;
    public int hitPoint = 10;
    private float damage;


    void Awake()
    {

    }
    void Start()
    {
        original = transform;
        stateMachine = new StateMachine();
    }


    void Update()
    {
        stateMachine.Update();
    }
    void ChangeState(GameState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }


        switch (currentState)
        {
            case GameState.Start:
                break;
            case GameState.Fight:
                break;
            case GameState.End:
                break;
            default:
                break;
        }
    }
    void Attack(Transform enemyTransform)
    {
        // walk animation
        // anim.SetTrigger("Walk");
        // reach near enemy
        // Transform enemy = GetRandomLocation();
        MoveSelfFromTo(transform, enemyTransform);
        // attack animation
        // anim.SetTrigger("Ult");
        // get back to the original position
        // MoveSelfFromTo(enemy, original);
    }
    void MoveSelfFromTo(Transform a, Transform b)
    {
        transform.position = Vector2.MoveTowards(a.position, b.position, speed * Time.fixedDeltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {

    }
}
