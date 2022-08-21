using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace InMemoryRepositorySimulator.Test
{
    [TestClass]
    public class RetrievingTests
    {
        private readonly IRepository repo;
        public RetrievingTests()
        {
            repo = new Repository();
            repo.Add("email","sofia.somma@gmail.com");
            repo.Add(1, 1);
            repo.Add("decimal", 0.9);
            repo.Add("user", new User { Name = "Sofia", Surname = "Somma" });

        }
        [TestMethod]
        public void GetItemNoKeyFound()
        {
            var key = "name";
            try
            {
                var s = repo.Get<string>(key);
            }
            catch (ArgumentException ex)
            {
                StringAssert.Contains(ex.Message, $"{key} not found");
            }
            
        }

        [TestMethod]
        public void GetString()
        {
            var s = repo.Get<string>("email");
            Assert.AreEqual(s, "sofia.somma@gmail.com");
        }

        [TestMethod]
        public void GetInteger()
        {
            var s = repo.Get<int>(1);
            Assert.AreEqual(s, 1);
        }

        [TestMethod]
        public void GetWrongDataType()
        {
            int value = 1;
            try
            {
                var s = repo.Get<string>(value);
            }
            catch(InvalidCastException ex)
            {
                StringAssert.Contains(ex.Message, $"output type required is {typeof(int)}");
            }
        }

        [TestMethod]
        public void GetUser()
        {
            User userExpected = new User() { Name = "Sofia",Surname = "Somma" };
            User user = repo.Get<User>("user");
            Assert.AreEqual(JsonConvert.SerializeObject(userExpected), JsonConvert.SerializeObject(user));
        }
    }

   
}
