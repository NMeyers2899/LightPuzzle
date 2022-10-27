using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBoxBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The material that represents the light being turned off or on.")]
    private Material _offMaterial, _onMaterial;

    [Tooltip("The mesh renderer for the object.")]
    private MeshRenderer _meshRenderer;

    [SerializeField]
    [Tooltip("Determines whether or not the light is on or off.")]
    private bool _lightIsOn = false;

    [SerializeField]
    [Tooltip("The radius aroudn the box that will determine its neighbors.")]
    private RadiusBehavior _radius;

    /// <summary>
    /// The material that represents the light being turned off or on.
    /// </summary>
    public Material OnMaterial { get { return _onMaterial; } }

    /// <summary>
    /// Determines whether or not the light is on or off.
    /// </summary>
    public bool LightIsOn { get { return _lightIsOn; } }

    /// <summary>
    /// Turns the light on or off depending on its current state.
    /// </summary>
    public void ToggleLight()
    {
        _lightIsOn = !_lightIsOn;
    }

    public void ChangeMaterial(Material other)
    {
        Vector4 newColor = other.GetColor("_BaseColor");

        _onMaterial.SetColor("_BaseColor", newColor);
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
            _meshRenderer.material.SetColor("_BaseColor", Vector4({ 0.0f, 0.0f, 0.0f, 1.0f}));
    }

    private void OnMouseDown()
    {
        // Toggles this box's light.
        ToggleLight();  

        // Toggles the nearby boxes' lights.
        _radius.ToggleNearbyLights();
    }
}
