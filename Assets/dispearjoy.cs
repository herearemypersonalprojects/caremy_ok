using UnityEngine;

public class dispearjoy : MonoBehaviour
{
    public GameObject objectToDestroy;
    public GameObject objectToDestruct;

	void FixedUpdate()
	{
        #if UNITY_STANDALONE_OSX 
        	Destroy(objectToDestroy);
        	Destroy(objectToDestruct);
        #endif

         #if UNITY_STANDALONE_WIN
        	Destroy(objectToDestroy);
        	Destroy(objectToDestruct);
         #endif
	}  
 }