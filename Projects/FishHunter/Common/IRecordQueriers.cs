﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VGame.Project.FishHunter
{
    public interface IRecordQueriers
    {
        Regulus.Remoting.Value<Data.Record> Load(Guid id);

        void Save(Data.Record record);
    }
    

    public interface ITradeAccount
    {
        Regulus.Remoting.Value<TradeNotes> Find(Guid id);
        
        Regulus.Remoting.Value<TradeNotes> Load(Guid id);

        //Regulus.Remoting.Value<Data.TradeData> Saving(Guid id);
        Regulus.Remoting.Value<Data.TradeData> Saving(Data.TradeData data);
    }
}
