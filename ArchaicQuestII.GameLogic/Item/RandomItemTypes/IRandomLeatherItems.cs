﻿using System;
using System.Collections.Generic;
using System.Text;
using ArchaicQuestII.GameLogic.Character;

namespace ArchaicQuestII.GameLogic.Item.RandomItemTypes
{
   public interface IRandomLeatherItems
   {
       public Item CreateRandomItem(Player player, bool legendary);
   }
}
