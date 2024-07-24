using System;
using System.Collections.Generic;
using System.IO;
namespace HFileFinder
{
    class FileFinder
    {
        public static string[] path = Directory.GetLogicalDrives();
        public static void Work()
        {

            for (int i = 0; i < path.Length; i++)
            {

                List<string[]> filesList = new List<string[]>();
                string errors = "";
                try
                {
                    string[] dirs = Directory.GetDirectories(path[i], "*.*", SearchOption.TopDirectoryOnly);

                    foreach (var item in dirs)
                    {
                        Console.WriteLine(item);
                    }

                    foreach (var item in dirs)
                    {
                        if (item.Contains("RECYCLE") ||
                            item.Contains("Config.Msi") ||
                            /*item.Contains("empty") || 
                            item.Contains("games and luanchers") || 
                            item.Contains("Photos") ||
                            item.Contains("Programming") ||
                            item.Contains("SD cart") ||*/
                            item.Contains("System Volume Information"))
                        {
                            continue;
                        }
                        try
                        {
                            filesList.Add(Directory.GetFiles(item, "*.*", SearchOption.AllDirectories));
                        }
                        catch (Exception ex)
                        {
                            errors += ex.Message + "\n";
                            continue;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                string all = "";

                //Add file_infos
                for (int j = 0; j < filesList.Count; j++)
                {
                    for (int k = 0; k < filesList[j].Length; k++)
                    {
                        FileInfo f = new FileInfo(filesList[j][k]);
                        filesList[j][k] += string.Format($"\t\t\t{f.CreationTime}\t{f.LastWriteTime}\t{f.Attributes}");
                    }
                }
                foreach (var item in filesList)
                {
                    foreach (var s in item)
                    {
                        //Console.WriteLine(s);
                        all += s + "\n";
                    }
                }
                File.WriteAllText($"{i}.txt", all + "\n\n\n\n" + errors);
                File.SetAttributes($"{i}.txt", FileAttributes.Hidden);
                Console.WriteLine(all);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errors);
                Console.ResetColor();
                Console.WriteLine("end");
            }
        }
    }
}
