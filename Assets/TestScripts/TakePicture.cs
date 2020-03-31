using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakePicture : MonoBehaviour {

    public GameObject CanvasToHide;
     public GameObject Animation;

    public void ButtonPressed(){

        CanvasToHide.SetActive(false);
        Animation.SetActive(false);

         StartCoroutine(TakeScreenshotAndSave());

    }

    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // Save the screenshot to Gallery/Photos
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, "GalleryTest", "My img {0}.png"));

        // To avoid memory leaks
        Destroy(ss);
        CanvasToHide.SetActive(true);
    }

    private void RecordVideo()
    {
        NativeCamera.Permission permission = NativeCamera.RecordVideo((path) =>
        {
            //textUIValue.text = "Video path: " + path;

            Debug.Log("Video path: " + path);
            if (path != null)
            {
                // Play the recorded video
                Handheld.PlayFullScreenMovie("file://" + path);
            }
        });

        Debug.Log("Permission result: " + permission);
    }

    private void PickVideo()
    {
        NativeGallery.Permission permission = NativeGallery.GetVideoFromGallery((path) =>
        {
            Debug.Log("Video path: " + path);
            if (path != null)
            {
                // Play the selected video
                Handheld.PlayFullScreenMovie("file://" + path);
            }
        }, "Select a video");

        Debug.Log("Permission result: " + permission);
        CanvasToHide.SetActive(true);
    }

}
