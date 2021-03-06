using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public enum ItemType
    {
        Pistol,
        MachineGun
    }
    [Header("Values")]
    [SerializeField] private ItemType itemType;
    [SerializeField] private int itemAmount;

    [Header("Visuals")]
    [SerializeField] private int rotationAngle;
    [SerializeField] private float verticalRange;
    [SerializeField] private float verticalSpeed;

    public ItemType Type { get { return itemType; } }
    public int Amount { get { return itemAmount; } }


    private GameObject floatingObject;
    private float verticalAngle;

    void Start()
    {
        floatingObject = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        verticalAngle += verticalSpeed * Time.deltaTime;

        floatingObject.transform.Rotate(0, rotationAngle * Time.deltaTime, 0);
        floatingObject.transform.localPosition = new Vector3(
            0,
            Mathf.Cos(verticalAngle) * verticalRange,
            0
            );
    }
}

