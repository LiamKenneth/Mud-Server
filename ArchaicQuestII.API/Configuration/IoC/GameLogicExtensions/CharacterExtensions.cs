﻿using ArchaicQuestII.GameLogic.Character.Equipment;
using ArchaicQuestII.GameLogic.Character.Gain;
using ArchaicQuestII.GameLogic.Character.Help;
using ArchaicQuestII.GameLogic.Character.MobFunctions;
using ArchaicQuestII.GameLogic.Character.MobFunctions.Healer;
using ArchaicQuestII.GameLogic.Character.MobFunctions.Shop;
using ArchaicQuestII.GameLogic.Socials;
using Microsoft.Extensions.DependencyInjection;

namespace ArchaicQuestII.API.Configuration.IoC.GameLogicExtensions
{
    public static class CharacterExtensions
    {
        public static IServiceCollection AddCharacterLogic(this IServiceCollection services)
        {
            services.AddSingleton<IGain, Gain>();
            services.AddSingleton<ISocials, Social>();
            services.AddSingleton<IMobFunctions, Shop>();
            services.AddSingleton<IHealer, Healer>();
            services.AddSingleton<IHelp, HelpFile>();

            services.AddTransient<IEquip, Equip>();

            return services;
        }
    }
}
