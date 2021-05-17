using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Focal Point variables")]
    [SerializeField] private GameObject focalPoint;
    [SerializeField] private float focalDistance;
    [SerializeField] private float focalSmoothness;
    [SerializeField] private KeyCode changeFocalSideKey;

    private bool isFocalPointOnLeft = true;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(changeFocalSideKey))
        {
            isFocalPointOnLeft = !isFocalPointOnLeft;
        }

        float targetX = focalDistance * (isFocalPointOnLeft ? -1 : 1);
        float smoothX = Mathf.Lerp(focalPoint.transform.localPosition.x, targetX, focalSmoothness * Time.deltaTime);
        focalPoint.transform.localPosition = new Vector3(smoothX, focalPoint.transform.localPosition.y, focalPoint.transform.localPosition.z);
    }
}
