using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVelocity : MonoBehaviour
{
  
    [SerializeField] private MyVector aceleration;
    [SerializeField] private MyVector velocity;
    [SerializeField] private MyVector displacement;
    private MyVector position;
    int currentIndex;
    //List<MyVector> aceleraciones = new List<MyVector>();

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
        currentIndex = 0;
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

    }
    private void FixedUpdate()
    {
        //Cambiar la posición
        Move();

    }

    public void Move()
    {
        velocity = velocity + aceleration * Time.fixedDeltaTime;
        displacement = velocity * Time.fixedDeltaTime;
        position += displacement;

        if (Mathf.Abs(position.x) > 5)
        {
            //Devuelve 1 si es positivo o -1 si es negativo
            position.x = Mathf.Sign(position.x) * 5;
            velocity.x *= -1;

        }
        if (Mathf.Abs(position.y) > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            velocity.y *= -1;
        }

        transform.position = position;

    }
}
