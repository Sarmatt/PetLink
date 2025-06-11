namespace AnimalSystem.StateMachineSystem.States
{
    public abstract class BaseAnimalState
    {
        protected AnimalStateMachine StateMachine { get; private set; }

        public virtual void Init(AnimalStateMachine stateMachine)
        {
            StateMachine = stateMachine;
            OnEnter();
        }

        protected virtual void OnEnter()
        {
        }

        protected virtual void OnExit()
            => StateMachine.SetDefaultState();

        public virtual void Break()
        {
        }
    }
}