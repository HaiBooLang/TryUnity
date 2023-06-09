using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI 管理相关
/// </summary>
public class UImanager : MonoBehaviour
{
    // 单例模式
    public static UImanager Instance { get; private set; }

    public Image healthBar;     // 血条

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 更新血条
    /// </summary>
    /// <param name="currentAmount"></param>
    /// <param name="maxAmount"></param>
    public void UpdateHealthBar(int currentAmount, int maxAmount)
    {
        healthBar.fillAmount = (float)currentAmount / (float)maxAmount;
    }
}
