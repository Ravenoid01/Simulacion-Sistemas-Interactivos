using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour
{
    //private Transform target;
    [SerializeField] private Transform target;
    [SerializeField] private MyVector force;
    [SerializeField] private MyVector aceleration;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector displacement;
    private MyVector position;

    int currentIndex = 0;
    //List<MyVector> aceleraciones = new List<MyVector>();

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }
    private void FixedUpdate()
    {
        //Cambiar la posición
        Move();

    }

    // Update is called once per frame
    void Update()
    {
        position.Draw(Color.red);
        displacement.Draw(Color.green, position);
        velocity.Draw(Color.cyan, position);
        aceleration.Draw(Color.green, position);

        // Codigo para que rebote en la paredes
        if (Input.GetKeyDown(KeyCode.Space))
        {
            velocity *= 0;
            switch (currentIndex)
            {
                case 0:
                    aceleration.x = 9.8f; aceleration.y = 0;
                    currentIndex++;
                    break;
                case 1:
                    aceleration.x = 0; aceleration.y = -9.8f;
                    currentIndex++;
                    break;
                case 2:
                    aceleration.x = -9.8f; aceleration.y = 0;
                    currentIndex++;
                    break;
                case 3:
                    aceleration.x = 0; aceleration.y = 9.8f;
                    currentIndex = 0;
                    break;

            }
        }

        aceleration = target.position - transform.position;

    }

    public void Move()
    {
        velocity += aceleration * Time.fixedDeltaTime;
        position += velocity * Time.fixedDeltaTime;

        //if (mathf.abs(position.x) > 5)
        //{
        //    //devuelve 1 si es positivo o -1 si es negativo
        //    position.x = mathf.sign(position.x) * 5;
        //    velocity.x *= -1;

        //}
        //if (mathf.abs(position.y) > 5)
        //{
        //    position.y = mathf.sign(position.y) * 5;
        //    velocity.y *= -1;
        //}

        transform.position = position;

    }

}
