using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePhysics : MonoBehaviour
{
    [SerializeField] private float mass = 1f;

    [Range(0, 1)] [SerializeField] private float u = 1;
    [Range(0, 1)] [SerializeField] private float damping = 1;
    private float gravity = -9.8f;

    [SerializeField] private MyVector aceleration;
    [SerializeField] private MyVector velocity;
    private MyVector position;
    [SerializeField] private bool useFluid;

    void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {


        //Apply Gravity
        float weightScalar = mass * gravity;
        MyVector weight = new MyVector(0, weightScalar);
        MyVector drag = new MyVector(0, 0);
        MyVector friction = new MyVector(0, 0);

        if (useFluid)
        {
            // fluid friction
            if(transform.position.y <= 0)
            {
                float frontalArea = transform.localScale.x;
                drag = velocity.normalized * frontalArea * velocity.magnitude * velocity.magnitude * -0.5f;

            }
            
        }
        else
        {
            // Aply friction
            friction = velocity.normalized * u * -weightScalar * -1;
            friction.Draw(Color.green, position);
        }

        AplyForce(weight + friction + drag);
        Move();

    }

    void Update()
    {
        velocity.Draw(Color.cyan, position);

    }

    public void Move()
    {
        velocity += aceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        if (Mathf.Abs(position.x) > 5)
        {
            //devuelve 1 si es positivo o -1 si es negativo
            position.x = Mathf.Sign(position.x) * 5;
            velocity *= -damping;

        }
        if (Mathf.Abs(position.y) > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity *= -damping;
        }

        transform.position = position;

    }

    void AplyForce(MyVector force)
    {
        aceleration = force / mass;
    }

}
