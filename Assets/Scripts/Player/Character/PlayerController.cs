using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    public float lastHorizontalInput;
    [HideInInspector] public float lastVerticalInput;
    SpriteRenderer mushroomSR;
    Rigidbody2D mushroomRb2d;
    [HideInInspector] public Vector3 movement;
    [HideInInspector] public Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        mushroomRb2d = GetComponent<Rigidbody2D>();
        movement = new Vector3();
        mushroomSR = GameObject.Find("mushroom").GetComponent<SpriteRenderer>();
        animator = GameObject.Find("mushroom").GetComponent<Animator>();
    }

    private void Start() 
    {
        lastHorizontalInput = 5f;
        lastVerticalInput = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        movement *= speed;
        mushroomRb2d.velocity = movement;

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

        if (movement.x != 0) {
            lastHorizontalInput = movement.x;
        }
        if (movement.y != 0) {
            lastVerticalInput = movement.y;
    }
    }
}
