﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Analyzer.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analyzer.Parsing;

namespace Analyzer.Pipeline.Tests
{
    [TestClass()]
    public class TestDepth
    {
        [TestMethod()]
        public void TestDepthOfInh()
        {
            // Specify the path to the DLL file
            string path = "..\\..\\..\\..\\Analyzer\\TestDLLs\\TestUnused.dll";

            // Create a list of DLL paths
            ParsedDLLFile dllFile = new(path);

            //DllFilePaths.Add(path);

            List<ParsedDLLFile> dllFiles = new() { dllFile };

            // Create an instance of RemoveUnusedLocalVariablesRule
            DepthOfInheritance analyzer = new(dllFiles);

            // Run the analyzer
            var result = analyzer.AnalyzeAllDLLs();

            foreach (var dll in result)
            {
                Console.WriteLine(dll.Key);

                var res = dll.Value;

                Console.WriteLine(res.AnalyserID + " " + res.Verdict + " " + res.ErrorMessage);
            }

        }
    }
}