using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // take player positions
    private List<GameObject> playerLocations;
    [SerializeField] Animator anim;
    [SerializeField] Rigidbody2D rb;
    public GameState gameState;
    Transform original;
    public float life = 100;
    public int hitPoint = 10;
    public float speed = 0.0001f;
    System.Random prng;

    Player targetToAttack;

    public void SetTarget(Player target)
    {
        targetToAttack = target;
    }

    void Awake()
    {
        prng = new System.Random();
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
        switch (gameState)
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
    Transform GetRandomLocation()
    {
        int randomIndex = prng.Next(0, playerLocations.Count);
        return playerLocations[randomIndex].transform;
    }
    void Attack()
    {
        // walk animation
        // anim.SetTrigger("Run");
        // reach near enemy
        Transform enemy = GetRandomLocation();
        MoveSelfFromTo(transform, enemy);
        // attack animation
        // anim.SetTrigger("attack1");
        // get back to the original position
        // MoveSelfFromTo(enemy, original);
    }
    void MoveSelfFromTo(Transform a, Transform b)
    {
        transform.position = Vector2.MoveTowards(a.position, b.position, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Player p = other.gameObject.GetComponent<Player>();
        this.life -= p.hitPoint;
    }
}
