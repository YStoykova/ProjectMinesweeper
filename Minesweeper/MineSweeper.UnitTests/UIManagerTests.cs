using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleMinesweeper;
using Minesweeper.Core;
using Moq;
using System.IO;
using System.Collections.Generic;

namespace Minesweper.UnitTests
{
    [TestClass]
    public class UIManagerTests
    {
        private static UIManager manager;
        private static UIManager mockedManager;
        private static Mock<IRenderer> renderer;
        private static Mock<IUserInputReader> inputReader;

        [ClassInitialize]
        public static void ClassInitialization(TestContext ctx)
        {
            manager = new UIManager();
            renderer = new Mock<IRenderer>();
            inputReader = new Mock<IUserInputReader>();
            mockedManager = new UIManager(renderer.Object, inputReader.Object);
        }

        [TestMethod]
        public void DisplayIntroShouldPrintInTheConsoleProperMessage()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                manager.DisplayIntro("Message");

                string expected = string.Format("{0}", "Message");
                Assert.AreEqual<string>(expected, sw.ToString(), "Printed intro message is not correct.");
            }
        }
        [TestMethod]
        public void CreateMinefieldWithId()
        {
            //arrange
            string input = "4 5";
            bool isValid = manager.ParseInput(input);

            Assert.IsNull(manager.minefields);
            Assert.AreEqual(manager.minefields.Count, 1);
            Assert.IsNotNull(manager.minefield);
            Assert.AreEqual(manager.minefield.Id, 1);
            Assert.IsTrue(isValid);
        }
    }
}
