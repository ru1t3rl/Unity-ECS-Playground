using Packages.Pong.Scripts.DataComponents.PaddleMovement;
using Unity.Entities;

public class PaddleMovementDataBaker : Baker<PaddleMovementDataAuthoring>
{
    public override void Bake(PaddleMovementDataAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, new PaddleMovementData
        {
            direction = authoring.direction,
            speed = authoring.speed
        });
    }
}