using UnityEngine;

public class Finish : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Update()
    {
        PlayerController player =
            FindAnyObjectByType<PlayerController>();

        float dist = Vector3.Distance(
            transform.position,
            player.transform.position
        );

        if (dist < 8f)
        {
            player.WinGame();
        }
    }
}
