using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBoxBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The material that represents the light being turned off.")]
    private Material _offMaterial;

    [SerializeField]
    [Tooltip("The material that represents the light being turned on.")]
    private Material _onMaterial;

    [Tooltip("The mesh renderer for the object.")]
    private MeshRenderer _meshRenderer;

    [SerializeField]
    [Tooltip("Determines whether or not the light is on or off.")]
    private bool _lightIsOn = false;

    [SerializeField]
    [Tooltip("The radius aroudn the box that will determine its neighbors.")]
    private RadiusBehavior _radius;

    /// <summary>
    /// Turns the light on or off depending on its current state.
    /// </summary>
    public void ToggleLight()
    {
        _lightIsOn = !_lightIsOn;
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(_lightIsOn)
            _meshRenderer.material = _onMaterial;
        else
            _meshRenderer.material = _offMaterial;
    }

    private void OnMouseDown()
    {
        // Toggles this box's light.
        ToggleLight();  

        // Toggles the nearby boxes' lights.
        _radius.ToggleNearbyLights();
    }
}
