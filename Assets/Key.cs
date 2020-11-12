﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 targetPosition;
    [SerializeField] float speed = 1f;
    bool pressed = false;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 reductionVector = new Vector3(0f, 0.5f, 0f);
        startingPosition = transform.position;
        targetPosition = transform.position - reductionVector;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        if(pressed)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            if(transform.position == targetPosition)
            {
                pressed = false;
                print("Bottomed");
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startingPosition, step);
        }            
    }

    public void PressKey()
    {
        pressed = true;
    }
}
