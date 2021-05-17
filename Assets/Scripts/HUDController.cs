using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{

    [SerializeField] private RectTransform weaponReloadBar;

    [SerializeField] private Text weaponAmmunitionText;
    [SerializeField] private Text weaponNameText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWeapon(Weapon weapon)
    {
        if (weapon == null)
        {
            weaponNameText.enabled = false;
            weaponAmmunitionText.enabled = false;
            weaponReloadBar.localScale = new Vector3(0, 1, 1);
        } 
        else
        {
            weaponNameText.enabled = true;
            weaponAmmunitionText.enabled = true;

            weaponNameText.text = weapon.Name;
            weaponAmmunitionText.text = weapon.ClipAmmunition + " / " + weapon.TotalAmmunition;

            if (weapon.ReloadTimer > 0)
            {
                weaponReloadBar.localScale = new Vector3(weapon.ReloadTimer / weapon.ReloadDuration, 1, 1);
            }
            else
            {
                weaponReloadBar.localScale = new Vector3(0, 1, 1);

            }
        }
    }
}
