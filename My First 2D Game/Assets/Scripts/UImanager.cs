using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// UI �������
/// </summary>
public class UImanager : MonoBehaviour
{
    // ����ģʽ
    public static UImanager Instance { get; private set; }

    public Image healthBar;     // Ѫ��

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// ����Ѫ��
    /// </summary>
    /// <param name="currentAmount"></param>
    /// <param name="maxAmount"></param>
    public void UpdateHealthBar(int currentAmount, int maxAmount)
    {
        healthBar.fillAmount = (float)currentAmount / (float)maxAmount;
    }
}
