using UnityEngine;
using System.Collections;

public class GameEntry : MonoBehaviour
{

    public bool shouldChangeState = false;
    public StateMachineManager stateMachine;
    public bool gameShouldRun = false;
    private GameState.GameStateType StateToChangeTo = GameState.GameStateType.NOT_SET;

    // Use this for initialization
    void Start()
    {
        //Let the state machine run and boot into the main menu
        gameShouldRun = true;
        MainMenuState menuState = new MainMenuState();
        menuState.game = this;
        stateMachine.Push(menuState);
        UnityEngine.Debug.Log("Game Started");
    }

public void Update()
    {
        if (gameShouldRun)
        {
            Input();
            UpdateGame();

            //handle State Change Request
            if (shouldChangeState)
                ChangeState(StateToChangeTo);

        }
        else
        {
            UnityEngine.Debug.Log("Game Stopped");
            Application.Quit();
        }
    }

    public void Input()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
            gameShouldRun = false;
        stateMachine.Input();
    }

    public void UpdateGame()
    {
        stateMachine.StateUpdate(Time.deltaTime);
    }

    public void StateChangeRequest(GameState.GameStateType stateToSwitchTo)
    {
        if (shouldChangeState)
            UnityEngine.Debug.LogError("Already Requested to Switching States");
        StateToChangeTo = stateToSwitchTo;
        shouldChangeState = true;
    }

    private void ChangeState(GameState.GameStateType stateToChangeTo)
    {
        //Make Sure the new state was set up 
        if (stateToChangeTo == GameState.GameStateType.NOT_SET)
            UnityEngine.Debug.LogError("You Can't change to a state without setting the new state");

        //pop the old one off
        stateMachine.Pop();

        //Create the New State based on the request
        switch (stateToChangeTo)
        {
            case GameState.GameStateType.SETUP_PLAYER:
                {
                    SetupPlayerState setupState = new SetupPlayerState();
                    setupState.game = this;
                    stateMachine.Push(setupState);
                }
                break;
        }

        shouldChangeState = false;
    }
}
