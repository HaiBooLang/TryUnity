using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���˿������
/// </summary>
public class EnemyController : MonoBehaviour
{
    public float speed = 5f;                // �ٶ�

    public float changeDirectionTime = 2f;  // �ı䷽��ʱ����

    private float changeTimer;              // �ı䷽��ʱ���ʱ��

    private Rigidbody2D rigidBody;          // ����

    public bool isVertical;                 // �Ƿ�ֱ�����ƶ�

    private Vector2 moveDirection;          // �ƶ�����

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        // ����Ǵ�ֱ�ƶ����ƶ���������ϣ������ƶ���������
        moveDirection = isVertical ? Vector2.up : Vector2.right;

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
}
