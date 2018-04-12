namespace Hatchet.Input
{
    public interface IGenericInputManager<TState>
    {
        TState PreviousState { get; }
        TState State { get; }

        void Update(TState newState);
    }
}
