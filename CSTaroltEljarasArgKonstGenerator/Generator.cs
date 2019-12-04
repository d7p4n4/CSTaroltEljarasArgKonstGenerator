using d7p4n4Namespace.Final.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSTaroltEljarasArgKonstGenerator
{
    class Generator
    {
        public static void generateClass(string outputPath, TaroltEljaras taroltEljaras)
        {
            string[] text = readIn("TemplateTaroltEljaras");

            string replaced = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i].Contains("argumentumKonstans"))
                {
                    string newline = "";
                    foreach (var arg in taroltEljaras.ArgumentumLista)
                    {
                        if (!arg.BelsoNev.Equals("@RETURN_VALUE"))
                        {
                            newline = newline + text[i + 1].Replace("#@argNev#", arg.BelsoNev).Replace("#argNev#", arg.BelsoNev.Substring(1)) + "\n";
                            Console.WriteLine(newline);
                        }
                    }
                    replaced = replaced + newline + "\n";
                    i = i + 2;
                }
                replaced = replaced + text[i] + "\n";
            }

            replaced = replaced.Replace("#taroltEljarasNev#", taroltEljaras.Megnevezes);

            writeOut(replaced, taroltEljaras.Megnevezes, outputPath);

        }

        public static string[] readIn(string fileName)
        {

            string textFile = "c:\\Templates\\c#\\Tabla\\" + fileName + ".csT";

            string[] text = File.ReadAllLines(textFile);

            return text;
        }

        public static void writeOut(string text, string fileName, string outputPath)
        {
            File.WriteAllText(outputPath + fileName + ".cs", text);

        }
    }
}