using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace probagetrequest.Hubs
{

    public class UserCount : Hub
    {
        private static int Count;
        public override Task OnConnectedAsync()
        {
            Count++;
            base.OnConnectedAsync();
            this.Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Count--;
            base.OnDisconnectedAsync(exception);
            this.Clients.All.SendAsync("updateCount", Count);
            return Task.CompletedTask;
        }

    }
    //public static class UseHandler
    //{
    //    public static HashSet<string> ConnectedIds = new HashSet<string>();
    //}
    //public class MyHub : Hub
    //{

        //public override Task OnConnectedAsync()
        //{
        //    UseHandler.ConnectedIds.Add(Context.ConnectionId);
        //    return base.OnConnectedAsync();
        //}
        //public override Task OnDisconnectedAsync(Exception exception)
        //{
        //    UseHandler.ConnectedIds.Remove(Context.ConnectionId);
        //    return base.OnDisconnectedAsync(exception);
        //}


        //public int getCount()
        //{
        //    return UseHandler.ConnectedIds.Count;
        //}

        //MyHub mzhub = new MyHub();
        //ViewBag counting = mzhub.getCount();

    //}


}