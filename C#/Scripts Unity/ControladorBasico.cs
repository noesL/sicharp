using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/* Script basico de controlador de un objeto Prefab, en este caso controla inputs >> outputs de movimiento de un jugador, 
 * en unity hay modulos integrados de fisica que permiten crear colision y fuerzas reales como gravedad e impulsos (ver linea 13 y 23)
 * Funciones Integradas de UNITY:
 * START > Se inicializa en la frame 1 de modo de juego
 * AWAKE > Se inicializa en la frame 0 (optima para renderear y cargar objetos (ver linea 20))
 * UPDATE > Se reinicia y ejecuta cada una de las frames mientras el juego esta corriendo.
 */


public class PlayerController : MonoBehaviour
{

    //Character movement variables
    public float jumpForce = 6f;
    Rigidbody2D playerRigidBody;

    void Awake()
    {
        // Using gameObject.GetComponent will return the first component that is found and the order is undefined.
        // If you expect there to be more than one component of the same type, use gameObject.GetComponents instead,
        // and cycle through the returned components testing for some unique property.
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    void Jump() 
    {
        // Apply a force to the rigidbody.

        //The force is specified as two separate components in the X and Y directions(there is no Z direction in 2D physics).
        //The object will be accelerated by the force according to the law force = mass x acceleration -the larger the mass,
        //greater the force required to accelerate to a given speed.

        // VECTOR2 INDICA MOVIMIENTO EN 2D
        //IMPULSE: This mode is useful for applying forces that happen instantly, such as forces from explosions or collisions.
        playerRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }
}
