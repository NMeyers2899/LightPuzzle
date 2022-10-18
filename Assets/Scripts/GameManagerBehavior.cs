using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The material that denotes light boxes as on.")]
    private Material _onMaterial;

    [SerializeField]
    [Tooltip("The boxes in the current scene.")]
    private List<LightBoxBehavior> _boxes;

    [SerializeField]
    [Tooltip("The screen that appears when the player completes a level.")]
    private Canvas _winScreen;

    [Tooltip("Checks to see every box in the scene has its on material.")]
    private bool _levelCompleted = false;

    private void Update()
    {
        if (_levelCompleted)
        {
            _winScreen.enabled = true;
            return;
        }

        foreach (LightBoxBehavior box in _boxes)
        {
            // If any box in the scene does not have the on material, the level is not complete.
            if (!box.LightIsOn)
                return;       
        }

        _levelCompleted = true;
    }
}
