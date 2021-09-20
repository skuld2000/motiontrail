using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MotionTrailData
{
    [Range(0.1f, 2.0f), Tooltip("잔상 지속 시간")]
    public float duration = 0.5f;

    public string shaderColorName = "_Color";
    public string shaderAlphaName = "_Alpha";

    public Material Mat { get; set; }
}