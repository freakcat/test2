using System;
using Unity.Entities;
using UnityEngine;

namespace EcsDemo
{
    public class HelloWordComponent : MonoBehaviour
    {
        public string word;
    }
 
    public class TestComponentData : IComponentData, ISharedComponentData
    {
        public HelloWordComponent _helloWordComponent;
    }
 
}
