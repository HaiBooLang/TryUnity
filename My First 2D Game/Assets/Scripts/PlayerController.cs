using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ƽ�ɫ�ƶ�������������
/// </summary>

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");   // ����ˮƽ�����ƶ� A:-1  D: 1
        float moveY = Input.GetAxisRaw("Vertical");     // ���ƴ�ֱ�����ƶ� W:-1  S: 1

        Vector2 position = transform.position;          // ���ﵱǰλ��
        
        // ��������λ��
        position.x += moveX * speed * Time.deltaTime;   
        position.y += moveY * speed * Time.deltaTime;

        transform.position = position;
    }
}
