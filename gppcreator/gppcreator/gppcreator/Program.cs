using System;
using System.IO;
using System.Net;

namespace gppcreator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "-fmake" && new FileInfo(args[1]).Exists && new FileInfo(args[1]).Name.Contains("colordump"))
                {
                    WriteLine("[>]: Reading Theme File...");
                    FileInfo colordump = new FileInfo(args[1]);
                    if (colordump.Exists)
                    {
                        var baseTheme = new WebClient().DownloadString("https://raw.githubusercontent.com/Storm99999/githubpp/main/gppcreator/base.css");
                        WriteLine("Questions will now be asked, rest of resources will be fetched from the color dump that was provided.\n\n");
                        WriteLine("[1]: Keyword Color (HEX): ");
                        var keyWordColor = Console.ReadLine();
                        baseTheme = baseTheme.Replace("--color-prettylights-syntax-keyword: #FF79C6", "--color-prettylights-syntax-keyword: " + keyWordColor);
                        string parsed = File.ReadAllLines(colordump.FullName)[0];
                        string backgroundColor = parsed.Replace("editor.background: ", "");
                        WriteLine("[Parser]: Assigned Background Color: " + backgroundColor);
                        baseTheme = baseTheme.Replace("#282A36", backgroundColor);
                        WriteLine("[2]: Secondary color, (sidebar specific, header on github): ");
                        var secondaryColor = Console.ReadLine();
                        baseTheme = baseTheme.Replace("#21222c", secondaryColor);
                        WriteLine("[3]: Function name colors: ");
                        var funcNameColors = Console.ReadLine();
                        baseTheme = baseTheme.Replace("--color-prettylights-syntax-entity-tag: #8ddb8c", "--color-prettylights-syntax-entity: " + funcNameColors);
                        baseTheme = baseTheme.Replace("--color-prettylights-syntax-entity: #dcbdfb", "--color-prettylights-syntax-entity: " + funcNameColors);

                        WriteLine("[4]: Comment colors: ");
                        var commentColors = Console.ReadLine();
                        baseTheme = baseTheme.Replace("--color-prettylights-syntax-comment: #6272A4", "--color-prettylights-syntax-comment: " + commentColors);
                        WriteLine("[5]: Variable colors: ");
                        var varColors = Console.ReadLine();
                        baseTheme = baseTheme.Replace("--color-prettylights-syntax-variable: #50FA7B", "--color-prettylights-syntax-variable: " + varColors);
                        WriteLine("[6]: String colors: ");
                        var strColors = Console.ReadLine();
                        baseTheme = baseTheme.Replace("--color-prettylights-syntax-string: #F1FA8C", "--color-prettylights-syntax-string: " + strColors);
                        File.WriteAllText("gppcreator_" + new Random().Next(1, 30000000) + ".css", baseTheme);
                        WriteLine("Written output!");
                    }
                }
            }
            else
            {
                WriteLine("No arguments passed, press any key to exit.");
                Console.ReadLine();
            }
        }
        public static void WriteLine(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("GPP");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("++");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("]");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" " + message + "\n");
        }
    }
}

