using System;
using TopCallXamarin.Infrastructure.Networking.Bases;
using Xamarin.Essentials;

namespace TopCallXamarin.Models.UI
{
    public class BaseUiModel
    {

        public BaseUiModel(NetworkAccess isNetWork, PhysicalResult physicalResult)
        {
            IsNetWork = isNetWork;
            PhysicalResult = physicalResult;
        }

        public NetworkAccess IsNetWork { get; set; }
        public PhysicalResult PhysicalResult { get; set; }
    }
}
