using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using TMPro;

public class ARImageRecognition : MonoBehaviour
{
    public void OnImageRecognized(ARTrackedImage trackedImage)
    {
        if (trackedImage.referenceImage.name == "PETBottle")
        {
            // Display Environmental Impact and add to score
            Debug.Log("Bottle detected: " + trackedImage.referenceImage.name);
            // Add code here to show impact, update score, etc.
        }
    }
}
