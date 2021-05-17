using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StaticEnemy : MonoBehaviour //IDamageable 
{
    // [SerializeField] private float health = 100;
    //[SerializeField] private float hitSmoothness;
    public int curHealth = 100;
    public int maxHealth = 100;

   // private float targetScale = 1f;

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

        if (curHealth <= 0)
        {
            EnemyDie();
        }
        /* transform.localScale = new Vector3(
            Mathf.Lerp(transform.localScale.x, targetScale, Time.deltaTime * hitSmoothness),
            Mathf.Lerp(transform.localScale.y, targetScale, Time.deltaTime * hitSmoothness),
            Mathf.Lerp(transform.localScale.z, targetScale, Time.deltaTime * hitSmoothness));
    } */
   // public int Damage(float amount)
     
   /* {
        health -= amount;
        transform.localScale = Vector3.one * 0.90f;
        if (health <= 0)
        {
            targetScale = 0;
            Destroy(gameObject, 1f);
        }
        return 0;    */
   void EnemyDie()
        {
        //    Destroy(hit. gameObject);      
        }
    
    }


  



}
