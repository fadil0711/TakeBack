using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
   public Vector2 camMaxChange;
   public Vector2 camMinChange;

   public Vector3 playerChange;

   private CameraFollow cam;

   private void Start()
   {
      cam = Camera.main.GetComponent<CameraFollow>();
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if(other.CompareTag("Player")) // Menggunakan CompareTag untuk memeriksa tag "Player"
      {
         TransitionRoom(other);
      }
   }

   private void TransitionRoom(Collider2D other)
   {
      if (cam != null) // Periksa apakah komponen CameraFollow ada
      {
         cam.minPos += camMinChange;
         cam.maxPos += camMaxChange;
      }
      else
      {
         Debug.LogWarning("CameraFollow component not found on main camera.");
      }

      other.transform.position += playerChange;
   }
}
