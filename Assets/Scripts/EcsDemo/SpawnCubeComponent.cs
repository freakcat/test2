using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

public struct SpawnCubeComponent : IComponentData
{
    public int row;
    public int colum;
    public Entity prefab;
}
