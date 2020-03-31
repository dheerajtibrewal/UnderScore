using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateModel : MonoBehaviour
{
    public Slider slider;
    public PlaceOnPlane placedscripts;

    public void SliderRotatingModel()
    {
       placedscripts.spawnedObject.transform.rotation = Quaternion.Euler(placedscripts.spawnedObject.transform.rotation.x, slider.value, placedscripts.spawnedObject.transform.rotation.z);
    }

}
