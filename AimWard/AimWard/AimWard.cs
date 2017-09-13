using Aimtec;
using Aimtec.SDK.Events;
using Aimtec.SDK.Menu.Components;

using System;
using System.Collections.Generic;
using System.Linq;

using AimWard.Menus;
using AimWard.Fuctions;

namespace AimWard
{
    class Program
    {
        public static Obj_AI_Hero Player = ObjectManager.GetLocalPlayer();
        public static float lastWardTick = 0;

        static void Main(string[] args)
        {
            GameEvents.GameStart += OnLoad;
        }

        private static void OnLoad()
        {
            var LoadMenus = new AimMenu();
            Render.OnRender += Render_OnRender;
            Game.OnUpdate += Game_OnUpdate;
        }

        private static void Render_OnRender()
        {
            if (AimMenu.Menu["drawWardLocation"].As<MenuBool>().Value)
            {
                Functions.DrawWardLocation();
            }
        }

        private static void Game_OnUpdate()
        {
            if (AimMenu.Menu["placeNormalKey"].As<MenuKeyBind>().Value)
            {
                SpellSlot wardSpellSlot = GetGoodWard();

                if (wardSpellSlot == SpellSlot.Unknown || lastWardTick + 1000 > Environment.TickCount)
                    return;

                Vector3? nearestWard = Functions.ScanWardLocation(new Vector3(Game.CursorPos.X, Game.CursorPos.Z, Game.CursorPos.Y));

                if (nearestWard != null && wardSpellSlot != SpellSlot.Unknown)
                {
                    Player.SpellBook.CastSpell(wardSpellSlot, (Vector3)nearestWard);
                    lastWardTick = Environment.TickCount;
                }
            }
        }

        private static SpellSlot GetGoodWard()
        {
            foreach(string ward in normalWards)
            {
                SpellSlot wardSlot = Player.SpellBook.Spells.FirstOrDefault(x => !String.IsNullOrEmpty(x.Name) && x.Name.ToLower() == ward)?.Slot ?? SpellSlot.Unknown;
                if(wardSlot != SpellSlot.Unknown)
                {
                    if (Player.SpellBook.GetSpellState(wardSlot) == SpellState.Ready)
                        return wardSlot;
                }
            }

            return SpellSlot.Unknown;
        }

        static readonly List<String> normalWards = new List<String>
        {
            "itemghostward",
            "sightward",
            "visionward",
            "trinkettotemlvl1",
            "eye of the equinox",
            "eye of the watchers",
            "eye of the oasis",
            "tracker's knife"
        };
    }
}
