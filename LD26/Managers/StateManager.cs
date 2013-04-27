using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LD26.States;

namespace LD26.Managers
{
    class StateManager
    {
        #region Singlation
        private static StateManager instance;

        public static StateManager Instance
        {
            get
            {
                return instance ?? (instance = new StateManager());
            }
        }

        protected StateManager()
        {
            states = new Stack<State>();
        }
        #endregion
        private readonly Stack<State> states;

        public State CurrentState
        {
            get
            {
                return states.Peek();
            }
            set
            {
                var state = value;
                state.Init();
                states.Push(state);
            }
        }

        public void GoLastState()
        {
            if (states.Count > 0)
                CurrentState = states.Pop();
        }
    }
}
