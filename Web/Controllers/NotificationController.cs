using System;
using System.Data.SqlClient;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Twilio;
using Web.Filters.BasicAuthentication.Filters;

namespace Web.Api
{
    [IdentityBasicAuthentication]
    public class NotificationController : ApiController
    {
        private const string SmsFrom = "+15022871630";
        private const string SmsTo = "+15024151622"; // me!

        // POST api/Notification
        public void Post(JObject jObject)
        {
            // get the plain-text message from VSO's Web Hook POST
            dynamic json = jObject;
            string messageText = json.message.text;

            // construct Twilio client
            var twilio = new TwilioRestClient(
                Security.TwilioAuthentication.AccountSid, 
                Security.TwilioAuthentication.AuthToken);

            // send SMS to my cell - I need to know about EVERY checkin and build
            var message = twilio.SendSmsMessage(SmsFrom, SmsTo, messageText, "");
        }
    }
}