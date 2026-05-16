using UnityEngine;

public class Barrier : MonoBehaviour
{ public float moveSpeed = 8f;
    public float spinSpeed = 300f;

    private bool moved = false;

    private Vector3 randomDirection;

    void Update()
    {
        CheckPlayerCollision();

        if (moved)
        {
           
            transform.position += randomDirection * moveSpeed * Time.deltaTime;

            
            transform.Rotate(0, 0, spinSpeed * Time.deltaTime);
        }
    }

    public void MoveAway()
    {
        if (moved)
            return;

        moved = true;

        
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(0.5f, 1.5f);

        randomDirection = new Vector3(randomX, randomY, 0f).normalized;

        
        Destroy(gameObject, 3f);
    }

    void CheckPlayerCollision()
    {
        PlayerController player =
            FindAnyObjectByType<PlayerController>();

        float dist = Vector3.Distance(
            transform.position,
            player.transform.position
        );

        if (dist < 1f)
        {
            Debug.Log("GAME OVER");

            player.LoseGame();
        }
    }
}
