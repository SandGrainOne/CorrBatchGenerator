using System;
using System.Collections.Generic;
using System.IO;
using Altinn.ExternalUtilities.CorrBatchGenerator.Entities;

namespace Altinn.ExternalUtilities.CorrBatchGenerator.Utils
{
    /// <summary>
    /// Class for reading a Data source as CSV file
    /// </summary>
    public class DatasourceReader
    {
        private readonly List<CorrespondenceInput> correspondenceInput = new List<CorrespondenceInput>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DatasourceReader"/> class
        /// </summary>
        /// <param name="filePath">The filePath of the data source CSV file to be loaded</param>
        public DatasourceReader(string filePath)
        {
            this.FilePath = filePath;
        }

        /// <summary>
        /// Gets the given FilePath for the Data source
        /// </summary>
        public string FilePath { get; private set; }

        /// <summary>
        /// Gets the number of correspondences in the data source file
        /// </summary>
        public int Count
        {
            get
            {
                return this.correspondenceInput.Count;
            }
        }

        /// <summary>
        /// Gets a Correspondence in the file
        /// </summary>
        /// <param name="index">zero based index</param>
        /// <returns>The correspondence</returns>
        /// <exception cref="IndexOutOfRangeException">When illegal index</exception>
        public CorrespondenceInput this[int index]
        {
            get
            {
                return this.correspondenceInput[index];
            }
        }
        
        /// <summary>
        /// Loading the file to internal structure
        /// </summary>
        /// <exception cref="DirectoryNotFoundException">FilePath given in constructor contains a non-existing directory</exception>
        /// <exception cref="FileNotFoundException">FilePath given in constructor contains a non-existing filename</exception>
        public void ReadFile()
        {
            if (string.IsNullOrEmpty(this.FilePath))
            {
                return;
            }

            using (StreamReader file = new StreamReader(this.FilePath))
            {
                // Read the header line
                string line = file.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    return;
                }

                while ((line = file.ReadLine()) != null)
                {
                    string[] cols = line.Split(',', ';');
                    CorrespondenceInput corinput = new CorrespondenceInput
                    {
                        Reportee = cols[0],
                        LanguageCode = cols[1],
                        MessageTitle = cols[2],
                        MessageBody = cols[3],
                        MessageSummary = cols[4],
                        VisibleDateTime = DateTime.Parse(cols[5]),
                        IsReservable = bool.Parse(cols[6]),
                    };
                    this.correspondenceInput.Add(corinput);
                }
            }
        }

        /// <summary>
        /// Gets an Enumerable over all Correspondence in the source file
        /// </summary>
        /// <returns>Correspondence input enumerable</returns>
        public IEnumerable<CorrespondenceInput> GetEnumerable()
        {
            return this.correspondenceInput;
        }
    }
}
