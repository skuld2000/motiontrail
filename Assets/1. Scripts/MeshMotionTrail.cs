using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//2021.09.20
//MeshRenderer 기반 오브젝트의 모션트레일

public sealed class MeshMotionTrail : MotionTrailBase
{
    private MeshFilter[] TargetMeshFilterArray { get; set; }
    protected override void Init()
    {
        // 1. Target Meshes
        if (_containChildrenMeshes)
            TargetMeshFilterArray = GetComponentsInChildren<MeshFilter>();
        else
            TargetMeshFilterArray = new[] { GetComponent<MeshFilter>() };

        // 2. Queues
        FaderWaitQueue = new Queue<MotionTrailFaderBase>();
        FaderRunningQueue = new Queue<MotionTrailFaderBase>();

        // 3. Container
        _faderContainer = new GameObject($"{gameObject.name} MotionTrail Container");
        _faderContainer.transform.SetPositionAndRotation(default, default);
        _faderContainer.transform.localScale = transform.localScale;

        _data.Mat = _motionTrailMaterial;
    }

    protected override void SetupFader(out MotionTrailFaderBase fader)
    {
        GameObject faderGo = new GameObject($"{gameObject.name} MotionTrail");
        faderGo.transform.SetParent(_faderContainer.transform);

        fader = faderGo.AddComponent<MeshMotionTrailFader>();
        fader.Setup(TargetMeshFilterArray, _data, this);
    }
}