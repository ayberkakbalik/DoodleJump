using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] private Transform doodle;  

    public void LateUpdate()
    {
        if(doodle.position.y > transform.position.y) // E�er Doodle kameradan daha y�ksekteyse
        {
            Vector3 newPosition = new Vector3(transform.position.x, doodle.position.y, transform.position.z);
            transform.position = newPosition;
        }
    }
 
}
