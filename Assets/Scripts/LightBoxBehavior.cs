using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBoxBehavior : MonoBehaviour
{
   [Tooltip("The mesh renderer for the object.")]
    private MeshRenderer _meshRenderer;

    [SerializeField]
    [Tooltip("The base color of the object, or the color that will change the color of the boxes around it.")]
    private Color _baseColor, _offset;

    [SerializeField]
    [Range(0, 1)]
    [Tooltip("Determines whether or not the light is on or off.")]
    private int _lightIsOn = 0;

    [SerializeField]
    [Tooltip("The radius around the box that will determine its neighbors.")]
    private RadiusBehavior _radius;

    /// <summary>
    /// Determines whether or not the light is on or off.
    /// </summary>
    public int LightIsOn { get { return _lightIsOn; } }

    /// <summary>
    /// Turns the light on or off depending on its current state.
    /// </summary>
    public void ToggleLight()
    {
        _lightIsOn = (_lightIsOn == 1) ? 0 : 1;
    }

    public void ChangeMaterial(Material other)
    {
        // Gathers the offset from the other color.
        Color newOffset = other.GetColor("_Offset");

        _meshRenderer.material.SetColor("_Offset", _offset + newOffset);
    }

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();

        // Sets the material's colors to the given ones on the box.
        _meshRenderer.material.SetColor("_BaseColor", _baseColor);
        _meshRenderer.material.SetColor("_Offset", _offset);
    }

    private void Update()
    {
        _meshRenderer.material.SetInt("_IsOn", _lightIsOn);
    }

    private void OnMouseDown()
    {
        // Toggles this box's light.
        ToggleLight();  

        // Toggles the nearby boxes' lights.
        _radius.ToggleNearbyLights();
    }
}
