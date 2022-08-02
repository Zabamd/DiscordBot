using System;
using System.Drawing;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.Extensions.Configuration;

namespace DiscordBot.Controller;

public class CommandHandler: BaseCommandModule
{
    protected DiscordEmbedBuilder _embed;

    [Command("Hi")]
    [Description("A simple welcome")]
    private  async Task  HiCommand(CommandContext context)
    {
        _embed = new DiscordEmbedBuilder()
        {
            Color = DiscordColor.Blue,
            
        };
        _embed.AddField("Hi!","What's on your mind?");
        await context.RespondAsync(_embed);
    }
    

    [Command("AddEvent")]
    [Description("Add new event to your schedule \n ??AddEvent {event name} -d {date} -p {place}  \n -d and -p are optional")]
    private async Task AddCommand(CommandContext context, [RemainingText, Description("Command string")] string command)
    {
        _embed = new DiscordEmbedBuilder()
        {
            Color = DiscordColor.Blue,
        };
        _embed.Timestamp = DateTimeOffset.Now;
        _embed.Title = command.Split(" ")[1];
        await context.RespondAsync($"added {command}");
    }


}