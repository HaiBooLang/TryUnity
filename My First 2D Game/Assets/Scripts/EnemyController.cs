using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
/// <summary>
/// ���˿������
/// </summary>
public class EnemyController : MonoBehaviour
{
    public float speed;                // �ٶ�

    public float changeDirectionTime;  // �ı䷽��ʱ����

    private float changeTimer;              // �ı䷽��ʱ���ʱ��

    private Rigidbody2D rigidBody;          // ����

    public bool isVertical;                 // �Ƿ�ֱ�����ƶ�

    private Vector2 moveDirection;          // �ƶ�����

    private bool isFixed;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        isFixed = false;

        rigidBody = GetComponent<Rigidbody2D>();

        // ����Ǵ�ֱ�ƶ����ƶ���������ϣ������ƶ���������
        moveDirection = isVertical ? Vector2.up : Vector2.right;

        animator = GetComponent<Animator>();

        changeTimer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFixed) { return; }        // ������޸���ִֹͣ�����´���

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
    }

    /// <summary>
    /// �������ײ���
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

    public void Fixed()
    {
        isFixed = true;
        rigidBody.simulated = false;    // ��������
        animator.SetTrigger("fixed");     // ���ű��޸��Ķ���
    }
}
