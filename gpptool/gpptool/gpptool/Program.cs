using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Linq;

namespace gpptool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string output = "";

            if (args.Length > 0)
            {
                if (args[0] == "-cfetch")
                {
                    WriteLine("[>]: Reading Theme File...");
                    FileInfo jsonfile = new FileInfo(args[1]);
                    if (jsonfile.Exists)
                    {
                        JsonDocument jsonDoc = JsonDocument.Parse(File.ReadAllText(args[1]));
                        JsonElement root = jsonDoc.RootElement;

                        if (root.TryGetProperty("colors", out JsonElement colorsObject))
                        {
                            foreach (JsonProperty colorProperty in colorsObject.EnumerateObject())
                            {
                                string propertyName = colorProperty.Name;
                                JsonElement propertyValue = colorProperty.Value;

                                if (propertyName.ToLower().Contains("editor.background") || propertyName.ToLower().Contains("sideBar"))
                                {
                                    output += $"{propertyName}: {propertyValue}\n";
                                    WriteLine($"{propertyName}: {propertyValue}");
                                }
                            }
                        }

                        if (root.TryGetProperty("tokenColors", out JsonElement tokenColorsArray))
                        {
                            if (tokenColorsArray.EnumerateArray().Any()) // die
                            {
                                foreach (JsonElement tokenColor in tokenColorsArray.EnumerateArray())
                                {
                                    if (tokenColor.TryGetProperty("name", out JsonElement nameProperty) && tokenColor.TryGetProperty("settings", out JsonElement settingsProperty))
                                    {
                                        // Check if its a string before printing
                                        if (nameProperty.ValueKind == JsonValueKind.String && settingsProperty.TryGetProperty("foreground", out JsonElement foregroundProperty))
                                        {

                                            string name = nameProperty.GetString();
                                            if (name.ToLower().Contains("keyword") || name.ToLower().Contains("function") || name.ToLower().Contains("variable") || name.ToLower().Contains("constant") || name.ToLower().Contains("function"))
                                            {
                                                output += $"Name: {name}, Color: {foregroundProperty.GetString()}\n";
                                                WriteLine($"Name: {name}, Color: {foregroundProperty.GetString()}");
                                            }
                                        }
                                    }
                                }
                                WriteLine("-----------------------------\nCreating Color dump...");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                File.WriteAllText("colordump_" + new Random().Next(1, 3000000) + ".txt", output);
                            }
                            else
                            {
                                WriteLine("The 'tokenColors' array is empty");
                            }
                        }
                        else
                        {
                            WriteLine("The 'tokenColors' property does not exist");
                        }
                    }
                    else
                    {
                        WriteLine("Invalid json, provide a VALID one in the arguments");
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
