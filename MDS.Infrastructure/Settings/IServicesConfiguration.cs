using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS.Infrastructure.Settings
{
    public interface IServicesConfiguration
    {
        string Siteds { get; }
        string Reniec { get; }
    }
}
