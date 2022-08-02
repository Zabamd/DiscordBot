using System;
using DiscordBot.Controller;
using DSharpPlus;
using DSharpPlus.CommandsNext;
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
                .Build();
            
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = config["botToken"],
                TokenType = TokenType.Bot,
            });

            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            { 
                StringPrefixes = new[] { "??" }
            });

            commands.RegisterCommands<CommandHandler>();
            
            await discord.ConnectAsync();
            
            await Task.Delay(-1, token);
            
        }
        
    }
};

