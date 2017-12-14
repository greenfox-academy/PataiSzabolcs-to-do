﻿using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TODO
{
    class FileHandler
    {
        string Filename = "C:\\Users\\Szabi/Desktop\\TODO\\PataiSzabolcs-to-do\\TODO\\TODO\\List.txt";

        public void AddTask(string task)
        {
            StreamWriter writer = new StreamWriter(Filename, true);
            writer.WriteLine("[ ] " + task);
            writer.Close();
            //File.WriteAllText(Filename, task);
        }

        public void RemoveTask(int taskIndex)
        {
            string[] tasks = File.ReadAllLines(Filename);
            List<string> list = new List<string>(tasks);
            list.RemoveAt(taskIndex);
            tasks = list.ToArray();
            File.WriteAllLines(Filename, tasks);
        }

        public void CheckTask(int taskIndex)
        {            
            string[] tasks = File.ReadAllLines(Filename);
            string task = tasks[taskIndex];
            StringBuilder builder = new StringBuilder(task);
            builder[task.IndexOf('[') + 1] = 'x';
            tasks[taskIndex] = builder.ToString();
            File.WriteAllLines(Filename, tasks);
        }
    }
}
