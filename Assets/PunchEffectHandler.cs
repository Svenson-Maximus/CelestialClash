using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchEffectHandler : MonoBehaviour
{
    public GameObject flamethrowerPrefab; // Drag the flamethrower prefab here in the inspector
    private GameObject currentEffectInstance;

    public Transform rightHandTransform; // Reference to the right hand bone transform

    private float flamethrowerDelay = 0.6f; // Shortened delay

    // Call this method when you detect a punch.
    public void HandlePunch()
    {
        Invoke("ActivateFlamethrowerEffect", flamethrowerDelay);
    }

    // This method will be called from an animation event or through HandlePunch after a delay
    public void ActivateFlamethrowerEffect()
    {
        if (currentEffectInstance != null)
        {
            Destroy(currentEffectInstance); // Destroy the previous effect instance if it exists
        }

        // Instantiate the prefab at the position of the right hand and align its forward direction with the camera's forward direction.
        // No longer setting it as a child to the hand.
        currentEffectInstance = Instantiate(flamethrowerPrefab, rightHandTransform.position, Camera.main.transform.rotation);
    }

    public void DeactivateFlamethrowerEffect()
    {
        if (currentEffectInstance != null)
        {
            Destroy(currentEffectInstance);
        }
    }
}
