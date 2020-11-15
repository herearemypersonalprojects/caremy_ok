using UnityEngine;

public class DeathZone : MonoBehaviour
{
	public int damageOnCollision = 100;

  private void OnTriggerEnter2D(Collider2D collision)
  {
   	  if (collision.CompareTag("Player"))
   	  {
   	     	  PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);
   	  }
   }
}
