using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ¿ØÖÆ×Óµ¯ÒÆ¶¯¡¢Åö×²
/// </summary>
public class BulletController : MonoBehaviour
{

    Rigidbody2D rigidBody;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 3f);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ×Óµ¯ÒÆ¶¯
    /// </summary>
    /// <param name="moveDirection"></param>
    /// <param name="moveForce"></param>
    public void Move(Vector2 moveDirection, float moveForce)
    {
        rigidBody.AddForce(moveDirection * moveForce);
    }
    /// <summary>
    /// Åö×²¼ì²â
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
        if (enemyController != null)
        {
            enemyController.Fixed();        // ÐÞ¸´µÐÈË
        }

        Destroy(this.gameObject);
    }
}
