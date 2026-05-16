using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject cannonPrefab;

    public float fireRate = 2f;

    public int cannonCount = 4;

    public int maxCannon = 8;

    private float timer = 0f;

  
    void Start()
    {
          timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            CannonSpawner();
            timer = 0f;
        }
    }


    void CannonSpawner()
    {
          float angleStep = 360f / cannonCount;

        float startAngle = 45f;

        for (int i = 0; i < cannonCount; i++)
        {
            float angle = startAngle + (angleStep * i);

            float radians = angle * Mathf.Deg2Rad;

            Vector3 direction = new Vector3(
                Mathf.Cos(radians),
                Mathf.Sin(radians),
                0
            );

            GameObject CannonBall = Instantiate(
                cannonPrefab,
                transform.position,
                Quaternion.identity
            );

            CannonBall.GetComponent<CannonBall>().SetDirection(direction);

            CannonBall.transform.right = direction;
        }
    }

    public void IncreaseCannonCount()
    {
        cannonCount++;

        if (cannonCount > maxCannon)
            cannonCount = maxCannon;
    }
}

