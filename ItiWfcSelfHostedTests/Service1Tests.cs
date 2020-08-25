using Microsoft.VisualStudio.TestTools.UnitTesting;
using ItiWfcSelfHosted;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Data;

namespace ItiWfcSelfHosted.Tests
{
    [TestClass()]
    public class Service1Tests
    {

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            string connection = "Data Source = DESKTOP-LHMVI7Q\\SQLEXPRESS; Initial Catalog = master; Persist Security Info = True; User ID = sa; Password = 121212qw";
            Service1.sqlConnect(connection);
        }

        [TestMethod()]
        public void getBranchsDataTest()
        {
            var service = new Service1();

            BranchData branchs = service.getBranchsData();

            Assert.IsTrue(branchs.branchsTable.Rows.Count> 0);


        }

        [TestMethod()]
        public void getInstructorsDataTest()
        {
            var service = new Service1();

            InstructorData instructors = service.getInstructorsData();

            Assert.IsTrue(instructors.InstructorsTable.Rows.Count > 0);
        }

        [TestMethod()]
        public void getStudentsDataTest()
        {
            var service = new Service1();

            StudentData students= service.getStudentsData();

            Assert.IsTrue(students.studentsTable.Rows.Count > 0);
        }

    }
}