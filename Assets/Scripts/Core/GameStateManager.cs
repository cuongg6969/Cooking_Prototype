using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;
    public GameState CurrentState { get; private set; } = GameState.World;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetState(GameState newState)
    {
        if (newState == CurrentState) return;

        GameState previous = CurrentState;
        CurrentState = newState;

        Debug.Log($"[GameState] {previous} -> {newState}");

        EventBus.Publish(new OnGameStateChanged
        {
            previous = previous,
            current = newState
        });
    }

    public bool IsState(GameState state) => CurrentState == state;
}
