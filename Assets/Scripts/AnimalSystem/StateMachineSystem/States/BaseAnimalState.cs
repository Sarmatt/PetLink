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
        
        protected virtual void OnEnter() { }
        public virtual void OnExit() { }
    }
}