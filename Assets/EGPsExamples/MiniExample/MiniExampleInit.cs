using EGamePlay.Combat;
using EGamePlay;
using ET;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using ECS;
using ECSUnity;

public class MiniExampleInit : MonoBehaviour
{
    public bool EntityLog;
    public AbilityConfigObject SkillConfigObject;
    public ReferenceCollector ConfigsCollector;
    public EcsNode EcsNode { get; private set; }


    private void Awake()
    {
        //SynchronizationContext.SetSynchronizationContext(ThreadSynchronizationContext.Instance);
        //Entity.EnableLog = EntityLog;
        //ECSNode.Create();
        //Entity.Create<TimerManager>();
        //Entity.Create<CombatContext>();

        EcsNode = new EcsNode(1);
        EcsNode.AddChild<CombatContext>();
        EcsNode.AddComponent<ConfigManageComponent>(x => x.ConfigsCollector = ConfigsCollector);

        //await TimerManager.Instance.WaitAsync(2000);
        //��������ս��ʵ��
        var monster = StaticClient.Context.AddChild<CombatEntity>();
        //����Ӣ��ս��ʵ��
        var hero = StaticClient.Context.AddChild<CombatEntity>();
        //��Ӣ�۹��ؼ��ܲ����ؼ���ִ����
        var heroSkillAbility = SkillSystem.Attach(hero, SkillConfigObject);

        Debug.Log($"1 monster.CurrentHealth={monster.GetComponent<HealthPointComponent>().Value}");
        //ʹ��Ӣ�ۼ��ܹ�������
        SpellSystem.SpellWithTarget(hero, heroSkillAbility, monster);
        //await TimerManager.Instance.WaitAsync(2000);
        Debug.Log($"2 monster.CurrentHealth={monster.GetComponent<HealthPointComponent>().Value}");
        //--ʾ������--
    }

    private void Update()
    {
        EcsNode.DriveEntityUpdate();
        //TimerManager.Instance?.Update();
    }

    private void OnApplicationQuit()
    {
        EcsObject.Destroy(EcsNode);
    }
}
