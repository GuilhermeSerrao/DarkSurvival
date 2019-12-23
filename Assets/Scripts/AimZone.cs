using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimZone : MonoBehaviour
{

    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other.name);
        if (other.GetComponent<Enemy>())
        {
            player.AddEnemy(other.GetComponent<Enemy>());
            print("Enemy Enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>())
        {
            player.RemoveEnemy(other.GetComponent<Enemy>());
        }
    }
}
