using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxBut : MonoBehaviour
{
    public PlaceOnPlane placedscript;
   // public Test1AutoPlaceItem furniture;
   public GameObject[] TestingFurniture;
     bool newnum = false;

  


     void scale(){
         if(newnum == false){
        placedscript.spawnedObject.gameObject.transform.localScale = new Vector3(1,1,1);
       // furniture.ItemPlacedController.GetGameObjectToPlace().gameObject.transform.localScale = new Vector3(1,1,1);
        {
            for (int i = 0; i < TestingFurniture.Length; i++)
            {
                TestingFurniture[i].gameObject.transform.localScale = new Vector3(1f,1f,1f);
            }
 
        }


        newnum = true;
         }
       else if(newnum == true)
        {
          placedscript.spawnedObject.gameObject.transform.localScale = new Vector3(.05f,.05f,.05f);  

        {
            for (int i = 0; i < TestingFurniture.Length; i++)
            {
                TestingFurniture[i].gameObject.transform.localScale = new Vector3(0f,0f,0f);
            }
 
        }

          newnum = false;
        }
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
