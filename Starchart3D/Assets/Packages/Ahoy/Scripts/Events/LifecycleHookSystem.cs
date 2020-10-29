// using UnityEngine;
// using Unity.Entities;

// namespace Ahoy
// {

//     public class LifecycleHookSystem : ComponentSystem
//     {

//         public AhoyEvent onUpdate;
//         public AhoyEvent onFixedUpdate;

//         protected override void OnCreate()
//         {
//             onUpdate = new AhoyEvent();
//             onFixedUpdate = new AhoyEvent();
//             LifecycleHooks.fixedUpdate.AddListener(OnFixedUpdate);
//         }

//         protected override void OnUpdate()
//         {
//             onUpdate.Invoke();
//         }

//         public void OnFixedUpdate()
//         {
//             onFixedUpdate.Invoke();
//         }
//     }
// }