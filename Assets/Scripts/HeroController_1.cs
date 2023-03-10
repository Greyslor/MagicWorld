//Script para mover objeto con el teclado izquierda y derecha y para hacer "flip" izquirda derecha.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController_1 : MonoBehaviour
{
   [Header("Animation Variables")]                                                             //"Pestaña" con título en el Inspector
 [SerializeField] AnimatorController_1 animatorController;    
    [SerializeField] private float speed_;                  //"SerializeField" significa que desde el inspector podemos  manipular o ver su valor.
    [SerializeField] private Vector2 movementDirection;     //"SerializeField" significa que desde el inspector podemos  manipular o ver su valor.
    private Rigidbody2D rigidbody2D_;                       //Variable de instanciamiento

                      
    void Start()
    {
        rigidbody2D_ = GetComponent<Rigidbody2D>();         //Variable de instanciamiento tipo "RigidBody2D"
    }

    // Update is called once per frame
    void Update()
    {
        HandleControls();                                    //invocando el m�todo "HandleControls" (abre el puerto de entrada del teclado)
        HandleMovement();                                    //invocando el m�todo "HandleMovement" (multiplica el valor de "x" por "speed".
        HandleFlip();                                       //invocando el m�todo "HandleFlip" (rota el personaje a la izquierda o a la derecha)
    }

    void HandleControls()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }

    void HandleMovement()
    {
        rigidbody2D_.velocity = new Vector2(movementDirection.x * speed_, rigidbody2D_.velocity.y);
        if (Mathf.Abs(rigidbody2D_.velocity.x) > 0)     //si el velor absoluto matemático de la velocidasd es mayor a cero..
        {
            animatorController.Play(AnimationId.Run);    //ejecuta en el script AnimatorController_1 el método "Play"
                                                         //mandando dentro de la variable "AnimationAI" el clip "Run"
        }
        else                                            //de otro modo ejecuta en el script AnimatorController_1 el método "Play"
                                                         //mandando dentro de la variable "AnimationAI" el clip "Idle"
        {
            animatorController.Play(AnimationId.Idle);
        }
    }
    void HandleFlip()
    {
        if (rigidbody2D_.velocity.magnitude > 0)                //S�lo si el personaje se est� moviendo ejecuta estas lineas...
        {
            if (rigidbody2D_.velocity.x >= 0)                           //si la velocidad en "x" es mayor que cero ejecuta la siguiente linea....
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);            //No rotes
            }
            else                                                                            //de otro modo ejecuta las siguientes lineas.....
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);              //rota en "y" 180�
            }
        }
    }
}
