using UnityEngine;

// ── Player ──────────────────────────────────────────
public struct OnPlayerHpChanged
{
    public int current;
    public int max;
}

public struct OnPlayerGoldChanged
{
    public int current;
}

public struct OnPlayerLevelUp
{
    public int newLevel;
}

// ── Combat ──────────────────────────────────────────
public struct OnEnemyKilled
{
    public string enemyId;
    public Vector2 position;
}

public struct OnPlayerDamaged
{
    public int damage;
    public ElementType source;
}

public struct OnSkillActivated
{
    public SkillSO skill;
}
public struct OnPlayerDied { }
public struct OnEnemySpawned
{
    public string enemyId;
    public Vector2 position;
}

//── Turn-Base ─────────────────────────────────────────
public struct OnTurnStarted
{
    public TurnOwner owner;
}
public struct OnTurnEnded
{
    public TurnOwner owner;
}
public struct OnEntityMoved
{
    public string entityId; public Vector2Int from;
    public Vector2Int to;
}
public struct OnCombatStarted
{
    public bool isBossFight;
}
public struct OnCombatEnded
{
    public bool playerWon;
}
public struct OnBossPhaseChanged
{
    public int newPhase;
}
public struct OnAllyJoined
{
    public AllySO ally;
}


//── Cooking ─────────────────────────────────────────
public struct OnDishCompleted
{
    public DishResult result;
}

public struct OnCookingStepPassed
{
    public int stepIndex;
    public float accuracy;
}

public struct OnCookingFailed
{
    public string reason;
}

public struct OnCookingStarted
{
    public RecipeSO recipe;
}
public struct OnDishAdded
{
    public DishResult result;
}

// ── Inventory ───────────────────────────────────────
public struct OnIngredientHarvested
{
    public IngredientSO data;
}

public struct OnItemAdded
{
    public string itemId;
}

public struct OnItemRemoved
{
    public string itemId;
}
// ── Restaurant ──────────────────────────────────────
public struct OnCustomerArrived
{
    public string customerId;
}

public struct OnOrderServed
{
    public float satisfaction;
}

public struct OnReputationChanged
{
    public int current;
}

// ── Game State ──────────────────────────────────────
public struct OnGameStateChanged
{
    public GameState previous;
    public GameState current;
}

// ── Mediapipe ───────────────────────────────────────
public struct OnGestureDetected
{
    public GestureType gestureType;
    public float confidence;
}