using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
 
public class RotateSimpleScaleGO : MonoBehaviour {
    public GameObject currentSelected;
 
    public LayerMask layerMask;
 
       // Use this for initialization
    void Start () {
         
    }
     
    // Update is called once per frame
    void LateUpdate () {
        if (EventSystem.current.IsPointerOverGameObject() ||
            EventSystem.current.currentSelectedGameObject != null)
        {
            return;
        }
 
 
        if(Application.isEditor){
 
            if(Input.GetMouseButton(0)){
 
                Ray ray=Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
 
                if(Physics.Raycast(ray,out hit, 500f, layerMask))
                {
                    currentSelected = hit.collider.gameObject.transform.parent.gameObject;
                }
 
            }
 
 
        }else{
 
            if(Input.touchCount ==1){
 
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Began){
 
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
 
                    if(Physics.Raycast(ray,out hit,500f,layerMask)){
 
                        currentSelected = hit.collider.gameObject.transform.parent.gameObject;
                    }
 
 
                }
 
            }else if(Input.touchCount == 2){
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Moved)
                {
                    if(currentSelected!=null){
                         
                        if(currentSelected.activeSelf==true){
                            float pinchAmount = 0;
                            Quaternion desiredRotation = currentSelected.transform.rotation;
 
                            DetectTouchMovement.Calculate();
 
                            if (Mathf.Abs(DetectTouchMovement.pinchDistanceDelta) > 0)
                            { // zoom
                                pinchAmount = DetectTouchMovement.pinchDistanceDelta;
                            }
 
                            if (Mathf.Abs(DetectTouchMovement.turnAngleDelta) > 0)
                            { // rotate
                                Vector3 rotationDeg = Vector3.zero;
                                rotationDeg.y = -DetectTouchMovement.turnAngleDelta;
                                desiredRotation *= Quaternion.Euler(rotationDeg);
                            }
 
                            desiredRotation.x=0;
                            desiredRotation.z = 0;
 
                            // will work:
                            currentSelected.transform.rotation = desiredRotation;
 
                            pinchAmount = pinchAmount * 0.001f;
                            Vector3 newScale = currentSelected.transform.localScale;
 
                            newScale+= pinchAmount * currentSelected.transform.localScale;
 
                            if (newScale.x > 0.2 && newScale.x < 2)
                            {
                                currentSelected.transform.localScale = newScale;
                            }
 
                              
                        }
 
                    }
 
 
                }
 
 
 
            }
 
 
 
 
 
        }
 
 
    }
}