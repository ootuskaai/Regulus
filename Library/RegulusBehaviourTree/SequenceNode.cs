﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regulus.BehaviourTree
{
    class SequenceNode  : ITicker , IParent
    {
        private List<ITicker> _Childs;
        private readonly Queue<ITicker> _Queue;


        private ITicker _RunninTicker;

        public SequenceNode()
        {
            _Childs = new List<ITicker>();
            _Queue = new Queue<ITicker>();
        }

        void ITicker.Reset()
        {
            if (_RunninTicker != null)
            {
                _RunninTicker.Reset();
                _RunninTicker = null;
            }
            _Queue.Clear();
        }

        public TICKRESULT Tick(float delta)
        {
            if (_RunninTicker != null)
            {
                var resultRunner = _RunninTicker.Tick(delta);
                
                if (resultRunner == TICKRESULT.RUNNING)
                    return TICKRESULT.RUNNING;

                _RunninTicker = null;
                if (resultRunner == TICKRESULT.FAILURE)
                {
                    _Queue.Clear();
                    return TICKRESULT.FAILURE;
                }

                if (_Queue.Count == 0)
                {                    
                    return TICKRESULT.SUCCESS;
                }

            }

            if (_Queue.Count == 0)
            {
                _Reload();
            }

            var ticker = _Queue.Dequeue();
            var result = ticker.Tick(delta);
            if (result == TICKRESULT.FAILURE)
            {
                _Queue.Clear();
                return TICKRESULT.FAILURE;
            }


            if (result == TICKRESULT.RUNNING)
            {
                _RunninTicker = ticker;
                return TICKRESULT.RUNNING;
            }

            if (_Queue.Count == 0)
                return TICKRESULT.SUCCESS;
            
            return TICKRESULT.RUNNING;
        }

        private void _Reload()
        {
            
            foreach (var ticker in _Childs)
            {
                _Queue.Enqueue(ticker);
            }
        }


        public void Add(ITicker ticker)
        {
            _Childs.Add(ticker);
        }
    }
}
