using System.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARImageBottleSpawner : MonoBehaviour
{
    public GameObject bottlePrefab; // Assign the PET bottle prefab in the Inspector
    private ARTrackedImageManager imageManager;
    private GameObject spawnedBottle;

    void Awake()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        imageManager.trackedImagesChanged += OnImageChanged;
    }

    void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnImageChanged;
    }

    void OnImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            SpawnBottle(trackedImage);
        }
    }

    void SpawnBottle(ARTrackedImage trackedImage)
    {
        if (spawnedBottle == null) // Ensure only one bottle is spawned per detected image
        {
            spawnedBottle = Instantiate(bottlePrefab, trackedImage.transform.position, Quaternion.identity);
            spawnedBottle.tag = "PETBottle"; // Assign tag for touch detection
        }
    }
}
