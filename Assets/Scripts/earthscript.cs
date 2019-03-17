using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class earthscript : MonoBehaviour
{

   
    public float orbitDistance = 10.0f;
    public float rotateSpeed = 315.0f*3.0f;
    public float orbitSpeed = 1.0f;

    private float orbitRate;
    private float twoPi = Mathf.PI * 2f/10.0f;

    // Use this for initialization
    void Start()
    { 
        orbitRate = orbitSpeed * twoPi;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //pos = transform.root.gameObject;
        transform.localPosition = new Vector3( 
            orbitDistance * Mathf.Cos( orbitRate * Time.time), 
            0, 
            orbitDistance * Mathf.Sin(orbitRate * Time.time) ); 

            transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
    }
}


