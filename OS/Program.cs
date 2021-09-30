using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OS
{
    class Program
    {
        static string path;

        static Dictionary<string, List<string>> folderTypes = new Dictionary<string, List<string>> {
           { "Text", new List<string> { ".txt", ".doc",".pdf"} },
           { "Images", new List<string> { ".png", ".jpeg",".ico",".jpg" } },
           { "Programs", new List<string> { ".exe" } },
           { "Videos", new List<string> { ".avi", ".mp4",".gif" } },
           { "Music", new List<string> { ".mp3", ".wav",".ogg" } },
           { "Archive", new List<string> { ".zip", ".rar" } },
           { "Code", new List<string> { ".cs", ".html",".php",".cpp",".js" } }

        };
        static void CreateFolders()
        {
            //          Создание папок
            for (int i = 0; i < folderTypes.Count; i++)
            {
                if (Directory.Exists($"{path + folderTypes.ElementAt(i).Key}") == false)
                    Directory.CreateDirectory($"{path + folderTypes.ElementAt(i).Key}");
            }
            Directory.CreateDirectory($"{path}Other");
        }

        static void FileSort()
        {
            //       Запись всех файлов в список
            List<string> allFiles = Directory.GetFiles(path).Select(Path.GetFileName).ToList();

            //        Сортировка файлов
            foreach (var item in folderTypes)
            {
                foreach (var innerItem in item.Value)
                {
                    allFiles.Where(x => x.Contains(innerItem)).ToList().ForEach(y => { File.Move($"{path + y}", $"{path + item.Key}\\{y}"); });
                   
                }
            }

            //        Перемещение отавшихся файлов в директорию "Другое"
            allFiles = Directory.GetFiles(path).Select(Path.GetFileName).ToList();
            allFiles.ToList().ForEach(y => { File.Move($"{path + y}", $"{path}Other\\{y}"); });

            //       Удаление пустых директорий 
            List<string> dirs = Directory.GetDirectories(path).ToList();
            foreach (var item in dirs)
            {
                if (Directory.GetFiles(item).Length==0)
                    Directory.Delete(item);
            }

            Console.WriteLine("\n\nСортировка выполнена");
        }

        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                path = args[0];
                path += "\\";

                if (Directory.Exists(path))
                {
                    CreateFolders();
                    FileSort();
                }
                else
                    Console.WriteLine("This directory does not exist");
            }

            Console.Read();
        }

    }
}
