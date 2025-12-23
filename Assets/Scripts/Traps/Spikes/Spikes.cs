using UnityEngine;

public class Spikes : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.gameObject.tag == "Player")
      {
         GameManager.instance.playerLife--;
      }
   }
}
