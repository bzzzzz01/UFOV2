using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicFlyAction : Action
{
    public Vector3 direction;
    public float speed;

    public static PhysicFlyAction getAction(Vector3 direction, float speed)
    {
        PhysicFlyAction action = CreateInstance<PhysicFlyAction>();
        action.direction = direction;
        action.speed = speed;
        return action;
    }

    public override void Start()
    {
        this.GameObject.GetComponent<Rigidbody>().velocity = speed * direction;
    }

    public override void Update()
    {
        if (this.GameObject.transform.position.x > 20 || this.GameObject.transform.position.x < -20 ||
            this.GameObject.transform.position.y > 10 || this.GameObject.transform.position.y < -10 )
        {
            this.destroy = true;
            this.Callback.ActionEvent(this, this.GameObject, ActionEventType.Compeleted);
        }

    }

}