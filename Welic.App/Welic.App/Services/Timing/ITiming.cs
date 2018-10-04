using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Welic.App.Services.Timing
{
    public interface ITiming
    {
        Task<bool> SendNewData();
        bool ConsultDataNoTiming();
        Task SincDatas();
    }
}
