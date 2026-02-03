using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityTimer;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private TMP_Text scoreCard;

    [Header("Enemy")]
    public float speed = 1f;
    StateMachine playerStateMachine;
    EntityState currentState;

    public Enemy targetToAttack;


    public float life = 100;
    public int hitPoint = 13;
    public bool isDead = false;

    void Start()
    {
        playerStateMachine = new StateMachine();
        ChangeState(EntityState.Idle);
        scoreCard.gameObject.SetActive(false);
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
                anim.SetTrigger("Idle");
                break;
            case EntityState.GotoOpponent:
                anim.SetTrigger("Run");
                playerStateMachine.SetState(new PlayerGotoOpponentState(this));
                break;
            case EntityState.Attack:
                anim.SetTrigger("Attack");
                playerStateMachine.SetState(new PlayerAttackState(this));
                break;
            case EntityState.Die:
                anim.SetTrigger("Die");
                Debug.Log("Player Ded");
                break;
            default:
                break;
        }
    }
    // Helper function used by the State
    public void MoveSelfFromTo(Transform a, Transform b)
    {
        // Use Time.deltaTime for Update(), Time.fixedDeltaTime for FixedUpdate()
        a.position = Vector2.MoveTowards(a.position, b.position, speed * Time.deltaTime);
    }
    public void TakeDamage(int opponentHitPoint)
    {
        life -= opponentHitPoint;
        StartCoroutine(TakeDamageTextAnimtaion());
    }
    public void SetTarget(Enemy target)
    {
        targetToAttack = target;
    }

    IEnumerator TakeDamageTextAnimtaion()
    {
        scoreCard.gameObject.SetActive(true);
        scoreCard.text = life.ToString();

        Vector3 startPosition = scoreCard.transform.position;
        Vector3 targetPosition = startPosition + Vector3.up * 2f;

        float elapsed = 0f;
        float duration = 0.75f; // Total time of the animation

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            // Calculate normalized time (0 to 1)
            float t = elapsed / duration;

            // Apply "Ease Out" effect (Starts fast, slows down at the end)
            // Formula: 1 - (1 - t) * (1 - t)
            float easedT = 1f - (1f - t) * (1f - t);

            // Apply the position
            scoreCard.transform.position = Vector3.Lerp(startPosition, targetPosition, easedT);

            // Wait for the next frame
            yield return null;
        }

        // Cleanup
        scoreCard.gameObject.SetActive(false);
        scoreCard.transform.position = startPosition;
    }
}
