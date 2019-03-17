using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class planetarySystem : MonoBehaviour {



    Texture2D thisTexture;
  
    
    public GameObject[] planets = new GameObject[10];

    private string[] mnames = { "Mercury", "Venus", "Earth", "Moon", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune", "Pluto" };
    private float[] planetSizes = { 0.383f, 0.949f, 1.0f, 0.2724f, 0.532f, 11.21f, 9.45f, 4.01f, 3.88f, 0.186f };
    private float[] rotationRates = { 58.8f, -244.0f, 1.0f, 27.4f, 1.03f, 0.415f, 0.445f, -0.720f, 0.673f, 6.41f };
    private float[] orbitalDistance = { 0.387f, 0.723f, 1.0f, 0.00257f, 1.52f, 5.20f, 9.58f, 19.20f, 30.05f, 39.48f };
    private float[] orbitalSpeed = { 0.241f, 0.615f, 1.0f, 0.0748f, 1.88f, 11.9f, 29.4f, 83.7f, 163.7f, 247.9f };

    // Use this for initialization
    void Start() {

        float y, xl;
        float dx;
        float  ds;
        y = -7.0f;
        xl = 4.0f;
        dx = 0.0f;

        for (int x = 0; x < 10; x++)
            {

      

            ds = planetSizes[x];
            planets[x] = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            planets[x].AddComponent<Rigidbody>();
            planets[x].GetComponent<Rigidbody>().useGravity = false;
            planets[x].transform.position = new Vector3(xl, y);
            planets[x].transform.localScale = new Vector3(ds, ds, ds);
            planets[x].name = mnames[x];

            //Debug.Log(cube);
            Texture2D mytexture = Resources.Load(mnames[x]) as Texture2D;
            planets[x].GetComponent<Renderer>().material.mainTexture = mytexture;

            if (x < 10) { 
            dx =  0.5f * (planetSizes[x] + planetSizes[x + 1]) ; }
            else { 
            dx = planetSizes[x]; }
            //ds = diameterScale * planetSizes[x];
            xl = xl + dx *  1.3f;
            
        }


}
void LateUpdate() {
        float rotateSpeed;
        for (int x = 0; x < 10; x++)
        {
            //pos = transform.root.gameObject;
            // transform.localPosition = new Vector3(
            //    orbitDistance * Mathf.Cos(orbitRate * Time.time),
            //    0,
            //    orbitDistance * Mathf.Sin(orbitRate * Time.time));

            rotateSpeed = 6.28f *10 / rotationRates[x];
            planets[x].transform.Rotate(transform.up * rotateSpeed * Time.deltaTime);
        }

    }



    // Update is called once per frame
    void Update () {
		
	}
}
