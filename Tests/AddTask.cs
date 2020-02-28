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
            newTask.Description = "Initial Interview";
            newTask.EndDate = DateTime.Now;
            newTask.StartDate = DateTime.Now;
            context.TaskClasses.Add(newTask);
            context.SaveChanges();
            Console.WriteLine($"The task is {newTask.Description}, it will start on" +
                              $"{newTask.StartDate.DayOfYear} and will end " +
                              $"{newTask.EndDate.DayOfYear}." +
                              $"Its id number is {newTask.TaskClassId} .");
        }
    }
}
