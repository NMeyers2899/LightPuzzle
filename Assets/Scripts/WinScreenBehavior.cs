using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class WinScreenBehavior : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The background that will fade in upon level completion.")]
    private Background _background;

    [SerializeField]
    [Tooltip("The text displayed when a level is completed.")]
    private Text _winText;
}
