using UnityEngine;
using System.Collections;

public abstract class GameState : MonoBehaviour {

    public enum GameStateType
    {
        SPLASH_SCREEN, MAIN_MENU, CREATE_LOBBY, FIND_LOBBY, SETUP_PLAYER, DEALING, PREGAME_EQUIP,
        DETERMINE_ORDER, PRE_DOOR_KICK, DOOR_KICK, FOUND_MONSTER, PICK, LOOT_THE_ROOM, LOOK_FOR_TROUBLE,
        CHARITY, VICTORY, STATS, NOT_SET
    };
    
    public GameStateType stateType;

    public abstract void Enter();
    public abstract void Exit();
    public abstract void Input();
    public abstract void UpdateState(float delata_time);
    public abstract void Render();
}
