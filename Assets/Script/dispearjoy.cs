using UnityEngine;

public class dispearjoy : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject objectToDestruct;
    public GameObject objectToDetruire;

	void FixedUpdate()
	{
        #if UNITY_STANDALONE_OSX 
        	Destroy(objectToDestroy);
        	Destroy(objectToDestruct);
            Destroy(objectToDetruire);
        #endif

         #if UNITY_STANDALONE_WIN
        	Destroy(objectToDestroy);
        	Destroy(objectToDestruct);
            Destroy(objectToDetruire);
         #endif
	}  
 }