using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Welic.App.Services.Timing
{
    public class Timing : ITiming
    {
        public Task<bool> SendNewData()
        {
            throw new NotImplementedException();
        }

        public bool ConsultDataNoTiming()
        {
            throw new NotImplementedException();
        }

        public Task SincDatas()
        {
            throw new NotImplementedException();
        }
    }
}
