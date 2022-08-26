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
    private DiscordEmbedBuilder _embed;

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

}