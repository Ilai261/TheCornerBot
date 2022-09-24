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

namespace HapinaBot.Modules
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        static ulong[] Ids = new ulong[51];
        static DateTime[] dates = new DateTime[51];
        System.Timers.Timer userTimer;
        System.Timers.Timer userTimer1;

        [Command("pina")]
        public async Task pina(String user22)
        {
            ulong voicePinaCoolGang = 776381418364207115;
            ulong voicePinaPlayAndFun = 804338089358000139; 
            var coolGangPina = Context.Guild.VoiceChannels.FirstOrDefault(x => x.Id.Equals(voicePinaCoolGang));
            var playAndFunPina = Context.Guild.VoiceChannels.FirstOrDefault(x => x.Id.Equals(voicePinaPlayAndFun)); 
            var chatPina = Context.Guild.Channels.FirstOrDefault(x => x.Id.Equals(776381390932410397)); 
            String mentPina = chatPina.Name;
            var chatPinaPlayAndFun = Context.Guild.Channels.FirstOrDefault(x => x.Id.Equals(804337770113663027));
            String mentPinaFun = chatPinaPlayAndFun.Name;
            if (Context.Message.Channel.Id.Equals(chatPina) || Context.Message.Channel.Id.Equals(chatPinaPlayAndFun))
            {   
                var user1 = Context.Message.Author;
                var user11 = Context.Guild.Users.FirstOrDefault(x => x.Id.Equals(user1.Id));
                var user2 = Context.Guild.Users.FirstOrDefault(x => x.Mention.Equals(user22));

                if (user11.VoiceChannel.Name == null || user2.VoiceChannel.Name == null)
                {
                    await ReplyAsync("Error. Please try again.");
                }

                int timerCounter = 0;
                bool check1 = false;
                bool canPina = false;
                ulong user1Id = user1.Id;
                ulong user2Id = user2.Id;
                var pinaRole = Context.Guild.Roles.FirstOrDefault(x => x.Name == "pina");
                String ment1 = user1.Mention;
                String ment2 = user2.Mention;
                ulong voiceNow = user2.VoiceChannel.Id;
                String voice = user2.VoiceChannel.Name;
                bool checks = true;

                for (int i = 0; i <= 50; i++)
                {
                    if (Ids[i] == user1Id && checks == true)
                    {
                        if (dates[i].AddDays(3) < DateTime.Now)
                        {
                            canPina = true;
                            dates[i] = DateTime.Now;
                            checks = false;
                        }
                        else
                        {
                            canPina = false;
                            checks = false;
                        }
                    }
                }
                if (checks == true)
                {
                    canPina = true;
                    for (int j = 0; j <= 50; j++)
                    {
                        if (Ids[j] == 0 && checks == true)
                        {
                            Ids[j] = user1Id;
                            dates[j] = DateTime.Now;
                            checks = false;
                            break;
                        }
                    }
                }

                if (voice == "הפינה")
                {
                    await ReplyAsync(ment2 + " is already in the pina!");
                }
                else if (canPina == true && voice != "הפינה")
                {
                    if (Context.Guild.VoiceChannels.Contains(coolGangPina))
                    {
                        await user2.ModifyAsync(x => { x.ChannelId = 776381418364207115; });
                    }
                    else
                    {
                        await user2.ModifyAsync(x => { x.ChannelId = voicePinaPlayAndFun; });
                    }
                    userTimer = new System.Timers.Timer(60000);
                    userTimer.Elapsed += OnTimedEvent;
                    userTimer.Enabled = true;

                    userTimer1 = new System.Timers.Timer(2000);
                    userTimer1.Elapsed += OnTimedEvent1;
                    userTimer1.Enabled = true;
                    userTimer1.AutoReset = true;


                    await ReplyAsync(ment1 + " put " + ment2 + " in the pina!");
                    await ReplyAsync("There are 3 days until " + ment1 + " could use his pina again.");
                }
                else { await ReplyAsync("You can't use your pina yet!"); }

                async void OnTimedEvent(Object source, ElapsedEventArgs e)
                {
                    userTimer.Stop();
                    userTimer.Dispose();
                    if (user2.VoiceChannel.Id==(776381418364207115) || user2.VoiceChannel.Id==(playAndFunPina.Id))
                        await user2.ModifyAsync(x => { x.ChannelId = voiceNow; });
                }
                async void OnTimedEvent1(Object source, ElapsedEventArgs e)
                {
                    timerCounter++;
                    if (timerCounter == 28)
                    {
                        check1 = true;
                        userTimer1.Stop();
                        userTimer1.Dispose();
                    }
                    if ((user2.VoiceChannel.Id==(776381418364207115)) || (user2.VoiceChannel.Id==(playAndFunPina.Id)) && check1 == false)
                        return;
                    else if (check1 == false)
                    {
                        check1 = true;
                        await ReplyAsync(ment2 + " just returned to his voice chat without waiting the whole minute in the pina!");
                    }
                }

                for (int s = 0; s <= 50; s++)
                {
                    Console.WriteLine(s + ": " + Ids[s] + ", ");
                }
                for (int s = 0; s <= 50; s++)
                {
                    Console.WriteLine(s + ": " + dates[s] + ", ");
                } 
            }
            else
            {
                if (Context.Guild.VoiceChannels.Contains(coolGangPina))
                    await ReplyAsync("This command can only be used in " + mentPina);
                else
                    await ReplyAsync("This command can only be used in " + mentPinaFun);
            }
        }
        [Command("nextpina")]
        public async Task nextPina(String user1)
        {
            var chatPinaCoolGang = Context.Guild.Channels.FirstOrDefault(x => x.Id == 776381390932410397);
            var chatPinaPlayAndFun = Context.Guild.Channels.FirstOrDefault(x => x.Id == 804337770113663027);
            String mentPina = chatPinaCoolGang.Name;
            String mentPinaFun = chatPinaPlayAndFun.Name;
            if (Context.Message.Channel.Id.Equals(chatPinaCoolGang) || Context.Message.Channel.Id.Equals(chatPinaPlayAndFun))
            { 
                var user = Context.Guild.Users.FirstOrDefault(x => x.Mention.Equals(user1));
                String ment = user.Mention;
                ulong id = user.Id;
                Boolean check = true;
                for (int i = 0; i <= 50; i++)
                {
                    if (Ids[i] == id && check == true)
                    {
                        if (dates[i].AddDays(3) > DateTime.Now)
                        {
                            await ReplyAsync("Next time " + ment + " could use his pina will be: " + dates[i].AddDays(3).ToString());
                            check = false;
                        }
                        else
                        {
                            await ReplyAsync(ment + " can use his pina!");
                            check = false;
                        }
                    }
                    else if (check == true)
                    {
                        await ReplyAsync(ment + " can use his pina!");
                        check = false;
                    }
                }
            }
            else
            {
                if (Context.Guild.Channels.Contains(chatPinaCoolGang))
                    await ReplyAsync("This command can only be used in " + mentPina);
                else
                    await ReplyAsync("This command can only be used in " + mentPinaFun);
            }
        }


    }
}
