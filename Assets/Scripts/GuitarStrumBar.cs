using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarStrumBar : MonoBehaviour
{
    [SerializeField] Transform targetRotation;
    [SerializeField] bool pressed = true;
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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation.rotation, step);
            float diffInRotation = Mathf.Abs(transform.rotation.x - targetRotation.rotation.x);
            print(diffInRotation);
            if(transform.rotation.x == targetRotation.rotation.x)
            {
                print("Match");
                pressed = false;
            }
        } 
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, startingObj.transform.rotation, step);
        }
    }

    public void Strum()
    {
        pressed = true;
    }
}
