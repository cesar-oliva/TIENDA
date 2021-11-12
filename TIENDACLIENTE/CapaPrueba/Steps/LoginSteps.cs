using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceUsuarioPrueba;
using System;
using TechTalk.SpecFlow;


namespace CapaPrueba.Features
{
    [Binding]
    public class LoginSteps
    {
        string username;
        bool result;
        string response;

        [Given(@"I have started the application whith ""(.*)""")]
        public void GivenIHaveStartedTheApplicationWhith(string Username)
        {
            this.username = Username;
        }
    
        
        [When(@"I write Password ""(.*)""")]
        public void WhenIWritePassword(string Password)
        {
            ServiceUsuarioClient client = new ServiceUsuarioClient();
            result = client.LoginUsuario(username, Password);
            if (result)
            {
                response = "true";
            }
            else
            {
                response = "false";
            }
        }
        
        [Then(@"the result should be ""(.*)""")]
        public void ThenTheResultShouldBe(string answer)
        {
            Assert.AreEqual(response, answer);
        }
    }
}
