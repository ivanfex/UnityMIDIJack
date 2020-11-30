using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrumGrow : MonoBehaviour
{
    Vector3 originalScale;
    Vector3 increasedScale;
    [SerializeField] float scaleMultiplier = 1.1f;
    [SerializeField] float scalingSpeed = 0.05f;
    public bool hit;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        increasedScale = transform.localScale * scaleMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localScale = transform.localScale;
        Vector3 scaleFactor = new Vector3(scalingSpeed,scalingSpeed,scalingSpeed) * Time.deltaTime;
        if(hit)
        {
            transform.localScale = transform.localScale + scaleFactor;
            if(localScale.x >= increasedScale.x && localScale.y >= increasedScale.y && localScale.z >= increasedScale.z)
            {
                hit = false;
            }
        }
        else
        {
            if (localScale.x >= originalScale.x && localScale.y >= originalScale.y && localScale.z >= originalScale.z)
            {
                transform.localScale = transform.localScale - (scaleFactor * 2f);
            }
        }
    }

    public void Hit()
    {
        hit = true;
    }
}
