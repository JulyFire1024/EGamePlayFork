﻿using ECS;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EGamePlay.Combat
{
    /// <summary>
    /// 行动禁制效果组件
    /// </summary>
    public class EffectActionControlComponent : EcsComponent/*, IEffectTriggerSystem*/
    {
        //public override bool DefaultEnable => false;
        public ActionControlEffect ActionControlEffect { get; set; }
        public ActionControlType ActionControlType { get; set; }


        //public override void Awake()
        //{
        //    ActionControlEffect = GetEntity<AbilityEffect>().EffectConfig as ActionControlEffect;
        //}

        //public override void OnEnable()
        //{
        //    //Log.Debug($"EffectActionControlComponent OnEnable {Entity.GetParent<Ability>().Config.KeyName}");
        //    Entity.Parent.Parent.GetComponent<StatusComponent>().OnStatusesChanged(Entity.GetParent<Ability>());
        //}

        //public override void OnDisable()
        //{
        //    Entity.Parent.Parent.GetComponent<StatusComponent>().OnStatusesChanged(Entity.GetParent<Ability>());
        //}

        //public void OnTriggerApplyEffect(Entity effectAssign)
        //{
        //    Enable = true;
        //}
    }
}