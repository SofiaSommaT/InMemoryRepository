using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InMemoryRepositorySimulator.Test
{
    [TestClass]
    public class RemovingTests
    {
        private readonly IRepository repo;
        public RemovingTests()
        {
            repo = new Repository();
            repo.Add("email", "sofia.somma@gmail.com");
            repo.Add(1, 1);
            repo.Add("decimal", 0.9);
            repo.Add("user", new User { Name = "Sofia", Surname = "Somma" });

        }

        [TestMethod]
        public void DeleteItemByKey()
        {
            Assert.IsTrue(repo.Remove("email"));
        }

        [TestMethod]
        public void DeleteItemUsingWrongKey()
        {
            var key = "name";
            try
            {
                var s = repo.Remove<string>(key);
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, $"{key} not found");
            }
        }

        [TestMethod]
        public void DeleteItemUsingNullKey()
        {
            object key = null;
            try
            {
                var s = repo.Remove<object>(key);
            }
            catch (ArgumentNullException ex)
            {
                StringAssert.Contains(ex.Message, $"cannot be null");
            }
        }

        [TestMethod]
        public void RemoveAll()
        {
            Assert.IsTrue(repo.EmptyAll());

            Assert.AreEqual(0, repo.Count());
        }
    }
}
