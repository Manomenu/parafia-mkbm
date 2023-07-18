using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using parafia_mbkm.Controllers;
using parafia_mbkm.data.Models;
using parafia_mbkm.Models;
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

        [Fact]
        public void ContactController_GetAllContacts_ReturnNotFound()
        {
            ///Arrange
            ///
            var contacts = A.Fake<List<Contact>>();
            contacts = null;
            A.CallTo(() => _contactService.GetAllContactsAsync())
                .Returns(contacts);
            var controller = new ContactController(_contactService);

            ///Act
            ///
            var result = controller.GetAllContacts();

            ///Assert
            ///
            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void ContactController_GetContactById_ReturnBadRequest()
        {
            ///Arrange
            ///
            var id = -1;
            var contact = A.Fake<Contact>();
            contact = null;
            A.CallTo(() => _contactService.GetContactByIdAsync(id))
                .Returns(contact);
            var controller = new ContactController(_contactService);

            ///Act
            ///
            var result = controller.GetContactById(id);

            ///Assert
            ///
            result.Result.Should().BeOfType(typeof(NotFoundResult));
        }

        [Fact]
        public void ContactController_GetContactById_ReturnOk()
        {
            ///Arrange
            ///
            var id = 1;
            var contact = A.Fake<Contact>();
            A.CallTo(() => _contactService.GetContactByIdAsync(id))
                .Returns(contact);
            var controller = new ContactController(_contactService);

            ///Act
            ///
            var result = controller.GetContactById(id);

            ///Assert
            ///
            result.Result.Should().BeOfType(typeof(OkObjectResult));
        }

        [Fact]
        public void ContactController_AddContact_ReturnBadRequest()
        {
            ///Arrange
            ///
            var contact = A.Fake<ContactModel>();
            var contactId = -1;
            A.CallTo(() => _contactService.AddContactAsync(contact))
                .Returns(contactId);
            var controller = new ContactController(_contactService);

            ///Act
            ///
            var result = controller.AddContact(contact);

            ///Assert
            ///
            result.Result.Should().BeOfType(typeof(BadRequestResult));
        }

        [Fact]
        public void ContactController_AddContact_ReturnCreatedAtAction()
        {
            ///Arrange
            ///
            var contact = A.Fake<ContactModel>();
            var contactId = 1;
            A.CallTo(() => _contactService.AddContactAsync(contact))
                .Returns(contactId);
            var controller = new ContactController(_contactService);

            ///Act
            ///
            var result = controller.AddContact(contact);

            ///Assert
            ///
            result.Result.Should().BeOfType(typeof(CreatedAtActionResult));
        }
    }
}