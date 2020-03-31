using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class Test2AutoPlane : MonoBehaviour
{

      static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;

     public GameObject GameObjectToPlace;
     public LayerMask layerMask;

    public GameObject[] TestingGround;
    
    public bool isPlacing = false;
     public float speed = 3f;
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
 
       isPlacing = true;
        GameObjectToPlace.SetActive(true);
        GameObjectToPlace.transform.parent = null;
        //GameObjectToPlace.transform.position = newPos;
        GameObjectToPlace.transform.position = Vector3.Lerp(GameObjectToPlace.transform.position, newPos, Time.deltaTime * speed);
        if (!GameObjectToPlace.activeSelf)
        {
            GameObjectToPlace.SetActive(true);
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

         if(Application.isEditor){

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f, 0f));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit,500f,layerMask)){
                GameCode(hit.point);
                GameObjectToPlace.transform.rotation = Quaternion.identity;

            }


        }else{

            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f, 0f));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit,500f,layerMask)){
                GameCode(hit.point);
                 GameObjectToPlace.transform.rotation = Quaternion.identity;

        }
           

       

    
       
 


    }

          
       if(isPlacing==false){
            GameObjectToPlace.SetActive(false);
            GameObjectToPlace.transform.parent = Camera.main.transform;
            GameObjectToPlace.transform.localPosition = Vector3.zero;
 
        }
 
        isPlacing = false;
    }

  
}
