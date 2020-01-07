using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace EcsDemo
{
    public class HelloWordSystem : ComponentSystem
    {
   
        protected override void OnUpdate()
        {
           Entities.ForEach<HelloWordComponent>(Say);
           
           Entities.ForEach<TestComponentData>(Test);
        }
 

        private static void Say(Entity entity, HelloWordComponent c0)
        {
            var id = entity.Index;
            c0.word = id + "HELLOWORD.......";
        }
        
        private static void Test(Entity entity, TestComponentData c0)
        {
            var id = entity.Index;
            c0._helloWordComponent.word = id + "XXXXX.......";
        }
    }
 
}
