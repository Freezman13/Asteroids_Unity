using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroids_script : MonoBehaviour
{
    // Variables
    public Rigidbody2D rigid_body;
    public float max_thrust;
    public float max_torque;
    // for screen wrap
    public float screen_top;
    public float screen_bottom;
    public float screen_left;
    public float screen_right;
    //size variables
    public enum size {large, medium, small}
    public size asteroid_size;
    public GameObject asteroid_medium;
    public GameObject asteroid_small;

    // Start is called before the first frame update
    void Start()
    {
        // Adds thrust
        Vector2 thrust = new Vector2(Random.Range(-max_thrust, max_thrust), Random.Range(-max_thrust, max_thrust));
        rigid_body.AddForce(thrust);

        // Adds torque
        float torque = Random.Range(-max_torque, max_torque);
        rigid_body.AddTorque(torque);
    }

    // Update is called once per frame
    void Update()
    {
        screen_wrap(); // Teleports asteroid to the opposite end of the screen


    }

    void screen_wrap() // Teleports asteroid to the opposite end of the screen
    {
        if (transform.position.y > screen_top)
        {
            Vector2 current_position = transform.position;
            current_position.y = screen_bottom;
            transform.position = current_position;
        }
        if (transform.position.y < screen_bottom)
        {
            Vector2 current_position = transform.position;
            current_position.y = screen_top;
            transform.position = current_position;
        }
        if (transform.position.x > screen_right)
        {
            Vector2 current_position = transform.position;
            current_position.x = screen_left;
            transform.position = current_position;
        }
        if (transform.position.x < screen_left)
        {
            Vector2 current_position = transform.position;
            current_position.x = screen_right;
            transform.position = current_position;
        }
    }

    private void OnTriggerEnter2D(Collider2D other_object) // Prebuilt unity functonion. Doesn't need to be in update.
    {
        Debug.Log("Asteroid collided with " + other_object.gameObject.name);

        if(other_object.CompareTag("Projectile")) // Checks the tag of the object
        {
            Destroy(other_object.gameObject); // Destroys collided projectile

            if(asteroid_size == size.large) // spawns medium asteroid
            {
                for (int i=0; i<2; i++)
                {
                    Instantiate(asteroid_medium, transform.position, transform.rotation); // spawns nedium asteroid
                    // sets spawned asteroid's size to medium in the prefab
                }
            }
            else if (asteroid_size == size.medium) // spawns small asteroid
            {
                for (int i = 0; i < 2; i++)
                {
                    Instantiate(asteroid_small, transform.position, transform.rotation); // spawns small asteroid
                    // sets spawned asteroid's size to small in the prefab
                }
            }
            else if (asteroid_size == size.small) // destroys asteroid
            {
                
            }

            Destroy(gameObject); // destroys asteroid
        }
        
    }
}
