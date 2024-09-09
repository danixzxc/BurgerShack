using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions;

public abstract class ClientQueue : MonoBehaviour
{
    [SerializeField]
    private int _maxAmount;
    [SerializeField]
    private Transform _queueStartTransform;
    [SerializeField]
    private float _clientSpacing;

    private List<Client> _clients;

    private void Start()
    {
        _clients = new List<Client>();
    }

    public void AddClient(Client client)
    {
        if (_clients.Count < _maxAmount)
            _clients.Add(client);
    }

    public Client RemoveFirstClient()
    {
        Client client = _clients[0];
        _clients.RemoveAt(0);
        return client;
    }

    public Client GetLastClient()
    {
        return _clients[_clients.Count - 1];
    }

    public Client GetFirstClient()
    {
        return _clients[0];
    }

    public int GetCount()
    {
        return _clients.Count;
    }

    public bool IsFull()
    {
        if (_clients.Count >= _maxAmount)
            return true;
        else
            return false;
    }
    public bool IsEmpty()
    {
        if (_clients.Count == 0)
            return true;
        else
            return false;
    }

    public void MoveQueueOneStep()
    {
        foreach (Client client in _clients)
        {
            client.GetComponent<NavMeshAgent>().destination = GetClientQueuePlace(_clients.IndexOf(client));
        }
    }    

    public Vector3 GetClientQueuePlace(int clientId)
    {
        if (clientId == 0)
        {
            return _queueStartTransform.position;
        }
        else
        {
            return new Vector3(_queueStartTransform.position.x, _queueStartTransform.position.y,
                _queueStartTransform.position.z + _clientSpacing * clientId);
        }
    }

    public virtual Vector3 GetAvaialbleQueuePlace()
    {
        Assert.AreNotEqual(0, _clients.Count);
        return GetClientQueuePlace(_clients.Count - 1);
    }
    public abstract Vector3 GetServicedClientTarget();
}
