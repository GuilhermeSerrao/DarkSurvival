using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private GameObject playerSprite;

    private List<Enemy> enemies = new List<Enemy>();

    private int direction = 0;

    private Enemy target;

    [SerializeField]
    private DarkZone[] zones;

    private void Start()
    {
        DisableZone();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (direction != 0)
            {
                direction = 0;
                DisableZone();
                Rotate();
                
            }
                       
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            if (direction != 1)
            {
                direction = 1;
                DisableZone();
                Rotate();
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            if (direction != 2)
            {
                direction = 2;
                DisableZone();
                Rotate();
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            if (direction != 3)
            {
                direction = 3;
                DisableZone();
                Rotate();
            }
            
        }

        if (target)
        {
            playerSprite.transform.right = target.transform.position - playerSprite.transform.position;
        }
        else
        {
            playerSprite.transform.rotation = transform.rotation;
        }
    }

    private void Rotate()
    {
        target = null;

        transform.rotation = Quaternion.Euler(0,0, -direction * 90);
        playerSprite.transform.rotation = transform.rotation;
    }

    public void AddEnemy(Enemy enemy)
    {
        enemies.Add(enemy);

        if (!target)
        {
            target = enemy;
        }
        else if (Vector2.Distance(enemy.transform.position,transform.position) < Vector2.Distance(target.transform.position, transform.position))
        {
            target = enemy;
        }
        
    }

    public void RemoveEnemy(Enemy enemy)
    {
        if (enemy == target)
        {
            target = null;
        }
        enemies.Remove(enemy);

        target = enemies[Random.Range(0, enemies.Count)];

        foreach (Enemy item in enemies)
        {
            if (Vector2.Distance(enemy.transform.position, transform.position) < Vector2.Distance(target.transform.position, transform.position))
            {
                target = item;
            }   
        }
    }

    private void Shoot()
    {
        Instantiate(bullet,transform.position, playerSprite.transform.rotation);
    }

    private void DisableZone()
    {
        foreach (DarkZone zone in zones)
        {
            zone.gameObject.SetActive(true);
           //zone.ResetTargets();
        }

        zones[direction].gameObject.SetActive(false);
        zones[direction].enemies.Clear();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>())
        {
            Destroy(collision.gameObject);
        }
    }
}
