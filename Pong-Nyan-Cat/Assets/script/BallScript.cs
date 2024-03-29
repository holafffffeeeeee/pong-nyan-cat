
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    public float moveSpeed = 1f;
    public float maxStartY = 4f;
    
    private float startX = 0f;

    private void Start()
    {
        InitialPush();
    }
    private void InitialPush()
    {
        Vector2 dir = Vector2.left;

        if (Random.value < 0.5f)
                dir = Vector2.right;

        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);
        rb2d.velocity = dir * moveSpeed;
    }
    private void ResetBall()
        {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        ScoreZone ScoreZone2 = collision.GetComponent<ScoreZone>();
        if (ScoreZone2) 
        {
            gameManager.OnScoreZoneReached(ScoreZone2.id);
           ResetBall();
            InitialPush();
        }
    }
}
