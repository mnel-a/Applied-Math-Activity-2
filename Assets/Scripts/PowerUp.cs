using UnityEngine;

public class PowerUp : MonoBehaviour
{
 void Update()
    {
        PlayerController player =
            FindAnyObjectByType<PlayerController>();

        if (player == null)
        {
            Debug.Log("PLAYER NOT FOUND");
            return;
        }

        float dist = Vector3.Distance(
            transform.position,
            player.transform.position
        );

        Debug.Log("Distance: " + dist);

        if (dist < 2f)
        {
            Debug.Log("POWER UP TOUCHED");

            player.IncreaseCannons();

            Destroy(gameObject);
        }
    }
}
