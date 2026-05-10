using UnityEngine;

public class CannonBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 8f;
    private Vector3 moveDirection;

    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

     void Update()
    {
        transform.position += moveDirection * speed * Time.deltaTime;

        CheckBarrierHit();
    }

     public void SetDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
    }

    void CheckBarrierHit()
    {
        Barrier[] barriers = FindObjectsByType<Barrier>();

        foreach (Barrier barrier in barriers)
        {
            float dist = Vector3.Distance(
                transform.position,
                barrier.transform.position
            );

            if (dist < 2f)
            {
                barrier.MoveAway();

                Destroy(gameObject);

                break;
            }
        }
    }
}
