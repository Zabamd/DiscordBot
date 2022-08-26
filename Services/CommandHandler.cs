using DiscordBot.Services;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Newtonsoft.Json.Linq;

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
            Color = DiscordColor.Red,
            Title = "What's on your mind?",
            Description = "Gimli, son of Glóin,",

        };
        _embed.WithImageUrl("https://upload.wikimedia.org/wikipedia/commons/8/8e/Gimli_son_of_Gloin_by_Perrie_Nicholas_Smith.jpg");


        await context.RespondAsync(_embed);
    }

    [Command("WiseWords")]
    [Description("Get random Gimli quote")]
    private async Task WiseWordsCommand(CommandContext context)
    {
        _embed = new DiscordEmbedBuilder()
        {
            Color = DiscordColor.Red,
            Description = "Gimli, son of Glóin,",
        };

        HttpClient httpClient = new HttpClient();
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://the-one-api.dev/v2/character/5cd99d4bde30eff6ebccfd23/quote"),
            Headers =
                {
                    { "Authorization" , "Bearer awdVuD2keslslQOp-J3f "}
                }
        };

        string body = "";
        using (var response = await httpClient.SendAsync(httpRequestMessage))
        {
            response.EnsureSuccessStatusCode();
            body = await response.Content.ReadAsStringAsync();
        }

        JObject json = JObject.Parse(body);
        Random rand = new Random();

        _embed.Title = (string)json.First.First[rand.Next(0, 115)]["dialog"];

        _embed.WithImageUrl("https://upload.wikimedia.org/wikipedia/commons/8/8e/Gimli_son_of_Gloin_by_Perrie_Nicholas_Smith.jpg");

        await context.RespondAsync(_embed);
    }

}