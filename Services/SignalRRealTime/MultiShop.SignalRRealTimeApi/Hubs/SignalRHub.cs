using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.SignalRCommentServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;

        public SignalRHub(ISignalRCommentService signalRCommentService)
        {

            _signalRCommentService = signalRCommentService;
        }

        //public async Task SendStatisticCount()
        //{
        //    var getTotalCommentCount = _signalRCommentService.GetTotalCommentCount();
        //    await Clients.All.SendAsync("RecieveCommentCount", getTotalCommentCount);

        //    var getTotalMessageCount = _signalRMessageService.GetTotalMessageCountByRecieverId("1");
        //    await Clients.All.SendAsync("RecieveMessageCount", getTotalMessageCount);
        //}  
        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("RecieveCommentCount", getTotalCommentCount);

        }
    }
}
