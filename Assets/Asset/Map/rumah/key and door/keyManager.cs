using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KeyManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject door;

    private bool isPickedUp;
    private Vector2 vel;
    public float smoothTime;

    // Start is called before the first frame update
    void Start()
    {
        isPickedUp = false; // Kunci belum diambil saat permainan dimulai
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
            UnlockedNewLevel();
            isPickedUp = true; // Kunci diambil oleh pemain
            PlayerController.instance.key = this.gameObject;
            door.GetComponent<door>().keyPickedUp = true; // Informasikan ke pintu bahwa kunci diambil
            /*            gameObject.SetActive(false); */// Sembunyikan kunci setelah diambil
        }
    }

    void UnlockedNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
