using HR_LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.IntergrationTests;

public class HrDatabaseContextTests
{
    private HrDatabaseContext _hrDatabaseContext; 
    public HrDatabaseContextTests()
    {
        var dbOptions = new DbContextOptionsBuilder<HrDatabaseContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

        _hrDatabaseContext = new HrDatabaseContext(dbOptions);
    }

    [Fact]
    public async void Save_SetDateCreatedValue()
    {
        //Arrange


        //Act

        //Assert
    }
}