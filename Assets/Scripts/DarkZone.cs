using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkZone : MonoBehaviour
{

    private GameObject warning;
    public List<Enemy> enemies = new List<Enemy>();
    // Start is called before the first frame update
    void Start()
    {
        warning = transform.GetChild(0).gameObject;
        warning.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            enemies.Add(collision.GetComponent<Enemy>());
            warning.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            enemies.Remove(collision.GetComponent<Enemy>());

            if (enemies.Count <= 0)
            {
                warning.SetActive(false);
            }            
        }
    }
}
