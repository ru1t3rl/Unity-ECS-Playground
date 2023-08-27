using Unity.Entities;

public class PaddleInputDataBaker : Baker<PaddleInputDataAuthoring>
{
    public override void Bake(PaddleInputDataAuthoring dataAuthoring)
    {
        var entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, new PaddleInputData
        {
            upKey = dataAuthoring.upKey,
            downKey = dataAuthoring.downKey
        });
    }
}