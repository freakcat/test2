using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderLabTest : MonoBehaviour
{
    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = GameObject.Find("Quad").GetComponent<MeshRenderer>().material;
         
    }

    // Update is called once per frame
    void Update()
    {
        if (material != null)
        {
            print(material.GetColor("_FilterfColor"));
        }
    }
}
