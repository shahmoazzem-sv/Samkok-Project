using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // take player positions
    private List<GameObject> playerLocations;
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    EntityState currentState;
    Transform original;
    public float life = 100;
    public int hitPoint = 10;
    public float speed = 0.0001f;

    public Player targetToAttack;
    StateMachine enemyStateMachine;

    public void SetTarget(Player target) // on enter do this
    {
        targetToAttack = target;
    }

    void Awake()
    {
        enemyStateMachine = new StateMachine();
    }
    void Start()
    {
        PlayerPositions p = FindFirstObjectByType<PlayerPositions>().GetComponent<PlayerPositions>();
        playerLocations = p.playerLocations;
        original = transform;
    }
    // Update is called once per frame
    void Update()
    {
        enemyStateMachine.Update();
    }
    public void ChangeState(EntityState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }
        switch (currentState)
        {
            case EntityState.Idle:
                Debug.Log("In debug mode");
                // anim.Play("Idle");
                break;
            case EntityState.GotoOpponent:
                enemyStateMachine.SetState(new EnemyGotoOpponentState(this));
                break;
            case EntityState.Attack:
                // Attack();
                Debug.Log("Attack!!!!!!");
                break;
            case EntityState.Die:
                break;
            default:
                break;
        }
    }
    public void MoveSelfFromTo(Transform a, Transform b)
    {
        transform.position = Vector2.MoveTowards(a.position, b.position, speed * Time.deltaTime);
    }
    public void TakeDamage(int opponentHitPoint)
    {
        life -= opponentHitPoint;
    }
}
