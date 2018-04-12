namespace Hatchet.Input
{
    public struct GenericInputManager<TState> : IGenericInputManager<TState>
    {
        public TState PreviousState { get; private set; }
        private TState state;

        public TState State
        {
            get => state;
            private set
            { PreviousState = state; state = value; }
        }

        public void Update(TState newState)
        {
            State = newState;
        }
    }
}
