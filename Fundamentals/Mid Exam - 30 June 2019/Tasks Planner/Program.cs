using System;
using System.Collections.Generic;
using System.Linq;

namespace Tasks_Planner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> taskList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "End")
            {
                if (command[0] == "Complete")
                {
                    int index = int.Parse(command[1]);
                    if (CheckIndex(taskList,index))
                    {
                        taskList[index] = 0;
                    }
                }
                if (command[0] == "Change")
                {
                    int index = int.Parse(command[1]);
                    int time = int.Parse(command[2]);
                    if (CheckIndex(taskList,index))
                    {
                        taskList[index] = time;
                    }
                }
                if (command[0] == "Drop")
                {
                    int index = int.Parse(command[1]);
                    if (CheckIndex(taskList, index))
                    {
                        taskList[index] = -1;
                    }
                }
                if (command[1] == "Completed")
                {
                    int countCompliteTask = 0;
                    for (int i = 0; i < taskList.Count; i++)
                    {
                        int currentNumber = taskList[i];
                        if (currentNumber == 0)
                        {
                            countCompliteTask++;
                        }
                    }
                    Console.WriteLine(countCompliteTask);
                }
                if (command[1] == "Incomplete")
                {
                    int countIncompliteTask = 0;
                    for (int i = 0; i < taskList.Count; i++)
                    {
                        int currentNumber = taskList[i];
                        
                        if (currentNumber>0)
                        {
                            countIncompliteTask++;
                        }
                    }
                    Console.WriteLine(countIncompliteTask);
                }
                if (command[1] == "Dropped")
                {
                    int CountDropedTask = 0;
                    for (int i = 0; i < taskList.Count; i++)
                    {
                        int currentNumber = taskList[i];
                        if (currentNumber == -1)
                        {
                            CountDropedTask++;
                        }
                    }
                    Console.WriteLine(CountDropedTask);
                }

                command = Console.ReadLine().Split().ToList();
            }
            List<int> incompliteTask = new List<int>();
            for (int i = 0; i < taskList.Count; i++)
            {
                int curentNum = taskList[i];
                if (curentNum>0)
                {
                    incompliteTask.Add(curentNum);
                }
            }
            Console.WriteLine(string.Join(" ",incompliteTask));
        }

        static bool CheckIndex(List<int> list, int index)
        {
            bool isValid = false;
            if (index >= 0 && index <= list.Count - 1)
            {
                isValid = true;
            }
            return isValid;
        }

        
    }
}
