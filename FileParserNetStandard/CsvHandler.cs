using System;
using System.Collections.Generic;
using System.Diagnostics;
using FileParserNetStandard;
using Delegate_Exercise;

namespace Delegate_Exercise {

    public delegate List<List<string>> Parser(List<List<string>> data);

    public class CsvHandler {

        FileHandler _fh = new FileHandler();

        /// <summary>
        /// Takes a list of list of strings applies datahandling via dataHandler delegate and writes result as csv to writeFile.
        /// </summary>
        /// <param name="readFile"></param>
        /// <param name="writeFile"></param>
        /// <param name="dataHandler"></param>
        public void ProcessCsv(string readFile, string writeFile, Func<List<List<string>>, List<List<string>>> dataHandler)
        {
            List<List<string>> result = _fh.ParseCsv(_fh.ReadFile(readFile));
            _fh.WriteFile(writeFile, ',', dataHandler(result));
        }

        public void ProcessCsv(string readFile, string writeFile, Parser parser)
        {
            List<List<string>> result = _fh.ParseCsv(_fh.ReadFile(readFile));
            _fh.WriteFile(writeFile, ',', parser(result));
        }
    }
}