using Unity.Entities;


public struct PaddleMovementData : IComponentData
{
    public int direction;
    public float speed;
}