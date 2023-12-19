using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
    public int Value = 0; // Jumlah poin yang diberikan saat mengambil koin
    public AudioClip coinSound; // Suara yang akan dimainkan saat mengambil koin
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Pastikan hanya pemain yang bisa mengambil koin
        {
            Destroy(gameObject);
            CoinsUI.instance.IncreaseCoins(Value);
        }
    }
}