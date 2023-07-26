using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Domain.Common;

/// <summary>
/// 多個Entity之間的共同屬性
/// </summary>
public abstract class BaseEntity
{
    public int Id { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

}
