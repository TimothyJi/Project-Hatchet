namespace Hatchet.Input
{
    public class GenericInputManager<TState> : IGenericInputManager<TState>
    {
        public TState PreviousState { get; private set; }
        public TState State { get; private set; }

        public void Update(TState newState)
        {
            PreviousState = State;
            State = newState;
        }
    }
}
