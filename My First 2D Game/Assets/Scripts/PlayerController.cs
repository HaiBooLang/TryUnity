using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ƽ�ɫ�ƶ�������������
/// </summary>

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;    // �ƶ��ٶ�

    private int maxHealth = 5;  // �������ֵ

    private int currentHealth = 1;  // ��ǰ����ֵ

    Rigidbody2D rigidBody;      // �������

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");   // ����ˮƽ�����ƶ� A:-1  D: 1
        float moveY = Input.GetAxisRaw("Vertical");     // ���ƴ�ֱ�����ƶ� W:-1  S: 1

        // �����ƶ�
        // ͨ���ƶ�����λ�ö�������λ�ý������������������ײʱ��������
        //=========================================================================================================
        Vector2 position = rigidBody.position;          // ���ﵱǰλ��
        
        // ��������λ��
        position.x += moveX * speed * Time.deltaTime;   
        position.y += moveY * speed * Time.deltaTime;

        rigidBody.position = position;
    }

    public int MyMaxHealth { get { return maxHealth; } }
    public int MyCurrentHealth { get { return currentHealth; } }

    /// <summary>
    /// �ı��������ֵ
    /// </summary>
    /// <param name="amount"></param>
    public void ChangeHealth(int amount)
    {
        // ���������ֵԼ���� 0 �� ���ֵ ֮��
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
