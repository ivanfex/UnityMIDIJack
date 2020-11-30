using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumStick : MonoBehaviour
{
    [SerializeField] Transform targetRotation;
    public bool hit = true;
    [SerializeField] float hitVelocity = 50f;
    GameObject startingObj;
    public bool atStart = true;
    // Start is called before the first frame update
    void Start()
    {
        startingObj = new GameObject("StickHelper");
        Instantiate(startingObj);
        startingObj.transform.position = transform.position;
        startingObj.transform.rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        float step = hitVelocity * Time.deltaTime;
        if(hit)
        {
            atStart = false;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation.rotation, step);
            if (transform.rotation.x == targetRotation.rotation.x)
            {
                hit = false;
                print($"OFF: {transform.name}");
            }
        } else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, startingObj.transform.rotation, step);
            if (Mathf.Abs(transform.rotation.x - startingObj.transform.rotation.x) < 0.0001f)
            {
                atStart = true;
                print($"BACK: {transform.name}");
            }
        }
    }

    public void Hit()
    {
        hit = true;
    }
}
