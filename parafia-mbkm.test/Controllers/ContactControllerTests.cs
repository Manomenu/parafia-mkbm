using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using parafia_mbkm.Controllers;
using parafia_mbkm.data.Models;
using parafia_mbkm.Services.IServices;

namespace parafia_mbkm.test.Services
{
    public class ContactControllerTests
    {
        private readonly IContactService _contactService;
        public ContactControllerTests()
        {
            _contactService = A.Fake<IContactService>();
        }

        [Fact]
        public void ContactController_GetAllContacts_ReturnOk()
        {
            ///Arrange
            ///
            var contactsList = A.Fake<List<Contact>>();
            A.CallTo(() => _contactService.GetAllContactsAsync())
                .Returns(contactsList);
            var controller = new ContactController(_contactService);

            ///Act
            ///
            var result = controller.GetAllContacts();

            ///Assert
            ///
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }
    }
}