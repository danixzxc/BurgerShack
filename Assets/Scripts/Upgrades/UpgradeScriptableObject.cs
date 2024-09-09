using UnityEngine;

public enum Type
{
    PlayerSpeed,
    BurgerSpeed,
    CashSpeed
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Upgrade", order = 1)]

public class UpgradeScriptableObject : ScriptableObject
{
    public Type type;
    public int maxLevel;
    public float defaultValue;
    public float increaseValue;
    public int defaultPrice;
    public int priceIncrease;
    
}