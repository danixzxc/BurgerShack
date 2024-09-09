using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CashZone : LoadingZone
{
    private ClientCashQueue _cashQueue;
    private ClientBurgerQueue _burgerQueue;
    [SerializeField]
    private ActivateSellZone _activateSellZone;
    [SerializeField]
    private MoneyManager _moneyManager;
    [SerializeField]
    private int _burgerPrice;

    private void Start()
    {
        _cashQueue = FindObjectOfType<ClientCashQueue>();
        _burgerQueue = FindObjectOfType<ClientBurgerQueue>();
    }

    protected override void LoadingCompleted(Collider player)
    {
        // если выполняется условие то запустить загрузку заново (принять следующего 
        // клиента не выходя из collider'a)
        _moneyManager.ChangeMoneyAmount(_burgerPrice);
        Client client = _cashQueue.RemoveFirstClient();
        _cashQueue.MoveQueueOneStep();
        _burgerQueue.AddClient(client);
        if (_burgerQueue.IsFull())
            _activateSellZone.SetBurgerQueueFullness(true);
        client.GetComponent<NavMeshAgent>().SetDestination(_burgerQueue.GetAvaialbleQueuePlace());
        base.LoadingCompleted(player);
        if(_activateSellZone.IsSellZoneActive())
            StartLoading(player);
    }
}
