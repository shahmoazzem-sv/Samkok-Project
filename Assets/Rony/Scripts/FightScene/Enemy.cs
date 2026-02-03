using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] TMP_Text scoreCard;
    EntityState currentState;
    public float life = 100;
    public int hitPoint = 12;
    public float speed = 2f;

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
        scoreCard.gameObject.SetActive(false);
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
                anim.SetTrigger("Idle");
                break;
            case EntityState.GotoOpponent:
                anim.SetTrigger("Run");
                enemyStateMachine.SetState(new EnemyGotoOpponentState(this));
                break;
            case EntityState.Attack:
                anim.SetTrigger("Attack1");
                enemyStateMachine.SetState(new EnemyAttackState(this));
                Debug.Log("Enemy Attack");
                break;
            case EntityState.Die:
                anim.SetTrigger("Die");
                Debug.Log("Enemy Ded");
                // Find game state for winning
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
        Debug.Log("Enemy: " + life);
        life -= opponentHitPoint;
        scoreCard.text = life.ToString();
        StartCoroutine(TakeDamageTextAnimtaion());

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
