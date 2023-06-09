using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// NPC �������
/// </summary>
public class NPCmanager : MonoBehaviour
{
    public GameObject tipImage;         // ������ʾ

    public GameObject dialogImage;      // �Ի�

    public float showTime = 4;          // �Ի�����ʾʱ��

    private float showTimer;            // �Ի�����ʾ��ʱ��

    // Start is called before the first frame update
    void Start()
    {
        tipImage.SetActive(true);        // ��ʼĬ����ʾ��ʾ
        dialogImage.SetActive(false);       // ��ʼĬ������
        showTimer = -1;
    }

    // Update is called once per frame
    void Update()
    {
        showTimer -= Time.deltaTime;

        if(showTimer <0)
        {
            tipImage.SetActive(true);
            dialogImage.SetActive(false);
        }
    }
    /// <summary>
    /// ��ʾ�Ի���
    /// </summary>
    public void ShowDialog()
    {
        showTimer = showTime;
        tipImage.SetActive(false);
        dialogImage.SetActive(true);
    }
}
