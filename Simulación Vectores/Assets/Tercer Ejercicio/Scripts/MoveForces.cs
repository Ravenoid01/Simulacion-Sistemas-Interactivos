using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForces : MonoBehaviour
{
    //private Transform target;
    [SerializeField] private MyVector wind;
    [SerializeField] private MyVector gravity;
    [SerializeField] private MyVector aceleration;
    [SerializeField] private MyVector velocity;
    [SerializeField] private float mass = 1f;
    [Range(0, 1)] [SerializeField] private float damping = 1;
    private MyVector position;

    void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {
        Move();
        //AplyForce(wind);
        //AplyForce(gravity);
        //aceleration *= 0f;
        AplyForce(wind + gravity);

    }

    void Update()
    {
        position.Draw(Color.red);
        velocity.Draw(Color.cyan, position);
        aceleration.Draw(Color.green, position);

    }

    public void Move()
    {
        velocity += aceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
        velocity *= damping;

        if (Mathf.Abs(position.x) > 5)
        {
            //devuelve 1 si es positivo o -1 si es negativo
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;
            //velocity *= -damping;

        }
        if (Mathf.Abs(position.y) > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
            //velocity *= -damping;
        }

        transform.position = position;

    }
    
    void AplyForce(MyVector force)
    {        
        aceleration = force / mass;
    }

}
