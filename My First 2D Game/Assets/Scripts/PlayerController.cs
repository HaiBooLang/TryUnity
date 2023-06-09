using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 控制角色移动、生命、动画
/// </summary>

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;            // 移动速度

    private int maxHealth = 5;          // 最大生命值

    private int currentHealth;      // 当前生命值

    private float invincibleTime = 2f;  // 无敌时间

    private float invincibleTimer;      // 无敌计时器

    private bool isInvincible;          // 是否处于无敌

    Rigidbody2D rigidBody;              // 刚体组件

    public int MyMaxHealth { get { return maxHealth; } }
    public int MyCurrentHealth { get { return currentHealth; } }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 2;
        invincibleTimer = 0;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");   // 控制水平方向移动 A:-1  D: 1
        float moveY = Input.GetAxisRaw("Vertical");     // 控制垂直方向移动 W:-1  S: 1

        // 人物移动: 通过移动刚体位置而非人物位置解决人物与其他物体碰撞时抖动问题
        //=========================================================================================================
        Vector2 position = rigidBody.position;          // 人物当前位置

        // 更新人物位置
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;

        rigidBody.position = position;

        // 无敌计时
        //=========================================================================================================
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    /// <summary>
    /// 改变玩家生命值
    /// </summary>
    /// <param name="amount"></param>
    public void ChangeHealth(int amount)
    {
        // 如果人物受到伤害
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = invincibleTime;
        }

        // 把玩家生命值约束在 0 和 最大值 之间
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
