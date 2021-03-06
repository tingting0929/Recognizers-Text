﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DateObject = System.DateTime;

namespace Microsoft.Recognizers.Text.DateTime.Chinese.Tests
{
    [TestClass]
    public class TestDurationChsParser
    {
        readonly DateObject refTime;
        private readonly DurationExtractorChs extractor = new DurationExtractorChs();
        private readonly DurationParserChs parser = new DurationParserChs(new ChineseDateTimeParserConfiguration());

        public TestDurationChsParser()
        {
            refTime = new DateObject(2017, 3, 22);
        }

        public void BasicTest(string text, string timex)
        {
            var er = extractor.Extract(text);
            Assert.AreEqual(1, er.Count);
            var pr = parser.Parse(er[0], refTime);
            Assert.AreEqual(Constants.SYS_DATETIME_DURATION, pr.Type);
            Assert.AreEqual(timex, ((DTParseResult) pr.Value).Timex);
        }


        [TestMethod]
        public void TestTimeParser()
        {
            BasicTest("两年", "P2Y");
            BasicTest("5分钟", "PT5M");
            BasicTest("3天", "P3D");
            BasicTest("15周", "P15W");
        }
    }
}