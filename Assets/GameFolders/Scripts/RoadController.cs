using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{

    float roadSize;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.GetChild(0) != null)
            roadSize = transform.GetChild(0).GetComponent<Renderer>().bounds.size.z * 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            ShiftRoad();
        }
    }

    void ShiftRoad()
    {
        transform.position += new Vector3(0, 0, roadSize);
    }
}
