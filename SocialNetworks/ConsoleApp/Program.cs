using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using VkNet;
using VkNet.AudioBypassService.Extensions;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace ConsoleApp1
{
    class Program
    {
        static string password = "Fal513low_Mae2d";
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddAudioBypass(); 
            
            var api = new VkApi(services);
            
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 6998852,
                Login = "asya230198@mail.ru",
                Password = password,
                Settings = Settings.All
            });
            Console.WriteLine(api.Token);
            
            ProfileFields pf = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Online;
            var friends = api.Friends.Get(new FriendsGetParams(){
                Order = FriendsOrder.Name,
                Fields = pf
            });
            Console.WriteLine(friends.TotalCount);
            foreach (var friend in friends)
            {
                Console.WriteLine(friend.FirstName + " " + friend.LastName + " " + friend.Online);
            }
            Console.WriteLine("Send message");
            Console.WriteLine("To: ");
            var receiver = Console.ReadLine();
            var receiverParsed = receiver.Split(" ");
            var recv = friends.Where(x => x.FirstName == receiverParsed[0] && x.LastName == receiverParsed[1]);
            var randomId = new Random().Next(10000, 32000);
            Console.WriteLine("Message text:");
            var message = Console.ReadLine();
            var msgid = api.Messages.Send(new MessagesSendParams
            {
                UserId = recv.First().Id,
                RandomId = randomId,
                Message = message
            });
            Console.WriteLine(msgid + " sent");
        }
    }
}