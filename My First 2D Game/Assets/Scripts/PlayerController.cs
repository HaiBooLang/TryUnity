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
        ;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }
}
