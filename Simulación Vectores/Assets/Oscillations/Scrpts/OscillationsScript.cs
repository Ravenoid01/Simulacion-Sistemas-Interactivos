using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillationsScript : MonoBehaviour
{
    private Vector3 position;
    [SerializeField]private float periodo = 2;
    [SerializeField] private float alcance = 3;
    // Start is called before the first frame update
    void Start()
    {
        position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float ruido = Mathf.Sin(4f * Time.time);
        transform.position = position + (Vector3.right + Vector3.up) * Mathf.Sin((2 * Mathf.PI * Time.time) / periodo) * alcance;
        //transform.position = new Vector3(Mathf.Sin(Time.time), transform.position.y, transform.position.z);
    }
}
