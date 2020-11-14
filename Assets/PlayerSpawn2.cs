using UnityEngine;

public class PlayerSpawn2 : MonoBehaviour
{
	private void Awake()
   {
   	    GameObject.FindGameObjectWithTag("Player").transform.position = transform.position;
   }
}