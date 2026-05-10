using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public int cannonCount = 4;
    public int maxCannons = 8;
    public GameObject cannonBallPrefab;
    public Transform firePoint;
    public float fireInterval = 2f;
    private float fireTimer;
    public GameObject Lose;
    public GameObject Win;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Update()
    {
        Move();
        FireCannons();
    }

    // Update is called once per frame
    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        Vector3 move = new Vector3(x, 0, z).normalized;

        transform.position += move.normalized * moveSpeed * Time.deltaTime;
    }

    void FireCannons()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            fireTimer = 0f;

            SpawnCannons();
        }
    }

    void SpawnCannons()
    {
        float angleStep = 360f / cannonCount;

        for (int i = 0; i < cannonCount; i++)
        {
            float angle = angleStep * i + 45f;

            float radians = angle * Mathf.Deg2Rad;

            Vector3 direction = new Vector3(
                Mathf.Cos(radians),
                0,
                Mathf.Sin(radians)
            );


            GameObject cannon = Instantiate(
                cannonBallPrefab,
                firePoint.position,
                Quaternion.identity
            );

            cannon.GetComponent<CannonBall>().SetDirection(direction);
        }
    }

    public void IncreaseCannons()
    {
        cannonCount++;
        Debug.Log("Cannons: " + cannonCount);
    }

    public void LoseGame()
    {
    Lose.SetActive(true);

    Time.timeScale = 0f;
    }

    public void WinGame()
{
    Win.SetActive(true);

    Time.timeScale = 0f;
}
}
