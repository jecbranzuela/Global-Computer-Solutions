﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using GCSClasses;
using NUnit.Framework;

namespace CreateTests
{
    [TestFixture]
    public class AddRegion
    {
        [Test]
        public void Region_AddRegionAutoGenerateId()
        {
            using var context = new GcsContext();
            var newRegion = new Region();
            newRegion.Name = "SouthEast (SE)";
            context.Regions.Add(newRegion);
            context.SaveChanges();
            Console.WriteLine($"FirstName of newly added region is {newRegion.Name.ToUpper()} " +
                              $"with region id of {newRegion.RegionId}");

        }
    }
}
