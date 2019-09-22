using CompanySelf.Application.Companies.Commands.DeleteCompany;
using CompanySelf.Application.Infrastructure;
using CompanySelf.Application.Tests.Helpers;
using CompanySelf.Domain.Entities;
using CompanySelf.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CompanySelf.Application.Tests.HandlersTests
{
    public class DeleteCompanyTests
    {
        [Fact]
        public async Task Call_Handler_Should_Remove_Company()
        {
            var options = DbContextOptionsHelper.GetOptions(Guid.NewGuid().ToString());
            using (var _context = new ApplicationDbContext(options))
            {
                for (int i = 1; i <= 20; i++)
                {
                    var company = new Company($"Company{i}", 2000 + i);
                    company.AddEmployee($"FirstName{i}", $"LastName{i}", DateTime.Now, JobType.Administrator);
                    await _context.AddAsync(company);
                }
                await _context.SaveChangesAsync();

                var deleteCommand = new DeleteCompanyCommand(1);
                var commandHandler = new DeleteCompanyCommandHandler(_context);
                var companiesCount = await _context.Companies.CountAsync();
                var response = await commandHandler.Handle(deleteCommand, CancellationToken.None);
                var expectedCompaniesCount = await _context.Companies.CountAsync();
                Assert.IsType<Response>(response);
                Assert.Equal(companiesCount - 1, expectedCompaniesCount);
            }
        }

        [Fact]
        public async Task Call_Handler_Should_Throw_NotFoundException()
        {
            var options = DbContextOptionsHelper.GetOptions(Guid.NewGuid().ToString());
            using (var _context = new ApplicationDbContext(options))
            {
                for (int i = 1; i <= 20; i++)
                {
                    var company = new Company($"Company{i}", 2000 + i);
                    company.AddEmployee($"FirstName{i}", $"LastName{i}", DateTime.Now, JobType.Administrator);
                    await _context.AddAsync(company);
                }
                await _context.SaveChangesAsync();
                int id = 21;

                var deleteCommand = new DeleteCompanyCommand(id);
                var commandHandler = new DeleteCompanyCommandHandler(_context);

                Exception ex = await Assert.ThrowsAsync<NotFoundException>(async () => await commandHandler.Handle(deleteCommand, CancellationToken.None));
                Assert.Equal($"Company with id {id} doesnt exist", ex.Message);
            }
        }
    }
}