using System.Collections;
using UnityEngine;

public class BottlePickup : MonoBehaviour
{
    private Animator bottleAnimator;
    private bool isRecycling = false;

    void Start()
    {
        bottleAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)) // Mobile touch or mouse click (for testing)
        {
            Vector2 touchPos = Input.touchCount > 0 ? Input.GetTouch(0).position : (Vector2)Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(touchPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                if (!isRecycling)
                {
                    StartCoroutine(RecycleBottle());
                }
            }
        }
    }
    //coroutine for recycle -- onscreen function??????????
    IEnumerator RecycleBottle()
    {
        isRecycling = true;
        bottleAnimator.SetTrigger("Recycle"); // Trigger the recycling animation
        yield return new WaitForSeconds(1.5f); // Wait for the animation to finish
        Destroy(gameObject); // Remove the bottle
    }
}
