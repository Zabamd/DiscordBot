using System;
using DSharpPlus;
using Microsoft.Extensions.Configuration;

namespace DiscordBot
{
    static class DiscordBot
    {
        private static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;
            
            var config = new ConfigurationBuilder()
                .AddJsonFile("botSettings.json",true)
                .AddUserSecrets(typeof(DiscordBot).Assembly, true)
                .Build();
            
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = config["botToken"],
                TokenType = TokenType.Bot,
            });
            
            discord.MessageCreated += async (client,args) =>
            {
                if (args.Message.Content.StartsWith("??"))
                {
                    await client.SendMessageAsync(args.Channel ,"Hi!");
                }
            };
            
            await discord.ConnectAsync();
            
            await Task.Delay(-1, token);
            
        }
        
    }
};

