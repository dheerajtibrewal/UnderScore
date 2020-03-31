using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalWallOutside : MonoBehaviour
{

    public GameObject plane1;
    public GameObject plane2;
    public GameObject plane3;

    void OnMouseDown(){
        
            plane1.SetActive(false);
            plane2.SetActive(false);
            plane3.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

