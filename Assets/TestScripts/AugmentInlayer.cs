using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ARRaycastManager))]

public class AugmentInlayer : MonoBehaviour
{

     GameObject m_PlacedPrefab;
      public GameObject GameObjectToPlace;
      public LayerMask layerMask;

        void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
         
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

     static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();

    ARRaycastManager m_RaycastManager;

     public void GameCode(Vector3 hitPoint){

        GameObjectToPlace.transform.position = hitPoint;
        if (!GameObjectToPlace.activeSelf)
        {
            GameObjectToPlace.SetActive(true);
        }
    }


   public void clickFun(){
         Ray ray = Camera.main.ScreenPointToRay(new Vector3(Camera.main.pixelWidth * 0.5f, Camera.main.pixelHeight * 0.5f, 0f));
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit,500f,layerMask)){
                GameCode(hit.point);
               //  GameObjectToPlace.transform.rotation = Quaternion.identity;

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
