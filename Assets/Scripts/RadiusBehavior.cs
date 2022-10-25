using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The nearby boxes that this can influence.")]
    private List<RadiusBehavior> _nearbyBoxes;

    [SerializeField]
    [Tooltip("The box this radius is attached to.")]
    private LightBoxBehavior _attachedBox;

    /// <summary>
    /// The nearby boxes that this can influence.
    /// </summary>
    public List<RadiusBehavior> NearbyBoxes { get { return _nearbyBoxes; } }

    /// <summary>
    /// The box this radius is attached to.
    /// </summary>
    public LightBoxBehavior AttachedBox { get { return _attachedBox; } }

    /// <summary>
    /// Turns each light nearby this light on or off depending on its current state.
    /// </summary>
    public void ToggleNearbyLights()
    {
        // Toggles the light for each nearby box.
        foreach (RadiusBehavior box in _nearbyBoxes)
        {
            box.AttachedBox.ToggleLight();
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
        RadiusBehavior otherRadius;

        // If the other object is another radius...
        if(otherRadius = other.GetComponent<RadiusBehavior>())
            // ...add the object to the list of other boxes.
            _nearbyBoxes.Add(otherRadius);
    }

    private void OnTriggerExit(Collider other)
    {
        RadiusBehavior otherRadius;

        // If the other object is another radius...
        if (otherRadius = other.GetComponent<RadiusBehavior>())
            // ...remove the object to the list of other boxes.
            _nearbyBoxes.Remove(otherRadius);
    }
}
