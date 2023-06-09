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

    Animator animator;

    public int MyMaxHealth { get { return maxHealth; } }
    public int MyCurrentHealth { get { return currentHealth; } }

    public GameObject bulletPrefab;     // 子弹

    // 玩家方向
    private Vector2 lookDirection = new Vector2(1, 0);     // 默认看向右方

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = 2;
        invincibleTimer = 0;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");   // 控制水平方向移动 A:-1  D: 1
        float moveY = Input.GetAxisRaw("Vertical");     // 控制垂直方向移动 W:-1  S: 1

        Vector2 moveVector = new Vector2(moveX, moveY);
        if (moveVector.x != 0 || moveVector.y != 0)
        {
            lookDirection = moveVector;
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", moveVector.magnitude);

        // 人物移动: 通过移动刚体位置而非人物位置解决人物与其他物体碰撞时抖动问题
        //=========================================================================================================
        Vector2 position = rigidBody.position;          // 人物当前位置

        position += moveVector * speed * Time.deltaTime;

        rigidBody.MovePosition(position);

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

        // 按下 J 键，进行攻击
        //=========================================================================================================
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Launch");      // 播放动画
            GameObject bullet = Instantiate(bulletPrefab, rigidBody.position + Vector2.up * 0.5f, Quaternion.identity);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            if (bulletController != null)
            {
                bulletController.Move(lookDirection, 300);
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
