using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Rendering;

public struct RenderMesh:IComponentData, ISharedComponentData
{
     public Mesh mesh;
     
     public Material material;

     public int subMesh;

     public ShadowCastingMode castShadows;

     public bool receiveShadows;
}
