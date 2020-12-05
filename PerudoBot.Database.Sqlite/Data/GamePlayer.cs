﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PerudoBot.Database.Sqlite.Data
{
    public class GamePlayer
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }

        public virtual Player Player { get; set; }

        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<GamePlayerRound> GamePlayerRounds { get; set; }// = new List<GamePlayerRound>();

        public int NumberOfDice { get; set; }
        public string Dice { get; set; }
        public int TurnOrder { get; internal set; }


        public GamePlayerRound CurrentGamePlayerRound
        {
            get
            {
                return GamePlayerRounds?.LastOrDefault();
            }
        }

    }
}