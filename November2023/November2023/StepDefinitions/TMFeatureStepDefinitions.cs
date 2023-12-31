using November_2023.Pages;
using November_2023.Utilities;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace November_2023.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObject = new TMPage();


        [Given(@"I logged into TurnUp portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            //open chrome browser
            driver = new ChromeDriver();

            // Login page object definition

            loginPageObj.LoginActions(driver);


        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            // Home page object deifinition

            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new time record")]
        public void WhenICreateANewTimeRecord()
        {
            // TM Page object initialization definition

            tmPageObject.Create_TimeRecord(driver);

        }


        [Then(@"the record should be created successfully")]
        public void ThenTheRecordShouldBeCreatedSuccessfully()
        {


            string newCode = tmPageObject.GetCode(driver);
            string newDescription = tmPageObject.GetDescription(driver);
            string newPrice = tmPageObject.GetPrice(driver);

            Assert.That(newCode == "Nov2023", "New code and expected code do not match.");
            Assert.That(newDescription == "Nov2023", "New description and expected description do not match.");
            Assert.That(newPrice == "$12.00", "New price and expected price do not match.");
        }


        [When(@"I update the '([^']*)', '([^']*)' and '([^']*)' of an existing time record")]
        public void WhenIUpdateTheAndOfAnExistingTimeRecord(string code, string description, string price)
        {
            tmPageObject.Edit_TimeRecord(driver, code, description, price);
        }

        [Then(@"the record should have an updated '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveAnUpdatedAnd(string code, string description, string price)
        {
            string editedCode = tmPageObject.EditedCode(driver);
            string editedDescription = tmPageObject.EditedDescription(driver);
            string editedPrice = tmPageObject.EditedPrice(driver);

            Assert.That(editedCode, Is.EqualTo(code), "Actual and expected Code do not match.");
            Assert.That(editedDescription, Is.EqualTo(description), "Actual and expected Description do not match.");
            Assert.That(editedPrice, Is.EqualTo(price), " Actual and expected Price do not match.");
        }

    }
}

