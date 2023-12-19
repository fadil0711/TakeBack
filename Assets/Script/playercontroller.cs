using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f; // Kecepatan gerak player
    public static PlayerController instance;
    public GameObject key;
    public GameObject bekal;
    public Animator anim;
    public GameObject door;

    private Rigidbody2D rb; // Rigidbody untuk player
    private void Awake() { instance = this; }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Mendapatkan komponen Rigidbody2D dari player
    }

    void Update()
    {
        // Mendapatkan input horizontal dan vertical dari axis (default: arrow keys atau WASD)
        float moveInputX = Input.GetAxis("Horizontal");
        float moveInputY = Input.GetAxis("Vertical");

        // Menentukan vektor gerak berdasarkan input
        Vector2 movement = new Vector2(moveInputX, moveInputY);

        // Normalisasi vektor agar player tidak bergerak lebih cepat saat bergerak diagonal
        movement.Normalize();

        // Gerakkan player menggunakan Rigidbody berdasarkan vektor gerak
        rb.velocity = movement * moveSpeed;

        // Mengatur animasi berdasarkan input gerakan
        anim.SetFloat("X", moveInputX);
        anim.SetFloat("Y", moveInputY);
        anim.SetBool("IsMoving", (moveInputX != 0 || moveInputY != 0));
    }
}
