using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtils;
using ECS;
using EGamePlay.Combat;
using System;
using ET;

namespace EGamePlay
{
    public class AbilityEffectSystem : AEntitySystem<AbilityEffect>,
        IAwake<AbilityEffect>,
        IEnable<AbilityEffect>,
        IDisable<AbilityEffect>,
        IDestroy<AbilityEffect>
    {
        public void Awake(AbilityEffect entity)
        {
            entity.Name = entity.EffectConfig.GetType().Name;

            /// �ж�����
            if (entity.EffectConfig is ActionControlEffect) entity.AddComponent<EffectActionControlComponent>();
            /// ��������
            if (entity.EffectConfig is AttributeModifyEffect) entity.AddComponent<EffectAttributeModifyComponent>();

            /// �˺�Ч��
            if (entity.EffectConfig is DamageEffect) entity.AddComponent<EffectDamageComponent>();
            /// ����Ч��
            if (entity.EffectConfig is CureEffect) entity.AddComponent<EffectCureComponent>();
            /// ��ܷ���Ч��
            if (entity.EffectConfig is ShieldDefenseEffect) entity.AddComponent<EffectShieldDefenseComponent>();
            /// ʩ��״̬Ч��
            if (entity.EffectConfig is AddStatusEffect) entity.AddComponent<EffectAddBuffComponent>();
            /// �Զ���Ч��
            //if (this.EffectConfig is CustomEffect) AddComponent<EffectCustomComponent>();
            /// Ч������
            var decorators = entity.EffectConfig.Decorators;
            if (decorators != null && decorators.Count > 0) entity.AddComponent<EffectDecoratorComponent>();
        }

        public void Enable(AbilityEffect entity)
        {
            //foreach (var item in entity.Components.Values)
            //{
            //    item.Enable = true;
            //}
        }

        public void Disable(AbilityEffect entity)
        {
            //foreach (var item in entity.Components.Values)
            //{
            //    item.Enable = false;
            //}
        }

        public void Destroy(AbilityEffect entity)
        {
            entity.Enable = false;
        }

        public static void OnTriggerApplyEffect(EffectAssignAction effectAssign)
        {
            foreach (var item in effectAssign.AbilityEffect.Components.Values)
            {

            }
        }
    }
}