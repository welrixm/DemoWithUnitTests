using Microsoft.VisualStudio.TestTools.UnitTesting;
using Delus.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delus.Components;

namespace Delus.Pages.Tests
{
    [TestClass()]
    public class AddEditAgentTests
    {
        public static AgentDelusEntities db = new AgentDelusEntities();
        Agent agent = new Agent
        {
            Title = "Pluton",
            AgentTypeID = 2,
            INN = "1234567",
            Phone = "89173951935",
            Priority = 250
        };
        [TestMethod()]
        public void AddEditAgentTest()
        {
           
            DBConnect.db.Agent.Add(agent);
            DBConnect.db.SaveChanges();
            var ag = DBConnect.db.Agent.Where(x => x.Title == agent.Title  && x.AgentTypeID == agent.AgentTypeID && x.INN == agent.INN && x.Phone == agent.Phone
            && x.Priority == agent.Priority).FirstOrDefault();
            Assert.IsTrue(ag != null);
        }
        
        [TestMethod()]
        public void AddEditAgentTest1()
        {
            DBConnect.db.Agent.Add(agent);
            DBConnect.db.SaveChanges();
            var ag = DBConnect.db.Agent.Where(x => x.Title == agent.Title && x.AgentTypeID == agent.AgentTypeID && x.INN == agent.INN && x.Phone == agent.Phone
            && x.Priority == agent.Priority).FirstOrDefault();
            agent.Title = "Neptun";
            DBConnect.db.SaveChanges();
            var agt = DBConnect.db.Agent.Where(x => x.Patronymic == agent.Patronymic && x.Title == "Neptun").FirstOrDefault();
            Assert.IsTrue(agt != null);
        }
       
        [TestMethod()]
        public void AddEditAgentTest2()
        {
            

            DBConnect.db.Agent.Add(agent);
            DBConnect.db.SaveChanges();
            var ag = DBConnect.db.Agent.Where(x => x.Title == agent.Title && x.AgentTypeID == agent.AgentTypeID && x.INN == agent.INN && x.Phone == agent.Phone
            && x.Priority == agent.Priority).FirstOrDefault();
            Assert.IsTrue(ag != null);
            DBConnect.db.Agent.Remove(agent);
            DBConnect.db.SaveChanges();
        }
    }
}