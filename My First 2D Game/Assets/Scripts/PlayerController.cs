using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ƽ�ɫ�ƶ�������������
/// </summary>

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rigid_body;     // �������

    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move_X = Input.GetAxisRaw("Horizontal");   // ����ˮƽ�����ƶ� A:-1  D: 1
        float move_Y = Input.GetAxisRaw("Vertical");     // ���ƴ�ֱ�����ƶ� W:-1  S: 1

        // �����ƶ�
        // ͨ���ƶ�����λ�ö�������λ�ý������������������ײʱ��������
        //=========================================================================================================
        Vector2 position = rigid_body.position;          // ���ﵱǰλ��
        
        // ��������λ��
        position.x += move_X * speed * Time.deltaTime;   
        position.y += move_Y * speed * Time.deltaTime;

        rigid_body.position = position;
    }
}
