using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制角色移动、生命、动画
/// </summary>

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rigid_body;     // 刚体组件

    // Start is called before the first frame update
    void Start()
    {
        rigid_body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move_X = Input.GetAxisRaw("Horizontal");   // 控制水平方向移动 A:-1  D: 1
        float move_Y = Input.GetAxisRaw("Vertical");     // 控制垂直方向移动 W:-1  S: 1

        // 人物移动
        // 通过移动刚体位置而非人物位置解决人物与其他物体碰撞时抖动问题
        //=========================================================================================================
        Vector2 position = rigid_body.position;          // 人物当前位置
        
        // 更新人物位置
        position.x += move_X * speed * Time.deltaTime;   
        position.y += move_Y * speed * Time.deltaTime;

        rigid_body.position = position;
    }
}
