﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdjustmentPlayerPhaseRule.cs" company="Regulus Framework">
//   Regulus Framework
// </copyright>
// <summary>
//   玩家阶段起伏的调整
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;


using Regulus.Utility;


using VGame.Project.FishHunter.Common.Data;
using VGame.Project.FishHunter.Formula.ZsFormula.Data;

namespace VGame.Project.FishHunter.Formula.ZsFormula.Rule
{
	/// <summary>
	///     玩家阶段起伏的调整
	/// </summary>
	public class AdjustmentPlayerPhaseRule
	{
		private readonly StageDataVisitor _StageVisitor;

		private static int RandNumber
		{
			get { return Random.Instance.NextInt(0, 1000); }
		}

		public AdjustmentPlayerPhaseRule(StageDataVisitor stage_visitor)
		{
			_StageVisitor = stage_visitor;
			
		}

		public void Run()
		{
			if (_StageVisitor.PlayerRecord.BufferValue < 0)
			{
				_StageVisitor.PlayerRecord.Status = 0;
			}

			if (_StageVisitor.PlayerRecord.Status > 0)
			{
				_StageVisitor.PlayerRecord.Status--;
			}
			else if(AdjustmentPlayerPhaseRule.RandNumber >= 200)
			{
				// 20%
				return;
			}

			// 從VIR00 - VIR03
			var enums = EnumHelper.GetEnums<StageBuffer.BUFFER_TYPE>().ToArray();

			for(var i = enums[(int)StageBuffer.BUFFER_TYPE.BUFFER_VIR_BEGIN];
			    i < enums[(int)StageBuffer.BUFFER_TYPE.BUFFER_VIR_END];
			    ++i)
			{
				var bufferData = _StageVisitor.FocusStageData.FindBuffer(_StageVisitor.FocusBufferBlock, i);

				var top = bufferData.Top * bufferData.BufferTempValue.AverageValue;

				if(bufferData.Buffer <= top)
				{
					continue;
				}

				if(AdjustmentPlayerPhaseRule.RandNumber < bufferData.Gate)
				{
					bufferData.Buffer -= top;

					_StageVisitor.PlayerRecord.Status = bufferData.Top * 5;
					_StageVisitor.PlayerRecord.BufferValue = top;
					_StageVisitor.PlayerRecord.StageRecords.Find(x => x.StageId == _StageVisitor.FocusStageData.StageId).AsnTimes += 1;
				}
				else
				{
					bufferData.Buffer = 0;
				}
			}
		}
	}
}