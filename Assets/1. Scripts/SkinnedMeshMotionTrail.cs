using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2021.09.20
//SkinnedMeshRenderer 기반 캐릭터의 모션트레일

public sealed class SkinnedMeshMotionTrail : MotionTrailBase
{
    private SkinnedMeshRenderer[] TargetSmrArray { get; set; }

    protected override void Init()
    {
        // 1. Target Meshes
        if (_containChildrenMeshes)
            TargetSmrArray = GetComponentsInChildren<SkinnedMeshRenderer>();
        else
            TargetSmrArray = new[] { GetComponent<SkinnedMeshRenderer>() };

        // 2. Queues
        FaderWaitQueue = new Queue<MotionTrailFaderBase>();
        FaderRunningQueue = new Queue<MotionTrailFaderBase>();

        // 3. Container
        _faderContainer = new GameObject($"{gameObject.name} MotionTrail Container");
        _faderContainer.transform.SetPositionAndRotation(default, default);

        _data.Mat = _motionTrailMaterial;
    }

    protected override void SetupFader(out MotionTrailFaderBase fader)
    {
        GameObject faderGo = new GameObject($"{gameObject.name} MotionTrail");
        faderGo.transform.SetParent(_faderContainer.transform);

        fader = faderGo.AddComponent<SkinnedMeshMotionTrailFader>();
        fader.Setup(TargetSmrArray, _data, this);
    }
}