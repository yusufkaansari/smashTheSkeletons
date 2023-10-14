using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    [SerializeField]
    Transform target;


    [SerializeField]
    float cameraSpeed = 0.05f;

    [SerializeField]
    float offsetX, offsetY, offsetZ;

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        SmoothCamera();
    }
    void SmoothCamera()
    {
        if (target != null)
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x + offsetX, target.position.y + offsetY, target.position.z + offsetZ), cameraSpeed);
        }

    }
}
