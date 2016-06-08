using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using System.Configuration;

namespace Gerrymander.Bot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private readonly LuisClient luisClient;

        public MessagesController()
        {
            luisClient = new LuisClient(ConfigurationManager.AppSettings["LuisId"], ConfigurationManager.AppSettings["LuisKey"]);
        }
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                try
                {
                    var result = await luisClient.ParseMessage(message.Text ?? string.Empty);
                    var intent = result.intents[0];
                    if (String.Equals(intent.intent, "None", StringComparison.InvariantCultureIgnoreCase))
                        return message.CreateReplyMessage("Wat?!");
                    return message.CreateReplyMessage("Hey, this is not implemented!");
                }
                catch(Exception e)
                {
                    return message.CreateReplyMessage($"An error occured: {e.Message}");
                }
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}