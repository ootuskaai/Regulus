// <copyright file="ActionNodeTest.cs">Copyright ©  2016</copyright>
using System;
using System.Linq.Expressions;
using System.Net.NetworkInformation;



using Regulus.BehaviourTree;

namespace Regulus.BehaviourTree.Tests
{
    /// <summary>此類別包含 ActionNode 的參數化單元測試</summary>
    
    
    
    public partial class ActionNodeTest
    {
        [NUnit.Framework.Test()]
        public void ActionTick()
        {            
            var node = new ActionNode<NumberTestNode>( ()=> new NumberTestNode(3) 
                , (ntn) => ntn.Tick
                , (ntn) => ntn.Start
                , (ntn) => ntn.End);
            ITicker ticker = node;
            var result1 = ticker.Tick(0);
            ticker.Tick(0);
            var result2 = ticker.Tick(0);
            var result3 = ticker.Tick(0);            


            NUnit.Framework.Assert.AreEqual(TICKRESULT.RUNNING , result1);            
            NUnit.Framework.Assert.AreEqual(TICKRESULT.SUCCESS, result2);
            NUnit.Framework.Assert.AreEqual(TICKRESULT.FAILURE, result3);
        }
    }

    public class NumberTestNode
    {
        private int _NumI;

        public TICKRESULT Tick(float delta)
        {
            _NumI --;
            if(_NumI > 0)
                return TICKRESULT.RUNNING;
            if (_NumI == 0)
                return TICKRESULT.SUCCESS;

            return TICKRESULT.FAILURE;
        }

        public NumberTestNode(int num_i)
        {
            _NumI = num_i;
            
        }

        public void Start()
        {
            
        }

        public void End()
        {
            
        }
    }
}
