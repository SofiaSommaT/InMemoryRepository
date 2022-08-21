using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InMemoryRepositorySimulator.Test
{
    [TestClass]
    public class AddingTests
    {
        [TestMethod]
        public void AddString()
        {

            IRepository repo = new Repository();
            Assert.IsTrue(repo.Add("email", "sofia.somma@gmail.com"));
        }

        [TestMethod]
        public void AddInteger()
        {
            IRepository repo = new Repository();
            Assert.IsTrue(repo.Add(1, 1));
        }

        [TestMethod]
        public void AddObject()
        {
            IRepository repo = new Repository();
            Assert.IsTrue(repo.Add("user", new { Name = "Sofia", Surname = "Somma" }));
        }

        [TestMethod]
        public void AddWithDuplicateKey()
        {
            IRepository repo = new Repository();
            var key = 2;
            try
            {
                repo.Add(key, "new item");
                repo.Add(key, "new item used the same key");
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, $"{key} already exists in the repository");
            }
        }

        [TestMethod]
        public void AddNullValue()
        {

            IRepository repo = new Repository();
            var key = 2;
            try
            {
                object value = null;
                repo.Add(key, value);
            }
            catch (ArgumentNullException ex)
            {
                StringAssert.Contains(ex.Message, $"cannot be null");
            }
            
        }

    }


}