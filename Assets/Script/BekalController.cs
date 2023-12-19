using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BekalController : MonoBehaviour
{
    [SerializeField] GameObject player;
    //[SerializeField] GameObject door;

    private bool isPickedUp;
    private Vector2 vel;
    public float smoothTime;

    // Start is called before the first frame update
    void Start()
    {
        isPickedUp = false; // bekal belum diambil saat permainan dimulai
    }

    // Update is called once per frame
    void Update()
    {
        if (isPickedUp)
        {
            Vector3 offset = new Vector3(0, 1.7f, 0);
            transform.position = Vector2.SmoothDamp(transform.position, player.transform.position + offset, ref vel, smoothTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true; // bekal diambil oleh pemain
           // door.GetComponent<door>().bekalPickedUp = true; // Informasikan ke pintu bahwa bekal diambil
            /*            gameObject.SetActive(false); */// Sembunyikan bekal setelah diambil
        }
    }
}