﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArchaicQuestII.GameLogic.Character;
using ArchaicQuestII.GameLogic.Core;
using ArchaicQuestII.GameLogic.World.Room;

namespace ArchaicQuestII.GameLogic.Commands.Objects
{

   public class Object: IObject
    {
        private readonly IWriteToClient _writer;
        public Object(IWriteToClient writer)
        {
            _writer = writer;
        }
        public void Get(string target, Room room, Player player)
        {
            //TODO: Get all, get nth (get 2.apple)
            //Check room first
            var item = room.Items.Where(x => x.Stuck == false).FirstOrDefault(x => x.Name.Contains(target, StringComparison.CurrentCultureIgnoreCase));

            if (item == null)
            {
               _writer.WriteLine("<p>You don't see that here.</p>", player.ConnectionId);
               return;
            }

            room.Items.Remove(item);

            foreach (var pc in room.Players)
            {
                if (pc.Name == player.Name)
                {
                    continue;
                }

                _writer.WriteLine($"<p>{player.Name} picks up {item.Name.ToLower()}.</p>", pc.ConnectionId);
            }

            player.Inventory.Add(item);
            _writer.WriteLine($"<p>You pick up {item.Name.ToLower()}.</p>", player.ConnectionId);

            // TODO: You are over encumbered 

        }

        public void Drop(string target, Room room, Player player)
        {
            throw new NotImplementedException();
        }

        public void Open(string target, Room room, Player player)
        {
            throw new NotImplementedException();
        }

        public void Close(string target, Room room, Player player)
        {
            throw new NotImplementedException();
        }

        public void Delete(string target, Room room, Player player)
        {
            throw new NotImplementedException();
        }

    
    }
}
