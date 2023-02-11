using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FrameRateCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Update()
    {
        _text.text = $"{1 / Time.deltaTime}";
    }
}
