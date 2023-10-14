using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float ballSpeedLeftRight,ballSpeedForward;

    [SerializeField]
    Transform minX, maxX;
    Rigidbody rbBall;

    float axisHorizontal, axisVertical;
    // Start is called before the first frame update
    void Start()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
        StayRoad();
    }
    void MoveBall()
    {
        axisHorizontal = Input.GetAxis("Horizontal");
        axisVertical = Input.GetAxis("Vertical");
        if (axisHorizontal !=0)
        {
            rbBall.velocity = new Vector3(axisHorizontal * ballSpeedLeftRight, rbBall.velocity.y, rbBall.velocity.z);           
        }
        if (axisVertical > 0)
        {
            rbBall.velocity = new Vector3(rbBall.velocity.x, rbBall.velocity.y, axisVertical * ballSpeedForward);
        }

    }
    void StayRoad()
    {
        Vector3 position = transform.position;

        if (transform.position.x > maxX.position.x || transform.position.x < minX.position.x)
        {
            position.x = Mathf.Clamp(position.x, minX.position.x, maxX.position.x);
        }
        transform.position = position;
    }
}
