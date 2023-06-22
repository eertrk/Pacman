using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform target;
    
    [SerializeField] float cameraSpeed;
    
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x + 5f, transform.position.y, transform.position.z), cameraSpeed);
    }
}
