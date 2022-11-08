using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomPlaneBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("All of the Light Boxes in the current scene.")]
    private List<LightBoxBehavior> _boxes;

    [Tooltip("The mesh renderer for the object.")]
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        // Grabs the plane's offset.
        Color offset = _meshRenderer.material.GetColor("_Offset");

        // Each box adds its own offset to the plane's.
        foreach (LightBoxBehavior box in _boxes)
            offset += box.Offset;

        // Normalize the offset.
        offset = ((Vector4)offset).normalized;

        // Set the plane's offset to the new offset.
        _meshRenderer.material.SetColor("_Offset", offset);
    }
}
