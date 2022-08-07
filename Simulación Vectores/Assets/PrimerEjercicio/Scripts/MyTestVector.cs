using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTestVector : MonoBehaviour
{
    [SerializeField]
    private MyVector myFirstVector;

    [SerializeField]
    private MyVector mySecondVector;

    private MyVector myrestvector;
    private MyVector myInterpolation;

    [SerializeField]
    [Range(0f,1f)]
    private float escalar;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        myFirstVector.Draw(Color.red);
        mySecondVector.Draw(Color.blue);

        myInterpolation = myFirstVector.Mix(mySecondVector, escalar);
        myrestvector = (mySecondVector - myFirstVector)*escalar;

        myrestvector.Draw(Color.yellow, myFirstVector);
        myInterpolation.Draw(Color.green);
    }
}
