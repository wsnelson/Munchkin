using UnityEngine;
using System.Collections;

public class MainMenuState : GameState
{

    public GameEntry game;

    public override void Enter()
    {
        
    }

    public override void Exit()
    {
        
    }

    public override void Input()
    {
       
        if (UnityEngine.Input.GetKeyDown(KeyCode.A))
        {
            UnityEngine.Debug.Log("WE Get Here");
            game.StateChangeRequest(GameState.GameStateType.SETUP_PLAYER);
        }
    }

    public override void UpdateState(float delata_time)
    {
        
    }

    public override void Render()
    {
        
    }
}
