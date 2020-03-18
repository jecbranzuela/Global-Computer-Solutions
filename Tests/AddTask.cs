using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCSClasses;
using GCSClasses.EFClasses;
using NUnit.Framework;

namespace CreateTests
{
    [TestFixture]
    public class AddTask
    {
        [Test]
        public void Task_AddTaskAutoGenerateId()
        {
            using var context = new GcsContext();
            var newTask = new GCSClasses.EFClasses.TaskClass();
            newTask.Description = "Final Interview";
           // newTask.EndDate = DateTime.Now;
           // newTask.StartDate = DateTime.Now;
            context.TaskClasses.Add(newTask);
            context.SaveChanges();
            Console.WriteLine($"The task is {newTask.Description}, Its id number is {newTask.TaskClassId} .");
        }

        [Test]
        public void Task_DisplayTasks()
        {
            using var context = new GcsContext();
            var tasks = context.TaskClasses.ToList();
            foreach (var taskClass in tasks)
            {
	            Console.WriteLine($"{taskClass.TaskClassId}  Name: {taskClass.Description} ");
            }
        }
    }
}
