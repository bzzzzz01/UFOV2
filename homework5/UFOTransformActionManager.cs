using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOTransformActionManager : ActionManager, UFOActionManager , ActionCallback
{
    public float slowSpeed = 3;
    public float middleSpeed = 5;
    public float fastSpeed = 10;
    public FirstSceneController sceneController;
    public TransformFlyAction slowFlyAction, middleFlyAction, fastFlyAction;

    protected new void Start()
    {
        sceneController = Director.getInstance().currentSceneController as FirstSceneController;
        sceneController.ufoActionManager = this;

        slowFlyAction = TransformFlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), slowSpeed);
        middleFlyAction = TransformFlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), middleSpeed);
        fastFlyAction = TransformFlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), fastSpeed);

    }

    protected new void Update()
    {
        base.Update();
    }

    public void FlyUFO(GameObject ufo, int round)
    {
        if(round==1)
        {
            slowFlyAction = TransformFlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), slowSpeed);
            this.RunAction(ufo, slowFlyAction, this);
        }
        else if (round == 2)
        {
            middleFlyAction = TransformFlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), middleSpeed);
            this.RunAction(ufo, middleFlyAction, this);
        }
        else if (round == 3)
        {
            fastFlyAction = TransformFlyAction.getAction(new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f)), fastSpeed);
            this.RunAction(ufo, fastFlyAction, this);
        }
    }

    public void ActionEvent(Action source, GameObject gameObjectParam = null, ActionEventType events = ActionEventType.Compeleted,
                        int intParam = 0, string strParam = null)
    {
        UFOFactory ufofactory = Singleton<UFOFactory>.Instance;
        ufofactory.freeUFO(gameObjectParam);
    }

}