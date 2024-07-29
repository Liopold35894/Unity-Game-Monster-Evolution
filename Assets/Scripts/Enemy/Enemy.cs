using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private float speed = 3.0f;
    private Rigidbody2D enemyRb;
    private GameObject player;
    private Vector2 movement;

    [SerializeField] private int hp = 3;
    [SerializeField] private int damage = 1;
    //no longer needed
    //[SerializeField] int experience_reward = 200;
    private Character targetCharacter;
    private Animator animator;
    
    private void Awake()
    {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = player.transform.position - transform.position;
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        lookDirection.Normalize();
        movement = lookDirection;

        if (movement.x > 0) {
            animator.SetFloat("X", 1);
        }
        
        if (movement.x < 0) {
            animator.SetFloat("X", 0);
        }

        if (movement.x != 0 || movement.y != 0) {
            animator.SetBool("IsWalking", true);
        } else {
            animator.SetBool("IsWalking", false);
        }
    }

    private void FixedUpdate() {
        MoveChracter(movement);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == player) {
            Attack();
        }
    }

    private void Attack()
    {
        if (targetCharacter == null) {
            targetCharacter = player.GetComponent<Character>();
        }
        targetCharacter.TakeDamage(damage);
    }

    private void MoveChracter(Vector2 direction) {
        enemyRb.MovePosition((Vector2) transform.position + (direction * speed * Time.deltaTime));
    }

    public void TakeDamage(int damage) 
    {
        hp -= damage;
        if (hp < 1) {
            //pick up gem to get experience, not from killing enemy
            //player.GetComponent<Level>().AddExperience(experience_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            Destroy(gameObject);
        }
    }
}
