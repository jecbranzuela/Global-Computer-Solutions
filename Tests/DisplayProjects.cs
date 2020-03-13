using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCSClasses;
using NUnit.Framework;

namespace CreateTests
{
    [TestFixture]
    public class DisplayProjects
    {
	    [Test]
	    public void Projects_DisplayAllProjects()
	    {
            using var context = new GcsContext();
            var projects = context.Projects.Where(c => c.IsDeleted == false);

            foreach (var project in projects)
            {
	            Console.WriteLine($"{project.ProjectId},  {project.Description}");
            }
	    }
    }
}
