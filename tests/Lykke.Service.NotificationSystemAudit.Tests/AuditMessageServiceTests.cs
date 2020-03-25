using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.NotificationSystemAudit.Domain.Contracts;
using Lykke.Service.NotificationSystemAudit.Domain.Entities;
using Lykke.Service.NotificationSystemAudit.Domain.Repositories;
using Lykke.Service.NotificationSystemAudit.DomainServices.Services;
using Moq;
using Xunit;

namespace Lykke.Service.NotificationSystemAudit.Tests
{
    public class AuditMessageServiceTests
    {
        private readonly Mock<IAuditMessageRepository> _messageRepositoryMock = new Mock<IAuditMessageRepository>();
        private readonly AuditMessageService _service;

        public AuditMessageServiceTests()
        {
            _service = new AuditMessageService(_messageRepositoryMock.Object);
        }

        [Fact]
        public async Task When_ParametersPassedToCreateAsync_Expect_MethodCalled()
        {
            //Arrange
            _messageRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<CreateAuditMessage>()))
                .Returns(Task.FromResult(It.IsAny<bool>()));

            //Act
            await _service.CreateAsync(It.IsAny<CreateAuditMessage>());

            //Assert
            _messageRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<CreateAuditMessage>()), Times.Once);
        }

        [Fact]
        public async Task
            When_NonPositiveCurrentPagePassedToRetrievePaginatedAuditMessagesAsync_Expect_ExceptionThrown()
        {
            await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.RetrievePaginatedMessagesAsync(0, 2, It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>()));
        }

        [Fact]
        public async Task When_NonPositivePageSizePassedToRetrievePaginatedAuditMessagesAsync_Expect_ExceptionThrown()
        {
            await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.RetrievePaginatedMessagesAsync(2, 0, It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>()));
        }

        [Fact]
        public async Task
            When_CorrectParametersPassedToRetrievePaginatedAuditMessagesAsync_Expect_MethodCalledWithCorrectParameters()
        {
            //Arrange
            var currentPage = 2;
            var pageSize = 12;

            var skip = (currentPage - 1) * pageSize;
            var take = pageSize;

            _messageRepositoryMock.Setup(x => x.RetrievePaginatedMessagesAsync(skip, take,
                    It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(),
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new PaginatedAuditList
                {
                    AuditMessages = It.IsAny<IEnumerable<IAuditMessage>>(), TotalCount = 123
                }));

            //Act
            var result = await _service.RetrievePaginatedMessagesAsync(currentPage, pageSize,
                It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>());

            //Assert
            _messageRepositoryMock.Verify(x => x.RetrievePaginatedMessagesAsync(skip, take,
                    It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(),
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);

            Assert.Equal(currentPage, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
        }

        [Fact]
        public async Task When_ParametersPassedToRetrieveFailedMessagesAsync_Expect_MethodCalled()
        {
            //Arrange
            _messageRepositoryMock.Setup(x => x.RetrieveDeliveryFailedMessagesAsync(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<DateTime>(),
                    It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(Task.FromResult(It.IsAny<PaginatedAuditList>()));

            //Act
            await _service.RetrieveDeliveryFailedMessagesAsync(1, 10, It.IsAny<DateTime>(),
                It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>());

            //Assert
            _messageRepositoryMock.Verify(x => x.RetrieveDeliveryFailedMessagesAsync(It.IsAny<int>(), It.IsAny<int>(),
                It.IsAny<DateTime>(),
                It.IsAny<DateTime>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task When_ParametersPassedToUpdateAsync_Expect_MethodCalled()
        {
            //Arrange
            _messageRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<UpdateAuditMessage>()))
                .Returns(Task.FromResult(It.IsAny<bool>()));

            //Act
            await _service.UpdateAsync(It.IsAny<UpdateAuditMessage>());

            //Assert
            _messageRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<UpdateAuditMessage>()), Times.Once);
        }

        [Fact]
        public async Task
            When_Get_Paginated_Audit_Messages_With_Parsing_Issues_Is_Executed_With_Non_Positive_Page_Size_Parameter__Expect_That_Exception_Is_Thrown()
        {
            await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.GetPaginatedAuditMessagesWithParsingIssuesAsync(1, 0, It.IsAny<DateTime?>(),
                    It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>()));
        }

        [Fact]
        public async Task
            When_Get_Paginated_Audit_Messages_With_Parsing_Issues_Is_Executed_With_Non_Positive_Current_Page_Paremeter_Expect_That_Exception_Is_Thrown()
        {
            await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.GetPaginatedAuditMessagesWithParsingIssuesAsync(0, 1, It.IsAny<DateTime?>(),
                    It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>()));
        }

        [Fact]
        public async Task
            When_Get_Paginated_Audit_Messages_With_Parsing_Issues_Is_Executed_With_All_Valid_Parameters_Expect_That_Repository_Is_Called()
        {
            _messageRepositoryMock.Setup(x => x.GetPaginatedMessagesWithParsingIssuesAsync(It.IsAny<int>(),
                    It.IsAny<int>(), It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(),
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new PaginatedAuditList
                {
                    AuditMessages = It.IsAny<IEnumerable<IAuditMessage>>(), TotalCount = 123
                }));

            await _service.GetPaginatedAuditMessagesWithParsingIssuesAsync(1, 10, It.IsAny<DateTime?>(),
                It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>());

            _messageRepositoryMock.Verify(
                x => x.GetPaginatedMessagesWithParsingIssuesAsync(It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Fact]
        public async Task
            When_Get_Paginated_Audit_Messages_With_Parsing_Issues_Is_Executed_With_All_Valid_Parameters_Expect_That_Result_Is_Valid()
        {
            var currentPage = 1;
            var pageSize = 10;
            var skip = (currentPage - 1) * pageSize;
            var take = pageSize;

            _messageRepositoryMock.Setup(x => x.GetPaginatedMessagesWithParsingIssuesAsync(skip, take,
                    It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<string>(),
                    It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new PaginatedAuditList
                {
                    AuditMessages = It.IsAny<IEnumerable<IAuditMessage>>(), TotalCount = 123
                }));

            var result = await _service.GetPaginatedAuditMessagesWithParsingIssuesAsync(currentPage, pageSize,
                It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            Assert.Equal(currentPage, result.CurrentPage);
            Assert.Equal(pageSize, result.PageSize);
        }
    }
}
