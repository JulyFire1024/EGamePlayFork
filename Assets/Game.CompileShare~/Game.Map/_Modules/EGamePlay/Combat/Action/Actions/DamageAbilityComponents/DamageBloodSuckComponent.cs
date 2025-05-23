﻿//using ECS;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//namespace EGamePlay.Combat
//{
//    /// <summary>
//    /// 伤害吸血组件
//    /// </summary>
//    public class DamageBloodSuckComponent : EcsComponent
//    {
//        public override void Awake()
//        {
//            var combatEntity = Entity.GetParent<CombatEntity>();
//            combatEntity.ListenActionPoint(ActionPointType.PostExecuteDamage, OnCauseDamage);
//        }

//        private void OnCauseDamage(EcsEntity action)
//        {
//            var damageAction = action as DamageAction;
//            if (damageAction.Target is CombatEntity target)
//            {
//                var value = damageAction.DamageValue * 0.2f;
//                var combatEntity = Entity.GetParent<CombatEntity>();
//                if (combatEntity.CureAbility.TryMakeAction(out var cureAction))
//                {
//                    cureAction.Creator = combatEntity;
//                    cureAction.Target = combatEntity;
//                    cureAction.CureValue = (int)value;
//                    cureAction.SourceAssignAction = null;
//                    cureAction.Execute();
//                }
//            }
//        }
//    }
//}