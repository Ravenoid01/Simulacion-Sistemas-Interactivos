using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocurrencyScript : MonoBehaviour
{
    void Start()
    {
        var enumeratorObject = DoSomething();
        StartCoroutine(enumeratorObject);
    }
    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime;
    }

    IEnumerator DoSomething()
    {
        Debug.Log("Started corroutine");
        yield return new WaitForSeconds(10f);
        Debug.Log("Ended corroutine");
    }

}
