using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Provider
{
    public interface IDateTimeProvider
    {
        DateTime UtcNow { get; }
    }

}