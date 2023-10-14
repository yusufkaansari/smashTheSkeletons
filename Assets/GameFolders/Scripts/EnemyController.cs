using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    float enemySpeed;

    Rigidbody rbEnemy;
    Animator animator;

    bool isDead=false;

    GameObject behindWall;

    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        behindWall = FindObjectOfType<BallController>().transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead) 
        { 
        MoveForward();
        CrushBehindWall();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !isDead)
        {
                DeadEnemy();
                GameManager.Instance.UpdateKillEnemyNumber();
        }
    }
    void MoveForward()
    {
        rbEnemy.velocity = new Vector3(rbEnemy.velocity.x, rbEnemy.velocity.y, (-1)*enemySpeed);
    }
    void DeadEnemy()
    {
        isDead = true;
        rbEnemy.AddForce(new Vector3(0, 3, 4), ForceMode.Impulse);
        animator.SetBool("IsDead", true);
        Destroy(gameObject, 1.13f);
    }
    void CrushBehindWall()
    {
        if (behindWall !=null)
        {
            if (transform.position.z <= behindWall.transform.position.z)
            {
                DeadEnemy();
            }
        }        
    }
}
