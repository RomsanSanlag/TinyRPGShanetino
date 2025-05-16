using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "GiveDamage", story: "[Agent] attack [target] with [damage] damage", category: "Action", id: "209a8937c4b1881b3c845f00f0da8c6b")]
public partial class GiveDamageAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<PlayerHealth> Target;
    [SerializeReference] public BlackboardVariable<int> Damage;
    protected override Status OnStart()
    {
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        Target.Value.TakeDamage(Damage.Value);
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

