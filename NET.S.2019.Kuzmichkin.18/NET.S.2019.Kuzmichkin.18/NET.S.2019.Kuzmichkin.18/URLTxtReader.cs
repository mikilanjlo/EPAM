using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2019.Kuzmichkin._18
{
    public class URLTxtReader
    {
        private string[] urls;

        public string[] URLs
        {
            get
            {
                return urls;
            }
        }

        /// <summary>
        /// Initializes a new instance of the URLsContainer class.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>instance</returns>
        public URLTxtReader(string filePath)
        {
            if (filePath == null)
                throw new ArgumentException("Invalid path");
            SetUrls(filePath);
        }

        /// <summary>
        /// Reades all lines from file to string array
        /// </summary>
        /// <param name="filePath"></param>
        private void SetUrls(string filePath)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException("Incorrect file path");

            urls = File.ReadAllLines(filePath);
        }
    }
}
