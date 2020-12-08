using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarStrumBar : MonoBehaviour
{
    [SerializeField] Transform targetRotation;
    [SerializeField] bool pressed = false;
    public bool atStart = true;
    [SerializeField] float strumVelocity = 70f;
    GameObject startingObj;
    // Start is called before the first frame update
    void Start()
    {
        startingObj = new GameObject("StrumHelper");
        Instantiate(startingObj);
        startingObj.transform.position = transform.position;
        startingObj.transform.rotation = transform.rotation;
    }

    void Update()
    {
        float step = strumVelocity * Time.deltaTime;
        if(pressed)
        {
            atStart = false;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation.rotation, step);
            if(transform.rotation.x == targetRotation.rotation.x)
            {
                pressed = false;
            }
        } 
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, startingObj.transform.rotation, step);

            if (Mathf.Abs(transform.rotation.x - startingObj.transform.rotation.x) < 0.01f)
            {
                atStart = true;
            }
        }
    }

    public void Strum()
    {
        pressed = true;
    }
}
