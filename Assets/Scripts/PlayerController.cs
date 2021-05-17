using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private HUDController hud;

    private Animator anim;
    private List<Weapon> weapons;
    private AudioSource audioSource;
    private Weapon weapon;

    public Camera fpsCam;
    public int impactForce = 1000;
    public ParticleSystem muzzleFlash;
    public AudioClip shootSound;

   // private bool isUsingTools = true;
  

    

    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<Weapon>();
        hud.UpdateWeapon(null);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();


    }

    private void FixedUpdate()
    {
        AnimatorStateInfo info = anim.GetCurrentAnimatorStateInfo(0);

       if (info.IsName("Fire")) anim.SetBool("Fire", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) {
            SwitchWeapon(0);
        }
        else
        {

        }
        if (Input.GetKeyDown("2"))
        {
            SwitchWeapon(1);
        }
        else
        {

        }
        if (Input.GetKeyDown("3"))
        {
            SwitchWeapon(2);
        }
        else
        {

        }
        if (Input.GetKeyDown("4"))
        {
            SwitchWeapon(3);
        }
        else
        {

        }
        if (Input.GetKeyDown("5"))
        {
            SwitchWeapon(4);
        }
        else
        {

        }
        UpdateWeapon();

    }
    private void SwitchWeapon(int index)
    {
        if (index < weapons.Count)
        {
            weapon = weapons[index];
            hud.UpdateWeapon(weapon);
          
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    //Picking up boxes for ammo
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.GetComponent<ItemBox>() != null)
        {
            ItemBox itemBox = otherCollider.gameObject.GetComponent<ItemBox>();

            GiveItem(itemBox.Type, itemBox.Amount);

            Destroy(otherCollider.gameObject);
        }
    }
    
    private void GiveItem (ItemBox.ItemType type, int amount)
    {
        
        //Create a weapon reference
        Weapon currentWeapon = null;

        // Check if we already have an instance of this weapon
        for (int i = 0; i < weapons.Count; i++)
        {
            if (type == ItemBox.ItemType.Pistol && weapons[i] is Pistol) currentWeapon = weapons[i];
            else if (type == ItemBox.ItemType.MachineGun && weapons[i] is MachineGun) currentWeapon = weapons[i];


        }

        // If we dont have a weapon, create one and add to the list
        if (currentWeapon == null)
        {
            if (type == ItemBox.ItemType.Pistol) currentWeapon = new Pistol();
            else if (type == ItemBox.ItemType.MachineGun) currentWeapon = new MachineGun();
            weapons.Add(currentWeapon);
        }

        currentWeapon.AddAmmunition(amount);
        currentWeapon.LoadClip();

        if (currentWeapon == weapon)
        {
            hud.UpdateWeapon(weapon);
        }

        
    } 
    private void UpdateWeapon() 
    {
        if (weapon != null)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                weapon.Reload();
            }
            float timeElapsed = Time.deltaTime;
            bool isPressingTrigger = Input.GetAxis("Fire1") > 0.1f;
            bool hasShot = weapon.Update(timeElapsed, isPressingTrigger);
            hud.UpdateWeapon(weapon);
            
            if (hasShot)
            {
                Shoot();
            }  
        }     
    } 
    private void Shoot()
    {
        Vector3 forward = GameObject.FindGameObjectWithTag("MainCamera").transform.TransformDirection(Vector3.forward);


        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit))
        {
            Debug.Log(hit.transform.name);

            GameObject target = hit.transform.gameObject;

            if(hit.transform.gameObject.tag == "Enemy")
            {
               // target.transform.parent.gameObject.GetComponent<StaticEnemy>().Damage(1);
                print("target hit");
                EnemyAI en = hit.transform.gameObject.GetComponent<EnemyAI>();

                en.curHealth -= 34;
            }
        }
        muzzleFlash.Play();
        PlayShootSound(); // Playing shoot sound effect. Call to method

        anim.CrossFadeInFixedTime("Fire", 0.01f);
        anim.SetBool("Fire", true);

    } 

    private void PlayShootSound()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
    }

 
}
