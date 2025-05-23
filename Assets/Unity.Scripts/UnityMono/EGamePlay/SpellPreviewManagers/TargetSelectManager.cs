﻿using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System;
using GameUtils;

public enum TargetLimitType { None, SelfTeam, EnemyTeam }

public class TargetSelectManager : MonoBehaviour
{
    public static TargetSelectManager Instance { get; set; }
    private Action<GameObject> OnSelectTargetCallback { get; set; }
    public TargetLimitType TargetLimitType { get; set; }
    public Color CursorColor { get; set; }
    public GameObject HeroObj;
    public GameObject RangeCircleObj;
    public Image CursorImage;


    private void Awake()
    {
        Instance = this;
        //CursorImage = GetComponent<Image>();
        CursorColor = CursorImage.color;
        Hide();
    }

    private void Update()
    {
        RangeCircleObj.transform.position = new Vector3(HeroObj.transform.position.x, 0.1f, HeroObj.transform.position.z);
        CursorImage.transform.position = Input.mousePosition;
        if (TargetLimitType == TargetLimitType.EnemyTeam)
        {
            if (RaycastHelper.CastEnemyObj(out var enemyObj))
            {
                if (Input.GetMouseButtonDown((int)UnityEngine.UIElements.MouseButton.LeftMouse))
                {
                    Hide();
                    OnSelectTargetCallback?.Invoke(enemyObj);
                }
                CursorImage.color = Color.red;
            }
            else
            {
                CursorImage.color = CursorColor;
            }
        }
        if (TargetLimitType == TargetLimitType.SelfTeam)
        {
            if (RaycastHelper.CastHeroObj(out var enemyObj))
            {
                if (Input.GetMouseButtonDown((int)UnityEngine.UIElements.MouseButton.LeftMouse))
                {
                    Hide();
                    OnSelectTargetCallback?.Invoke(enemyObj);
                }
                CursorImage.color = Color.green;
            }
            else
            {
                CursorImage.color = CursorColor;
            }
        }
    }

    public void Show(Action<GameObject> onSelectTargetCallback)
    {
        gameObject.SetActive(true);
        Cursor.visible = false;
        CursorImage.gameObject.SetActive(true);
        RangeCircleObj.SetActive(true);
        OnSelectTargetCallback = onSelectTargetCallback;
    }

    public void Hide()
    {
        Cursor.visible = true;
        CursorImage.gameObject.SetActive(false);
        RangeCircleObj.SetActive(false);
        gameObject.SetActive(false);
    }
}
