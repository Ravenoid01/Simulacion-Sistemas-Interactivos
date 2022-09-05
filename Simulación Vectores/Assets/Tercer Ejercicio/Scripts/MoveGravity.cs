using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGravity : MonoBehaviour
{
    [SerializeField] private MoveGravity target;
    public float mass = 1f;
  
    [SerializeField] private MyVector aceleration;
    [SerializeField] private MyVector velocity;
    private MyVector position;

    void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {
        aceleration *= 0;

        MyVector atraction = target.transform.position - transform.position;
        float atractMag = atraction.magnitude;
        MyVector force = atraction.normalized * (target.mass * mass / atractMag * atractMag);
        AplyForce(force);

        force.Draw(Color.blue, position);
        
        Move();
    }

    void Update()
    {


    }

    public void Move()
    {
        velocity += aceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;
  
        if(velocity.magnitude > 5)
        {
            velocity.Normalize();
            velocity *= 5;
        }

        transform.position = position;


    }

    void AplyForce(MyVector force)
    {        
        aceleration = force / mass;

    }

}
