using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GiveBurgerZone : LoadingZone
{
    [SerializeField]
    private BurgerSlot _burgerSlot;
    [SerializeField]
    private Transform _getBurgerTrigger;
    [SerializeField]
    private ActivateSellZone _activateSellZone;

    private ClientBurgerQueue _burgerQueue;

    private void Start()
    {
        _burgerQueue = FindObjectOfType<ClientBurgerQueue>();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BurgerSlot>().HasBurger() && !_burgerSlot.HasBurger())
        {
            base.OnTriggerEnter(other);
        }
    }
    protected override void LoadingCompleted(Collider player)
    {
        _activateSellZone.SetBurgerQueueFullness(false);
        base.LoadingCompleted(player);
        _burgerSlot.AddBurger();
        player.GetComponent<BurgerSlot>().RemoveBurger();

        if (!_burgerQueue.IsEmpty())
        {
            Client client = _burgerQueue.GetFirstClient();
            client.GetComponent<NavMeshAgent>().SetDestination(_getBurgerTrigger.position);
        }
    }
}
