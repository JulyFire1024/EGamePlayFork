﻿//using System;
//using System.Collections.Generic;


//namespace EGamePlay
//{
//    public sealed class ECSNode : Entity
//    {
//        public Dictionary<Type, List<Entity>> Entities { get; private set; } = new Dictionary<Type, List<Entity>>();
//        public List<Component> AllComponents { get; private set; } = new List<Component>();
//        public List<UpdateComponent> UpdateComponents { get; private set; } = new List<UpdateComponent>();
//        public static ECSNode Instance { get; private set; }


//        private ECSNode()
//        {
            
//        }

//        public static ECSNode Create()
//        {
//            if (Instance == null)
//            {
//                Instance = new ECSNode();
//#if !NOT_UNITY
//                Instance.AddComponent<GameObjectComponent>();
//                UnityEngine.GameObject.DontDestroyOnLoad(Instance.GetComponent<GameObjectComponent>().GameObject);
//#endif
//            }
//            return Instance;
//        }

//        public static void Destroy()
//        {
//            Destroy(Instance);
//            Instance = null;
//        }

//        public override void Update()
//        {
//            if (AllComponents.Count == 0)
//            {
//                return;
//            }
//            for (int i = AllComponents.Count - 1; i >= 0; i--)
//            {
//                var item = AllComponents[i];
//                if (item.IsDisposed)
//                {
//                    AllComponents.RemoveAt(i);
//                    continue;
//                }
//                if (item.Disable)
//                {
//                    continue;
//                }
//                item.Update();
//            }
//        }

//        public override void FixedUpdate()
//        {
//            if (AllComponents.Count == 0)
//            {
//                return;
//            }
//            for (int i = AllComponents.Count - 1; i >= 0; i--)
//            {
//                var item = AllComponents[i];
//                if (item.IsDisposed)
//                {
//                    AllComponents.RemoveAt(i);
//                    continue;
//                }
//                if (item.Disable)
//                {
//                    continue;
//                }
//                item.FixedUpdate();
//            }
//        }
//    }
//}