public abstract class State
{
    protected GameManager manager;

    public abstract void EnterState();
    public abstract void ExitState();
}
