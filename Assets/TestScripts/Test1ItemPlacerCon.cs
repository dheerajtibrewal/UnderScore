using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1ItemPlacerCon : MonoBehaviour
{
    public bool hasItemBeenPlaced = false;
    public GameObject ItemToSetIntoPlacer;
    public Test1AutoPlaceItem PlacerScript;

    void Start()
    {
        if (hasItemBeenPlaced == false)
        {

            ItemToSetIntoPlacer.SetActive(false);
        }
 
    }

     public void ButtonClicked(){

         if(hasItemBeenPlaced == false){

            if(PlacerScript.ItemPlacedController!=this){
                PlacerScript.SetNewGameObjectToPlace(this);

            }else{

                PutItemAway();
            }






        }else{
            PutItemAway();
        }



            
                
            }


     public GameObject GetGameObjectToPlace(){
        return ItemToSetIntoPlacer;
    }


    public void PutItemAway(){
        PlacerScript.SetNewGameObjectToPlace(this);
        hasItemBeenPlaced = false;
        PlacerScript.HideItem();
        PlacerScript.RemoveItemToPlace();

    }






        
        


    





}
