using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The background that will fade in upon level completion.")]
    private Image _background;

    [SerializeField]
    [Tooltip("The text displayed when a level is completed.")]
    private Text _winText;

    [Tooltip("Checks to see if the win screen should fade in.")]
    private bool _fadeInWinScreen;

    [SerializeField]
    [Tooltip("How fast the win screen fades in upon level completion.")]
    private float _fadeInSpeed;

    private float _currentLerp;

    private float _time;

    /// <summary>
    /// Checks to see if the win screen should fade in.
    /// </summary>
    public bool FadeInWinScreen { get { return _fadeInWinScreen; } set { _fadeInWinScreen = value; } }

    private void Update()
    {
        _currentLerp = Mathf.Lerp(0, 1, _time += _fadeInSpeed * Time.deltaTime);
        
        if (_fadeInWinScreen)
            _background.color = new Vector4(_background.color.r, _background.color.g, _background.color.b, _currentLerp);
    }
}
