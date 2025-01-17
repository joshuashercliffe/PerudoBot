﻿using Discord.Commands;
using PerudoBot.GameService;
using System.Linq;
using System.Threading.Tasks;
namespace PerudoBot.Modules
{
    public partial class Commands : ModuleBase<SocketCommandContext>
    {
        private async Task AwardPoints(GameObject game)
        {
            var gamePlayers = game.GetAllPlayers()
                .OrderBy(x => x.Rank)
                .ToList();

            await SendMessageAsync("`Points:`");
            foreach (var gamePlayer in gamePlayers)
            {
                var player = _db.Players.First(x => x.Id == gamePlayer.PlayerId);
                var originalPoints = player.Points;

                var awardedPoints = (gamePlayers.Count() - gamePlayer.Rank + 1) * 10;
                player.Points += awardedPoints;

                _db.SaveChanges();

                await SendMessageAsync($"`{gamePlayer.Rank}` {gamePlayer.Name} `{originalPoints}` => `{player.Points}` ({awardedPoints})");
            }
        }

        [Command("points")]
        public async Task Points(params string[] options)
        {
            var players = _db.Players
                .ToList()
                .OrderByDescending(x => x.Points)
                .ToList();

            var message = "`Points:`";

            foreach (var player in players)
            {
                message += $"\n{player.Name}: `{player.Points}`";
            }
            await SendMessageAsync(message);
        }
    }
}