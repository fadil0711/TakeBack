using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public bool locked = true; // Inisialisasi pintu terkunci
    public bool keyPickedUp = false; // Inisialisasi kunci belum diambil
    public Animation doorAnimation;

    private void Start()
    {
        doorAnimation = GetComponent<Animation>(); // Mengambil komponen animasi dari pintu
    }

    private void Update()
    {
        // Jika pintu tidak terkunci, kunci sudah diambil, dan pemain cukup dekat dengan pintu
        if (!locked && keyPickedUp && IsPlayerNearDoor() && Input.GetKeyDown(KeyCode.E))
        {
            doorAnimation.Play(); // Memainkan animasi pintu yang sudah dibuat
            UnlockNewLevel(); // Panggil method untuk membuka level baru
            // Menghapus game object yang memiliki tag "key"
            Destroy(GameObject.FindGameObjectWithTag("key"));
        }
    }

    private bool IsPlayerNearDoor()
    {
        float distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        return distance < 5.0f; // Atur jarak sesuai kebutuhan
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            keyPickedUp = true; // Kunci diambil
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("key"))
        {
            UnlockNewLevel(); // Panggil method untuk membuka level baru
        }
    }

    void UnlockNewLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 1);

        if (currentSceneIndex >= reachedIndex)
        {
            PlayerPrefs.SetInt("ReachedIndex", currentSceneIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
