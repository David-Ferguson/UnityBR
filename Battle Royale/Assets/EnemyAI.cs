using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0f;
    private Transform closestEnemy = null;
    void Start()
    {
        speed = GameObject.Find("Players").GetComponent<Spawner>().speed;
        closestEnemy = GameObject.Find("Circle").GetComponent<Transform>();
    }
    private System.Random rand = new System.Random();
    // Update is called once per frame
    private float moveAngle = 0f;

    Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform bestTarget = GameObject.Find("Circle").GetComponent<Transform>();
        float closestDistanceSqr = 1000000000;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            if (potentialTarget.tag != "Health" && potentialTarget.tag != "Advantage")
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr && dSqrToTarget >= 0.01)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;
                }
            }
        }

        return bestTarget;
    }
    float findEnemyAngle()
    {
        Vector2 targetDistance = new Vector2(0, 0);
        Vector2 targetDirection = new Vector2(0, 0);
        targetDistance = new Vector2(closestEnemy.position.x - transform.position.x, closestEnemy.position.y - transform.position.y);
        targetDirection = targetDistance.normalized;
        moveAngle = Mathf.Acos(targetDirection.x);
        if (closestEnemy.position.y - transform.position.y < 0)
        {
            moveAngle = moveAngle + (Mathf.PI - moveAngle) * 2;
        }
        return moveAngle;
    }
    Vector2 targetDistance = new Vector2(0, 0);
    public Vector2 targetDirection = new Vector2(0, 0);
    public void Update()
    {
        targetDistance = new Vector2(closestEnemy.position.x - transform.position.x, closestEnemy.position.y - transform.position.y);
        targetDirection = targetDistance.normalized;
        double actionCooldown = GameObject.Find("Players").GetComponent<Spawner>().rand.NextDouble();
        actionCooldown = actionCooldown - Time.deltaTime;
        if (actionCooldown <= 0)
        {
            closestEnemy = GetClosestEnemy(enemies: GameObject.Find("Players").GetComponent<Spawner>().children);
            findEnemyAngle();
        }

        if (Mathf.Abs(targetDistance.x) + Mathf.Abs(targetDistance.y) <= 10)
        {
            int dodgeAction = GameObject.Find("Players").GetComponent<Spawner>().rand.Next(100);
            if (dodgeAction == 1)
            {
                moveAngle = findEnemyAngle();
                moveAngle = moveAngle + Mathf.PI / 2;

            } else if (dodgeAction == 2)
            {
                moveAngle = findEnemyAngle();
                moveAngle = moveAngle - Mathf.PI / 2;
            }
        }
        if (Mathf.Sqrt(transform.position.x*transform.position.x+transform.position.y*transform.position.y) >= GameObject.Find("Circle").transform.localScale.x * 25 - 0.1 && GameObject.Find("Circle").transform.localScale.x * 25 > 2) {
            targetDirection = new Vector2(-transform.position.x, -transform.position.y).normalized;
            moveAngle = Mathf.Acos(targetDirection.x);
            if (transform.position.y > 0)
            {
                moveAngle = moveAngle + (Mathf.PI - moveAngle) * 2;
            }
        }
        transform.position += new Vector3(speed * Convert.ToSingle(Math.Cos(moveAngle)), speed * Convert.ToSingle(Math.Sin(moveAngle)), 0.0f) * Time.deltaTime;
    }
}
;