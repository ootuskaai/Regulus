﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regulus.Project.TurnBasedRPGUserConsole.BotStage
{
    class BodyMovements : Samebest.Game.IStage<StatusBotController>
    {

        void Samebest.Game.IStage<StatusBotController>.Enter(StatusBotController obj)
        {
            obj.User.PlayerProvider.Supply += PlayerProvider_Supply;
        }
        int _ToMoveTimeSecond;
        Samebest.Remoting.TimeCounter _ToMove;
        void PlayerProvider_Supply(TurnBasedRPG.IPlayer obj)
        {
            _ToMove = new Samebest.Remoting.TimeCounter();
            var actionStatus = Enum.GetValues(typeof(Regulus.Project.TurnBasedRPG.ActionStatue));
            if (actionStatus.Length > 0)
            {
                obj.BodyMovements((Regulus.Project.TurnBasedRPG.ActionStatue) Regulus.Utility.Random.Next(0, actionStatus.Length - 1));
                _ToMoveTimeSecond = 1;// Regulus.Utility.Random.Next(10, 30);   
            }
            
            
            
        }

        void Samebest.Game.IStage<StatusBotController>.Leave(StatusBotController obj)
        {
            obj.User.PlayerProvider.Supply -= PlayerProvider_Supply;
        }

        void Samebest.Game.IStage<StatusBotController>.Update(StatusBotController obj)
        {

            if (_ToMove != null)
            {
                var t = new System.TimeSpan(_ToMove.Ticks).TotalSeconds;
                if (t > _ToMoveTimeSecond)
                {
                    if (Regulus.Utility.Random.Next(0, 1) == 0)
                        obj.ToMove();
                    else
                        obj.ToBodyMovements();
                }
            }
        }
    }
}
