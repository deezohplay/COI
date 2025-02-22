using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PetPick : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject recycledBottle;
    private Animator bottleAnimator;

    // You can assign this in the Inspector
    public GameObject bottlePrefab; // Your PET bottle prefab
    public float maxDistance = 0.2f; // The maximum distance from the camera where the bottle can be picked up

    void Start()
    {
        // Get AR Raycast Manager to perform raycasting
        raycastManager = FindObjectOfType<ARRaycastManager>();

        // Get the bottle prefab and animator (you'll need to attach this animation component to the bottle)
        recycledBottle = Instantiate(bottlePrefab);
        bottleAnimator = recycledBottle.GetComponent<Animator>();
    }

    void Update()
    {
        // Detect touch (on mobile) or mouse click (for testing in Editor)
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the touch position or mouse position
            Vector2 touchPos = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;

            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, maxDistance))
            {
                if (hitInfo.collider.gameObject.CompareTag("PETBottle"))
                {
                    // If the bottle is touched, trigger recycling animation
                    TriggerRecyclingAnimation();
                }
            }
        }
    }
    
    private void TriggerRecyclingAnimation()
    {
        // Trigger the recycling animation on the bottle (you can use any animation you like)
        bottleAnimator.SetTrigger("Recycle");

        // For example, make the bottle shrink and disappear (simulating it being recycled)
        // You can play any animation (scale change, color change, etc.)
        Debug.Log("Recycling triggered for: " + recycledBottle.name);
    }
}
