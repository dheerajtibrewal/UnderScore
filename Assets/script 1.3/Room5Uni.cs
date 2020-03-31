using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room5Uni : MonoBehaviour
{

    public GameObject plane1;
    public GameObject plane2;

    void OnMouseDown(){
        
            plane1.SetActive(false);
            plane2.SetActive(false);
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

