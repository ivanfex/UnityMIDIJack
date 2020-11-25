using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarKey : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 targetPosition;
    [SerializeField] float speed = 1f;
    bool pressed = false;
    float keyVelocity = 1f;
    [SerializeField] Vector3 reductionVector = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.localPosition;
        targetPosition = transform.localPosition - reductionVector;
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime * keyVelocity; // calculate distance to move
        if (pressed)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, step);
            if (transform.localPosition == targetPosition)
            {
                pressed = false;
            }
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startingPosition, step);
        }
    }

    public void PressKey(float pressVelocity)
    {
        pressed = true;
        //print($"Pressed at: {pressVelocity}");
        if (pressVelocity < 0.3f)
        {
            keyVelocity = 0.3f;
        }
        else
        {
            keyVelocity = pressVelocity;
        }
    }
}
