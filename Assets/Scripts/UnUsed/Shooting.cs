using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    private Weapon weapon;
    public Camera fpsCam;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot()
    {
        Vector3 forward = GameObject.FindGameObjectWithTag("MainCamera").transform.TransformDirection(Vector3.forward);


        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            GameObject target = hit.transform.gameObject;

            if (hit.transform.gameObject.tag == "Enemy")
            {
                // target.transform.parent.gameObject.GetComponent<StaticEnemy>().Damage(1);
                print("target hit");
                EnemyAI en = hit.transform.gameObject.GetComponent<EnemyAI>();

                en.curHealth -= 34;
            }
        }
        anim.SetBool("fire1", true);
    }
}
