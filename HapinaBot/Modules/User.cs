using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;
using Discord;
using Discord.WebSocket;
using System.Threading.Channels;
using System.Timers;

namespace HapinaBot.User 
{
    public class User
    {
        private DateTime _nextPina;
        public User()
        {
            _nextPina = DateTime.Now.AddDays(3);

        }
        public Boolean canPina(User uz)
        {
            if(DateTime.Now > uz._nextPina)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
