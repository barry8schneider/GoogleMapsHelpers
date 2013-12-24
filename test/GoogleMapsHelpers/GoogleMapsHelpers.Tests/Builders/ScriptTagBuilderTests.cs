using GoogleMapsHelpers.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleMapsHelpers.Tests.Builders
{
    [TestClass]
    public class ScriptTagBuilderTests
    {
        private ScriptTagBuilder _scriptTagBuilder;

        [TestInitialize]
        public void SetUp()
        {
            _scriptTagBuilder = new ScriptTagBuilder();
        }

        [TestMethod]
        public void ScriptTagBuilder_Exists()
        {
            Assert.IsNotNull(_scriptTagBuilder);
        }

        [TestMethod]
        public void ScriptTagBuilder_GetResult_Test()
        {
            var expected = "<script type=\"text/javascript\"></script>";
            var actual = _scriptTagBuilder.GetResult();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScriptTagBuilder_SetScriptSource_Test()
        {
            var expected = "<script src=\"~/test.js\" type=\"text/javascript\"></script>";
            _scriptTagBuilder.SetScriptSource("~/test.js");
            var actual = _scriptTagBuilder.GetResult();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ScriptTagBuilder_AddScriptBody_Test()
        {
            var expected = "<script type=\"text/javascript\">var testVar = 0</script>";
            _scriptTagBuilder.AddScriptBody("var testVar = 0");
            var actual = _scriptTagBuilder.GetResult();

            Assert.AreEqual(expected, actual);
        }
    }
}
