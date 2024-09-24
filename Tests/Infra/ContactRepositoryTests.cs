using Domain.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Tests.Fixtures;
using Tests.Infra.Fixtures;

namespace Tests.Infra
{
    public class ContactRepositoryTests : DatabaseTestBase, IClassFixture<DockerPostgresFixture>
    {
        public ContactRepositoryTests(DockerPostgresFixture dockerFixture) : base(dockerFixture)
        {
        }

        [Fact(DisplayName = "Deve listar todos contatos")]
        [Trait("Metodo", "ListAll")]
        public async Task ListAll_ShouldReturnAllContacts()
        {
            // Arrange
            var contact1 = ContactFixture.CreateFakeContact();
            contact1.Id = 1;
            await _context.Set<Contact>().AddAsync(contact1);
            await _context.SaveChangesAsync();

            var contact2 = ContactFixture.CreateFakeContact();
            contact2.Id = 2;
            await _context.Set<Contact>().AddAsync(contact2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _context.Set<Contact>().ToListAsync();

            //Assert
            result.Should().HaveCount(2);
        }
    }

}

