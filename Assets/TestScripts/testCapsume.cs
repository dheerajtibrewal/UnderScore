using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCapsume : MonoBehaviour
{

    public GameObject capsule;

    public void click(){
        capsule.SetActive(true);
    }

    void OnMouseDown() {
       capsule.SetActive(true); 
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
