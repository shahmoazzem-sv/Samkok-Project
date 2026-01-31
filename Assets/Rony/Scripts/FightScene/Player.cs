using UnityEngine;
public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    [Header("Enemy")]
    public float speed = 0.0001f;
    StateMachine playerStateMachine;
    EntityState currentState;

    public Enemy targetToAttack;


    public float life = 100;
    public int hitPoint = 10;

    void Start()
    {
        playerStateMachine = new StateMachine();
        ChangeState(EntityState.Idle);
    }


    void Update()
    {
        playerStateMachine.Update();
    }

    // This is the "Event" triggered by the State

    public void ChangeState(EntityState newState)
    {
        if (currentState != newState)
        {
            currentState = newState;
        }


        switch (currentState)
        {
            case EntityState.Idle:
                // Logic for Idle (or make an IdleState class)
                anim.Play("Idle");
                if (targetToAttack != null) ChangeState(EntityState.GotoOpponent);
                break;
            case EntityState.GotoOpponent:
                playerStateMachine.SetState(new PlayerGotoOpponentState(this));
                break;
            case EntityState.Attack:
                playerStateMachine.SetState(new PlayerAttackState(this));
                break;
            case EntityState.Die:
                break;
            default:
                break;
        }
    }
    // Helper function used by the State
    public void MoveSelfFromTo(Transform self, Transform target)
    {
        // Use Time.deltaTime for Update(), Time.fixedDeltaTime for FixedUpdate()
        self.position = Vector2.MoveTowards(self.position, target.position, speed * Time.deltaTime);
    }
    public void TakeDamage(int opponentHitPoint)
    {
        life -= opponentHitPoint;
    }

    public void SetTarget(Enemy target)
    {
        targetToAttack = target;
    }
}
