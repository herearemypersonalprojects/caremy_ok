using UnityEngine;

public class DeathZone : MonoBehaviour
{
	private Transform playerSpawn;

  private void Awake()
  {
       playerSpawn = GameObject.FindWithTag("PlayerSpawn").transform;
  }
    private void OnTriggerEnter2D(Collider2D collision)
  {
   	  if (collision.CompareTag("Player"))
   	     {
   	     	  collision.transform.position = playerSpawn.position;
   	  }
   }
}
