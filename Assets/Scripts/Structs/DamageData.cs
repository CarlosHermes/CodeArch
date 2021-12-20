[System.Serializable]
public struct DamageData
{
    public float damage;
    public ElementalType elementalType;
    
    public DamageData(float damage, ElementalType elementalType)
    {
        this.damage = damage;
        this.elementalType = elementalType;
    }
}
