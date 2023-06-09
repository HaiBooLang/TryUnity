using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��ݮ�������ײʱ���������
/// </summary>
public class NewBehaviourScript : MonoBehaviour
{

    public ParticleSystem collectEffect;        // ʰȡ��Ч

    public AudioClip collectClip;               // ʰȡ��Ч

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ��ײ������
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        PlayerController playerController = otherCollider.GetComponent<PlayerController>();
        if (playerController != null)
        {
            if (playerController.MyCurrentHealth < playerController.MyMaxHealth)
            {
                playerController.ChangeHealth(1);
                Instantiate(collectEffect, transform.position, Quaternion.identity);        // ������Ч
                AudioManager.instance.AudioPlay(collectClip);                               // ������Ч
                Destroy(this.gameObject);
            }
        }
    }
}
