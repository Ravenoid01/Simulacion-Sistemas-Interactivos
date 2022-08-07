using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVelocity : MonoBehaviour
{
    private MyVector position;
    [SerializeField]
    private MyVector displacement;

    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;  //position = new MyVector(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {

        //Debug Vectors 
        position.Draw(Color.red);
        displacement.Draw(Color.green, position);
    }
    public void Move()
    {
        position = position + displacement;
        
        if(Mathf.Abs(position.x) > 5)
        {
            //Devuelve 1 si es positivo o -1 si es negativo
            position.x = Mathf.Sign(position.x) * 5;
            displacement.x *= -1;
        }
        if (Mathf.Abs(position.y) > 5)
        {
            position.y = Mathf.Sign(position.y) * 5;
            displacement.y *= -1;
        }

        transform.position = position;

    }
}
