﻿#region Designer generated code

using Microsoft.VisualStudio.TestTools.UnitTesting;

#pragma warning disable

namespace GameTest.ZsFormulaTest
{
	using TechTalk.SpecFlow;

	[System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
	[System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	[Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
	public partial class ZsFishStageDataCheckFeature
	{
		private static ITestRunner testRunner;

		[Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
		public static void FeatureSetup(TestContext testContext)
		{
			ZsFishStageDataCheckFeature.testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
			var featureInfo = new TechTalk.SpecFlow.FeatureInfo(
				new System.Globalization.CultureInfo("en-US"), 
				"ZsFishStageDataCheck", 
				"In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
				"wo numbers", 
				ProgrammingLanguage.CSharp, 
				(string[])(null));
			ZsFishStageDataCheckFeature.testRunner.OnFeatureStart(featureInfo);
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
		public static void FeatureTearDown()
		{
			ZsFishStageDataCheckFeature.testRunner.OnFeatureEnd();
			ZsFishStageDataCheckFeature.testRunner = null;
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
		public virtual void TestInitialize()
		{
			if((TechTalk.SpecFlow.FeatureContext.Current != null)
			    && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "ZsFishStageDataCheck"))
			{
				GameTest.ZsFormulaTest.ZsFishStageDataCheckFeature.FeatureSetup(null);
			}
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
		public virtual void ScenarioTearDown()
		{
			ZsFishStageDataCheckFeature.testRunner.OnScenarioEnd();
		}

		public virtual void ScenarioSetup(ScenarioInfo scenarioInfo)
		{
			ZsFishStageDataCheckFeature.testRunner.OnScenarioStart(scenarioInfo);
		}

		public virtual void ScenarioCleanup()
		{
			ZsFishStageDataCheckFeature.testRunner.CollectScenarioErrors();
		}

		[Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
		[Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("取得0號魚場資料")]
		[Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ZsFishStageDataCheck")]
		public virtual void 取得0號魚場資料()
		{
			var scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("取得0號魚場資料", (string[])(null));
#line 6
			this.ScenarioSetup(scenarioInfo);
#line hidden
			var table1 = new TechTalk.SpecFlow.Table(
				new[]
				{
					"StageId", 
					"Name", 
					"SizeType", 
					"BaseOdds", 
					"GameRate", 
					"MaxBet", 
					"NowBaseOdds", 
					"BaseChgOddsCnt"
				});
			table1.AddRow(
				new[]
				{
					"1", 
					"魚場1", 
					"SMALL", 
					"100", 
					"995", 
					"1000", 
					"0", 
					"0"
				});
			table1.AddRow(
				new[]
				{
					"2", 
					"魚場2", 
					"MEDIUM", 
					"200", 
					"995", 
					"1000", 
					"0", 
					"0"
				});
			table1.AddRow(
				new[]
				{
					"3", 
					"魚場3", 
					"MEDIUM", 
					"200", 
					"995", 
					"1000", 
					"0", 
					"0"
				});
			table1.AddRow(
				new[]
				{
					"4", 
					"魚場4", 
					"LARGE", 
					"300", 
					"995", 
					"1000", 
					"0", 
					"0"
				});
#line 8
			ZsFishStageDataCheckFeature.testRunner.Given("魚場資料表是", (string)(null), table1, "Given ");
#line 15
			ZsFishStageDataCheckFeature.testRunner.When(
				"當輸入魚場id是 1", 
				(string)(null), 
				(TechTalk.SpecFlow.Table)(null), 
				"When ");
#line hidden
			var table2 = new TechTalk.SpecFlow.Table(
				new[]
				{
					"StageId", 
					"Name", 
					"SizeType", 
					"BaseOdds", 
					"GameRate", 
					"MaxBet", 
					"NowBaseOdds", 
					"BaseChgOddsCnt"
				});
			table2.AddRow(
				new[]
				{
					"1", 
					"魚場1", 
					"SMALL", 
					"100", 
					"995", 
					"1000", 
					"0", 
					"0"
				});
#line 17
			ZsFishStageDataCheckFeature.testRunner.Then("取得的魚場資料是", (string)(null), table2, "Then ");
#line hidden
			this.ScenarioCleanup();
		}
	}
}

#pragma warning restore

#endregion