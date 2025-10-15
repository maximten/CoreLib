using System;
using System.Collections.Generic;
using UnityEngine;

namespace CoreLib
{
    public class StageReducerT<StageT> : MonoBehaviour where StageT : Enum
    {
        public static StageReducerT<StageT> Current;
        
        private Dictionary<StageT, Action> _stageEnterActions = new();
        private Dictionary<StageT, Action> _stageExitActions = new();
        
        public StageT PrevStage;
        public StageT Stage;
        
        void Awake()
        {
            Current = this;
        }
        
        public void ChangeStage(StageT stage)
        {
            if (Equals(PrevStage, stage))
                return;
            if (_stageExitActions.ContainsKey(PrevStage))
            {
                _stageExitActions[PrevStage]();
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
    }
}