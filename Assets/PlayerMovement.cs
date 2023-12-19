using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 20f; // Kecepatan gerak player

    public static PlayerMovement instance;
    public GameObject key;

    private void Awake() { instance = this; }

    private Rigidbody2D rb; // Rigidbody untuk player
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Mendapatkan komponen Rigidbody2D dari player
    }

    void Update()
    {
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveInputX, moveInputY);
        movement.Normalize();

        rb.velocity = movement * moveSpeed;

        // Mengatur animasi berdasarkan input gerakan
        anim.SetFloat("X", moveInputX);
        anim.SetFloat("Y", moveInputY);
        anim.SetBool("IsMoving", (moveInputX != 0 || moveInputY != 0));
    }
}
