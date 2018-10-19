using System;
using System.Collections.Generic;
using System.Text;
using Welic.App.Services;
using Welic.App.ViewModels.Base;

namespace Welic.App.ViewModels
{
    public class AspectFillLiveViewModel : BaseViewModel
    {
        public string AspectImg { get; set; }

        public AspectFillLiveViewModel()
        {
            AspectImg = Util.ImagePorSistema("iFullExit.png");
        }

    }
}
