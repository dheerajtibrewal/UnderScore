using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;
 

/// <summary>
/// Listens for touch events and performs an AR raycast from the screen touch point.
/// AR raycasts will only hit detected trackables like feature points and planes.
///
/// If a raycast hits a trackable, the <see cref="placedPrefab"/> is instantiated
/// and moved to the hit position.
/// </summary>
[RequireComponent(typeof(ARRaycastManager))]
public class Test1AutoPlaceItem : MonoBehaviour
{
    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;

     public Test1ItemPlacerCon ItemPlacedController;
   
    
     public LayerMask layerMask;
 
    public GameObject[] TestingGround;
    public float speed = 3f;
    public bool isPlacing = false;

    public Material planeMaterial;
   
    

    

    void Awake()
    {

        


        m_RaycastManager = GetComponent<ARRaycastManager>();


         if (Application.isEditor)
        {
            for (int i = 0; i < TestingGround.Length; i++)
            {
                TestingGround[i].SetActive(true);
            }
 
        }
    }


     public void GameCode(Vector3 newPos){
       
         if (ItemPlacedController != null)
        {
            if (ItemPlacedController.hasItemBeenPlaced == false)
            {
                isPlacing = true;
                ItemPlacedController.GetGameObjectToPlace().SetActive(true);
                ItemPlacedController.GetGameObjectToPlace().transform.parent = null;
             //  ItemPlacedController.GetGameObjectToPlace().transform.position = newPos;
                ItemPlacedController.GetGameObjectToPlace().transform.position = Vector3.Lerp(ItemPlacedController.GetGameObjectToPlace().transform.position, newPos, Time.deltaTime * speed);
                 
                 Vector3 CameraFlatPos = new Vector3(Camera.main.transform.position.x,newPos.y,Camera.main.transform.position.z);

                ItemPlacedController.GetGameObjectToPlace().transform.LookAt(CameraFlatPos);
                if (!ItemPlacedController.GetGameObjectToPlace().activeSelf)
                {
                    ItemPlacedController.GetGameObjectToPlace().SetActive(true);
                }
            }
        }
    }



    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            var mousePosition = Input.mousePosition;
            touchPosition = new Vector2(mousePosition.x, mousePosition.y);
            return true;
        }
#else
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
#endif

        touchPosition = default;
        return false;
    }

    void Update()
    {   
        if (ItemPlacedController != null)
        {
            
                if(Application.isEditor){
        
                    Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f, 0f));
                    RaycastHit hit;
        
                    if(Physics.Raycast(ray, out hit,500f,layerMask)){
                        GameCode(hit.point);
                  // ItemPlacedController.GetGameObjectToPlace().transform.rotation = Quaternion.identity;

                    //  Debug.Log("Hello0");
        
                    }
        
        
                }else{
        
                    
                    Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f, 0f));
                    RaycastHit hit;
        
                    if(Physics.Raycast(ray, out hit,500f,layerMask)){
                        GameCode(hit.point);
                  // ItemPlacedController.GetGameObjectToPlace().transform.rotation = Quaternion.identity;
                       

                    //  Debug.Log("Hello0");
        
                    }
        
                }
        if (isPlacing == false && ItemPlacedController.hasItemBeenPlaced == false)
            {
                HideItem();

            }else{

                CheckTouchType();

            }

            isPlacing = false;
        }
        
            
 
        
 
    }
 public void CheckTouchType(){


        if(EventSystem.current.IsPointerOverGameObject() ||
            EventSystem.current.currentSelectedGameObject !=null)
        {

            return;
        }



        if(Application.isEditor){

            if(Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray,out hit, 500f, layerMask))
                {
                    TapHasOccured();
                }

            }

        }else{

           if(Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray,out hit, 500f, layerMask))
                {
                    TapHasOccured();
                }

            }


        }


    }

    public void SetPlaneOn(bool isOn){
        Color color = planeMaterial.color;
        if(isOn==true){
            color.a = 0.3f;
        }
        else{
            color.a = 0;
            LineRenderer[]allLines = GetComponentsInChildren<LineRenderer>();
            for(int i = 0; i<allLines.Length;i++)
            {
                Destroy(allLines[i]);
            }
        }
        planeMaterial.color = color;
    }


    public void TapHasOccured(){

        ItemPlacedController.hasItemBeenPlaced = true;
        SetPlaneOn(false);

    }


    public void SetNewGameObjectToPlace(Test1ItemPlacerCon ItemPlacedController){

        ShouldWeHideIt();
        //   ItemPlacedController.GetGameObjectToPlace() = newItem;
        this.ItemPlacedController = ItemPlacedController;
        SetPlaneOn(true);

    }

    public void ShouldWeHideIt(){
        if (ItemPlacedController != null)
        {
            if (ItemPlacedController.hasItemBeenPlaced == false)
            {
                HideItem();
            }
        }

    }

    public void HideItem(){
        if (ItemPlacedController != null)
        {
            ItemPlacedController.GetGameObjectToPlace().SetActive(false);
            ItemPlacedController.GetGameObjectToPlace().transform.parent = Camera.main.transform;
            ItemPlacedController.GetGameObjectToPlace().transform.localPosition = Vector3.zero;
        }
    }

    public void RemoveItemToPlace(){
        ItemPlacedController = null;
        SetPlaneOn(false);

    }

    

    
}
