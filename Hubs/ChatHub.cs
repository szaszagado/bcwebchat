using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using probagetrequest.Models;
using Microsoft.AspNetCore.Http;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public DateTime dt;
        public async Task SendMessage(string user, string message)
        {
            string connn;
            connn = "Server=DESKTOP-U7SBTFN;Database=DBChatApp;Uid=sa;Pwd=123456;";
            System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(connn);
            try
            {
                Console.WriteLine("Connecting to SqlServer...");
                con.Open();
                Console.WriteLine("Connection Open!");
                string query = "INSERT INTO Messages (Timestamp, Username, Message) VALUES (@datee ,@username, @message)";
                var cmd = new System.Data.SqlClient.SqlCommand(query, con);

                cmd.Parameters.Add("@datee", System.Data.SqlDbType.VarChar).Value = dt;
                cmd.Parameters.Add("@username", System.Data.SqlDbType.VarChar).Value = user;
                cmd.Parameters.Add("@message", System.Data.SqlDbType.VarChar).Value = message;

                //Execute
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
            con.Close();
            Console.WriteLine("Done!!!!!");

            // var client = new MongoClient("mongodb://localhost:27017");

            // var db = client.GetDatabase("MSGforCHAT");

            // var collec = db.GetCollection<Message>("MSGforCHAT");

            // collec.InsertOne(new Message
            //  {
            //      Sent = DateTime.Now,
            //     Usr = user,
            //     Msg = message
            // });

            Console.WriteLine($"user={user}, message={message}");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}