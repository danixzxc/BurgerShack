using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientDestroyTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Client>() != null)
            Destroy(gameObject);
    }
}
