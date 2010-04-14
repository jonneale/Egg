using System;
using uSwitch.Energy.Silverlight.Rest;

namespace uSwitch.Energy.Silverlight.Commands
{
    public interface IAsyncCommand<TReturn>
    {
        void Execute(IRestClient client, Action<TReturn> queryCallback);
    }
}