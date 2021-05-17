using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    Transform tr_Player;
    public float f_RotSpeed = 3.0f;
    public float f_MoveSpeed = 1.0f;
    public int curHealth = 100;
    public int maxHealth = 100;


    // Start is called before the first frame update
    void Start()
    {
        tr_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(tr_Player.position - transform.position), f_RotSpeed * Time.deltaTime);

        transform.position += transform.forward * f_MoveSpeed * Time.deltaTime;

        if (curHealth <= 0)
        {
            EnemyDie();
        }
        

    }
    void EnemyDie()
    {
        Destroy(gameObject);
    }
}
