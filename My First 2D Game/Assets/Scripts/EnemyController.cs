using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
/// <summary>
/// 敌人控制相关
/// </summary>
public class EnemyController : MonoBehaviour
{
    public float speed;                // 速度

    public float changeDirectionTime;  // 改变方向时间间隔

    private float changeTimer;              // 改变方向时间计时器

    private Rigidbody2D rigidBody;          // 刚体

    public bool isVertical;                 // 是否垂直方向移动

    private Vector2 moveDirection;          // 移动方向

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        // 如果是垂直移动，移动方向就向上，否则移动方向向右
        moveDirection = isVertical ? Vector2.up : Vector2.right;

        animator = GetComponent<Animator>();

        changeTimer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0)
        {
            moveDirection *= -1;
            changeTimer = changeDirectionTime;
        }

        Vector2 position = rigidBody.position;
        position.x += moveDirection.x * speed * Time.deltaTime;
        position.y += moveDirection.y * speed * Time.deltaTime;
        rigidBody.MovePosition(position);

        animator.SetFloat("moveX", moveDirection.x);
        animator.SetFloat("moveY", moveDirection.y);
    }

    /// <summary>
    /// 与玩家碰撞检测
    /// </summary>
    /// <param name="otherCollision"></param>
    private void OnCollisionEnter2D(Collision2D otherCollision)
    {
        PlayerController playerController = otherCollision.gameObject.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.ChangeHealth(-1);
        }
    }
}
