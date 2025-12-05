using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CoreLib
{
    public class StageReducerT<StageT> : MonoBehaviour where StageT : Enum
    {
        public static event Action<StageT> OnStageChange;
        public static event Action<StageT> OnStagePush;
        public static event Action OnStagePop;
        
        public static StageReducerT<StageT> Current;
        public StageT PrevStage;
        public StageT Stage;
        
        private Dictionary<StageT, Action> _stageEnterActions = new();
        private Dictionary<StageT, Action> _stageExitActions = new();

        private Stack<StageT> _stack = new();

        void Awake()
        {
            Current = this;
            OnStageChange += ChangeStage;
            OnStagePush += PushStage;
            OnStagePop += PopStage;
        }
        
        void ChangeStage(StageT stage)
        {
            _stack.Clear();
            _stack.Push(stage);
            SetStage(stage);
        }

        void PushStage(StageT stage)
        {
            _stack.Push(stage);
            SetStage(stage);
        }

        void PopStage()
        {
            _stack.Pop();
            var stage = _stack.Peek();
            SetStage(stage);
        }

        void SetStage(StageT stage)
        {
            if (Equals(Stage, stage))
                return;
            if (_stageExitActions.ContainsKey(Stage))
            {
                _stageExitActions[Stage]();
            }
            if (_stageEnterActions.ContainsKey(stage))
            {
                _stageEnterActions[stage]();
            }
            PrevStage = Stage;
            Stage = stage;
        }

        public void AddEnterAction(StageT stage, Action action)
        {
            _stageEnterActions[stage] = action;
        }

        public void AddExitAction(StageT stage, Action action)
        {
            _stageExitActions[stage] = action;
        }

        public static void EmitStageChange(StageT stage)
        {
            OnStageChange?.Invoke(stage);
        }

        public static void EmitStagePush(StageT stage)
        {
            OnStagePush?.Invoke(stage);
        }

        public static void EmitStagePop()
        {
            OnStagePop?.Invoke();
        }
    }
}