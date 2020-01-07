using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct NoiseHeightComponent : IComponentData
{
    public float waveFactor;
    public float sampleFactor;
}
