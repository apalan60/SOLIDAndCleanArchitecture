using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Features.LeaveTypeFeature.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.MappingProfile;
using HRLeaveManagement.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using Xunit;

namespace HRLeaveManagement.Application.UnitTests.Features.LeaveTypes.Queries;

public class GetLeaveTypeQueryHandlerTests
{
    private readonly Mock<ILeaveTypeRepository> _mockRepo;
    private readonly IMapper _mapper;
    private Mock<IAppLogger<GetLeaveTypeQueryHandler>> _mockAppLogger; 

    public GetLeaveTypeQueryHandlerTests()
    {
        _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

        var mapperConfig = new MapperConfiguration(c => 
        {
            c.AddProfile<LeaveTypeProfile>();
        });

        _mapper = mapperConfig.CreateMapper();
        _mockAppLogger = new Mock<IAppLogger<GetLeaveTypeQueryHandler>>();
    }

    [Fact]
    public async Task GetLeaveTypeListTest() 
    {
        var handler = new GetLeaveTypeQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

        var result = await handler.Handle(new GetLeaveTypeQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<LeaveTypeDto>>();
        result.Count.ShouldBe(3);
    }
}
