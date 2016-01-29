using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StateMachineManager : MonoBehaviour {

    private Stack<GameState> MenuStack = new Stack<GameState>();
    public GameEntry gameEntry;

    public void Push(GameState stateToPush)
    {
        MenuStack.Push(stateToPush);
        stateToPush.Enter();
    }

    public void Pop()
    {
        if (MenuStack.Count > 0)
        {
            MenuStack.Peek().Exit();
            MenuStack.Pop();
        }
        else
            UnityEngine.Debug.Log("YOU CANT POP AN EMPTY STACK");
    }

    public void StateUpdate(float delta_time)
    {
        if (MenuStack.Count > 0)
        {
            MenuStack.Peek().UpdateState(Time.deltaTime);
        }
        else
            UnityEngine.Debug.Log("You cant Update there are no states on the Stack");
    }

    public void Input()
    {
        if (MenuStack.Count > 0)
            MenuStack.Peek().Input();
    }

    public void ShutDown()
    {
        for (int i = 0; i < MenuStack.Count; i++)
        {
            Pop();
        }
    }
}
