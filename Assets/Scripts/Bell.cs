using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bell : MonoBehaviour
{
    [SerializeField] Transform targetPosition;

    public bool hit = true;
    [SerializeField] float hitVelocity = 50f;
    GameObject startingObj;
    public bool atStart = true;

    // Start is called before the first frame update
    void Start()
    {
        startingObj = new GameObject("BellHelper");
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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetPosition.rotation, step);

            if (Mathf.Abs(transform.rotation.x - targetPosition.rotation.x) < 0.0001f)
            {
                hit = false;
            }
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, startingObj.transform.rotation, step);
            if (Mathf.Abs(transform.rotation.x - startingObj.transform.rotation.x) < 0.0001f)
            {
                atStart = true;
            }
        }
    }

    public void Hit()
    {
        hit = true;
    }
}
