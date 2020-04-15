﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flee.CalcEngine.PublicTypes;
using Flee.PublicTypes;
using NUnit.Framework;

namespace Flee.Test.CalcEngineTests
{
    [TestFixture]
    public class LongScriptTests
    {
        private SimpleCalcEngine _myEngine;

        public LongScriptTests()
        {
            var engine = new SimpleCalcEngine();
            var context = new ExpressionContext();
            context.Imports.AddType(typeof(Math));
			//            context.Imports.AddType(typeof(Math), "math");

			//' add convert methods e.g. .ToInt64, .ToString, .ToDateTime...  https://msdn.microsoft.com/en-us/library/system.convert.aspx?f=255&MSPPError=-2147217396 
			context.Imports.AddType(typeof(Convert));
			context.Options.ParseCulture = CultureInfo.InvariantCulture;

			engine.Context = context;
            _myEngine = engine;
        }

        [Test]
        public void LongScriptWithManyFunctions()
        {
			var script = Flee.Tests.Properties.Resources.LongScriptWithManyFunctions;
			var expr = _myEngine.Context.CompileDynamic(script);
			var result = expr.Evaluate();

			Assert.AreEqual(84.0d, result);
		}


		[Test]
		public void FailingLongScriptWithManyFunctions()
		{
			var script = Flee.Tests.Properties.Resources.FailingLongScriptWithManyFunctions;
			var expr = _myEngine.Context.CompileDynamic(script);
			var result = expr.Evaluate();

			Assert.AreEqual(84.0d, result);
		}
	}
}
