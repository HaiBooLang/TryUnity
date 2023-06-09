using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ƽ�ɫ�ƶ�������������
/// </summary>

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;            // �ƶ��ٶ�

    private int maxHealth = 5;          // �������ֵ

    private int currentHealth;      // ��ǰ����ֵ

    private float invincibleTime = 2f;  // �޵�ʱ��

    private float invincibleTimer;      // �޵м�ʱ��

    private bool isInvincible;          // �Ƿ����޵�

    Rigidbody2D rigidBody;              // �������

    Animator animator;

    public int MyMaxHealth { get { return maxHealth; } }
    public int MyCurrentHealth { get { return currentHealth; } }

    public GameObject bulletPrefab;     // �ӵ�

    // ��ҷ���
    private Vector2 lookDirection = new Vector2(1, 0);     // Ĭ�Ͽ����ҷ�

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
        float moveX = Input.GetAxisRaw("Horizontal");   // ����ˮƽ�����ƶ� A:-1  D: 1
        float moveY = Input.GetAxisRaw("Vertical");     // ���ƴ�ֱ�����ƶ� W:-1  S: 1

        Vector2 moveVector = new Vector2(moveX, moveY);
        if (moveVector.x != 0 || moveVector.y != 0)
        {
            lookDirection = moveVector;
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", moveVector.magnitude);

        // �����ƶ�: ͨ���ƶ�����λ�ö�������λ�ý������������������ײʱ��������
        //=========================================================================================================
        Vector2 position = rigidBody.position;          // ���ﵱǰλ��

        position += moveVector * speed * Time.deltaTime;

        rigidBody.MovePosition(position);

        // �޵м�ʱ
        //=========================================================================================================
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }

        // ���� J �������й���
        //=========================================================================================================
        if (Input.GetKeyDown(KeyCode.J))
        {
            animator.SetTrigger("Launch");      // ���Ŷ���
            GameObject bullet = Instantiate(bulletPrefab, rigidBody.position + Vector2.up * 0.5f, Quaternion.identity);
            BulletController bulletController = bullet.GetComponent<BulletController>();
            if (bulletController != null)
            {
                bulletController.Move(lookDirection, 300);
            }
        }
    }

    /// <summary>
    /// �ı��������ֵ
    /// </summary>
    /// <param name="amount"></param>
    public void ChangeHealth(int amount)
    {
        // ��������ܵ��˺�
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }
            isInvincible = true;
            invincibleTimer = invincibleTime;
        }

        // ���������ֵԼ���� 0 �� ���ֵ ֮��
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
