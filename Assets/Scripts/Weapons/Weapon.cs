using System.Collections;
using System.Collections.Generic;


public abstract class Weapon
{
    private int totalAmmunition = 0;
    private int clipAmmunition = 0;

    // Weapon settings, which are customizalbe on weapon classes. 
    protected int clipSize = 0;
    protected int maxAmmunition = 0;
    protected float reloadDuration = 0f;
    protected float cooldownDuration = 0f;
    protected bool isAutomatic = false;
    protected string name = "";
    protected int damage = 0;

    private float reloadTimer = 0.0f;
    private float cooldownTimer = 0.0f;
    private bool pressedTrigger = false;

    public int TotalAmmunition { get { return totalAmmunition; } set { totalAmmunition = value; } }
    public int ClipAmmunition { get { return clipAmmunition; } set { clipAmmunition = value; }  }


    public int ClipSize { get { return clipSize; } }
    public int MaxAmmunition { get { return maxAmmunition; } }
    public float ReloadDuration { get { return reloadDuration; } }
    public float CooldownDuration { get { return cooldownDuration; } }
    public bool IsAutomatic { get { return isAutomatic; } }

    public float ReloadTimer { get { return reloadTimer; } }

    public string Name { get { return name; } }


    // The absolute max is the maxAmmunition
    public void AddAmmunition (int amount) 
        {
            totalAmmunition = System.Math.Min(totalAmmunition + amount, maxAmmunition);
        } 
    
    public void LoadClip ()
    {
        int maximumAmmunitionToLoad = clipSize - clipAmmunition;
        int ammunitionToLoad = System.Math.Min(maximumAmmunitionToLoad, totalAmmunition);

        clipAmmunition += ammunitionToLoad;
        totalAmmunition -= ammunitionToLoad;
    }

    public bool Update (float deltaTime, bool isPressingTrigger)
    {
        bool hasShot = false;

        // Cooldown when shooting
        cooldownTimer -= deltaTime;
        if ( cooldownTimer <= 0)
        {
            bool canShoot = false;
            if (isAutomatic) canShoot = isPressingTrigger;
            else if (!pressedTrigger && isPressingTrigger) canShoot = true;
            
            if (canShoot && reloadTimer <= 0.0f)
            {
                cooldownTimer = cooldownDuration;
                if(clipAmmunition > 0)
                {
                    clipAmmunition--;
                    hasShot = true;
                }
                //Automatic reloading
                if (clipAmmunition == 0)
                    
                {
                    Reload();
                }
            }
            pressedTrigger = isPressingTrigger;
        }
        //When realoading
        if(reloadTimer > 0.0f)
        {
            reloadTimer -= deltaTime;
            if (reloadTimer <= 0.0f)
            {
                LoadClip();
            }
        }

        return hasShot;
    }

    public void Reload()
    {
        //Only reloads if the weapon is not currently reloading
        // and the clip is not full
        // and there are more bullets left
        if (reloadTimer <= 0.0f && clipAmmunition < clipSize && totalAmmunition > 0)
        {
            reloadTimer = reloadDuration;
        }
        }   
}
