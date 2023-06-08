using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制角色移动、生命、动画
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
        float moveX = Input.GetAxisRaw("Horizontal");   // 控制水平方向移动 A:-1  D: 1
        float moveY = Input.GetAxisRaw("Vertical");     // 控制垂直方向移动 W:-1  S: 1

        Vector2 position = transform.position;          // 人物当前位置
        
        // 更新人物位置
        position.x += moveX * speed * Time.deltaTime;   
        position.y += moveY * speed * Time.deltaTime;

        transform.position = position;
    }
}
