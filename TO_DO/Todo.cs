using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parprogrammering
{
    internal class Todo
    {

        List<Task> taskList = new List<Task>();
        string input;

        public void Run()
        {
            BackToMain();
        }

        public void ShowTasks()
        {
            Console.Clear();
            Console.WriteLine("Dine oppgaver: ");

            for (int i = 0; i < taskList.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + taskList[i].Title);

            }
            //input = Console.ReadLine();
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
            {
                return;
            }

            if (int.TryParse(input, out int index) && index > 0 && index <= taskList.Count)
            {
                index--;
                Console.WriteLine($"You have selected the task: {taskList[index].Title}");
                Console.WriteLine($"Objective for this task: {taskList[index].Description}");

                Console.WriteLine();
                Console.WriteLine("0. Delete task");
                Console.WriteLine("1. Exit to main menu");
                
                input = Console.ReadLine();
                if (input == "0")
                {
                    taskList.RemoveAt(index);
                    Console.WriteLine("You have deleted the task");
                    Console.ReadLine();

                    BackToMain();
                }
                else if (input == "1")
                {
                    BackToMain();
                }
                else
                {
                    return;
                }

            }
            else
            {

                Console.WriteLine("Invalid choice");
            }
        }

        public void AddTask()
        {
            Console.Clear();
            Console.WriteLine("Give your task a name");
            var taskInput = Console.ReadLine();
            Console.WriteLine("Give your task a description");
            var taskDescription = Console.ReadLine();
            //Console.WriteLine("");
            //var description = Console.ReadLine();
            var task = new Task(taskInput, taskDescription);
            taskList.Add(task);
            BackToMain();
        }

        public void TaskInfo()
        {

        }


        public void NotasksError()
        {
            Console.WriteLine("You have no task added!");
            Console.ReadLine();
            BackToMain();
        }

        public void BackToMain()
        {
            Console.Clear();
            Console.WriteLine("Welcome to your TODO list");
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine();
            Console.WriteLine("1. See your tasks");
            Console.WriteLine("2. Add a task");
            Console.WriteLine("3. Exit");
            input = Console.ReadLine();

            if (input == "1")
            {
                if (taskList.Count <= 0)
                {
                    NotasksError();
                }
                else
                {
                    ShowTasks();
                }

            }
            else if (input == "2")
            {
                AddTask();
            }
            else if (input == "3")
            {
                Environment.Exit(0);
            }
            else
            {
                BackToMain();
            }

        }
    }
}
