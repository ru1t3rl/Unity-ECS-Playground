using Unity.Entities;
using UnityEngine;

public struct PaddleInputData : IComponentData
{
    public KeyCode upKey;
    public KeyCode downKey;
}