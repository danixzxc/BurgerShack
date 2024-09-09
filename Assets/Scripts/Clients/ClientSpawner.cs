using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClientSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _clientPrefab;
    [SerializeField]
    private ClientCashQueue _cashQueue;
    [SerializeField]
    private int _spawnDelay;

    private float _timer = 0f;
    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > _spawnDelay && !_cashQueue.IsFull())
        {
            _timer = 0f;
            var client = Instantiate(_clientPrefab, new Vector3(-3,1,18), Quaternion.identity);
            _cashQueue.AddClient(client.GetComponent<Client>());
            client.GetComponentInChildren<NavMeshAgent>().destination = _cashQueue.GetAvaialbleQueuePlace();
        }
    }
}
