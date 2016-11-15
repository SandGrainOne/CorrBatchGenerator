using System.IO;
using Altinn.ExternalUtilities.CorrBatchGenerator.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Altinn.ExternalUtilities.CorrBatchGeneratorTest
{
    /// <summary>
    /// Test class with unit tests for the <see cref="DatasourceReader"/> class.
    /// </summary>
    [TestClass]
    public class DatasourceReaderTest
    {
        /// <summary>
        /// Scenario: Reading a null file
        /// </summary>
        [TestMethod]
        public void ReadTest_no_file_gives_no_content()
        {
            DatasourceReader reader = new DatasourceReader(null);
            reader.ReadFile();
            Assert.AreEqual(0, reader.Count);
        }

        /// <summary>
        /// Scenario: Giving a file path where directory does not exists
        /// </summary>
        [TestMethod]
        public void ReadTest_file_not_found_throws_exception()
        {
            DatasourceReader reader = new DatasourceReader(@"C:\tullball\data.csv");
            DirectoryNotFoundException exception = null;
            try
            {
                reader.ReadFile();
            }
            catch (DirectoryNotFoundException ex)
            {
                exception = ex;
            }

            Assert.IsNotNull(exception);
        }

        /// <summary>
        /// Scenario: Read a CSV file which is empty
        /// </summary>
        [TestMethod]
        public void ReadTest_file_is_empty_gives_empty_Dataset()
        {
            DatasourceReader reader = new DatasourceReader(@"Testdata\Empty.csv");
            reader.ReadFile();
            Assert.AreEqual(0, reader.Count);
        }

        /// <summary>
        /// Scenario: Reading a valid file 
        /// </summary>
        [TestMethod]
        public void ReadTest_file_is_valid_gives_two_Correspondances()
        {
            DatasourceReader reader = new DatasourceReader(@"Testdata\ValidTwoRows.csv");
            reader.ReadFile();
            Assert.AreEqual(2, reader.Count);
            Assert.AreEqual("1001", reader[0].Reportee);
            Assert.AreEqual("1002", reader[1].Reportee);
        }
    }
}
