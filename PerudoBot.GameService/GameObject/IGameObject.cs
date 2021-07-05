﻿using System.Collections.Generic;

namespace PerudoBot.GameService
{
    public interface IGameObject
    {
        public void OnEndOfRound();
        public void OnEndOfGame();
        public void Start();
        public bool Bid(int quantity, int pips);
        public PlayerData GetCurrentPlayer();
        public int GetCurrentRoundNumber();
        public bool BidReverse(int quantity, int pips);
        public List<PlayerData> GetPlayerDice();
        public LiarResult Liar();
        public bool CreateGame(ulong guildId);
        public bool AddPlayer(ulong userId, ulong guildId, string name, bool isBot);
        public bool SetModeSuddenDeath();
        public bool SetModeVariable();
        public RoundStatus StartNewRound();
    }
}
