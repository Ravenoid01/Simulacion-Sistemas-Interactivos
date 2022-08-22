using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForces : MonoBehaviour
{
    //private Transform target;
    [SerializeField] private MyVector wind;
    [SerializeField] private MyVector gravity;
    [Range(0,1)][SerializeField] private float damping = 1;
    [SerializeField] private MyVector aceleration;
    [SerializeField] private MyVector velocity;
    [SerializeField] private float mass = 1f;
    private MyVector position;

    //int currentIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {
        //Cambiar la posición
        Move();
        //AplyForce(wind);
        //AplyForce(gravity);
        //aceleration *= 0f;
        AplyForce(wind + gravity);

    }

    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.red);
        velocity.Draw(Color.cyan, position);
        aceleration.Draw(Color.green, position);

        // Codigo para que rebote en la paredes
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    velocity *= 0;
        //    switch (currentIndex)
        //    {
        //        case 0:
        //            aceleration.x = 9.8f; aceleration.y = 0;
        //            currentIndex++;
        //            break;
        //        case 1:
        //            aceleration.x = 0; aceleration.y = -9.8f;
        //            currentIndex++;
        //            break;
        //        case 2:
        //            aceleration.x = -9.8f; aceleration.y = 0;
        //            currentIndex++;
        //            break;
        //        case 3:
        //            aceleration.x = 0; aceleration.y = 9.8f;
        //            currentIndex = 0;
        //            break;

        //    }
        //}

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
            //velocity *= damping;

        }
        if (Mathf.Abs(position.y) > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
            //velocity *= damping;
        }

        transform.position = position;

    }
    
    void AplyForce(MyVector force)
    {
        aceleration = force / mass;
    }

}
