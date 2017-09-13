using Aimtec.SDK.Menu;
using Aimtec.SDK.Menu.Components;

namespace AimWard.Menus
{
    class AimMenu
    {
        public static Menu Menu = new Menu("AimWard", "AimWard", true);

        public AimMenu()
        {
            var DrawingMenu = new Menu("Drawing", "Drawing");
            {
                DrawingMenu.Add(new MenuBool("drawWardLocation", "Draw Ward Location"));
                DrawingMenu.Add(new MenuSlider("drawDistanceFromWard", "Draw is not bigger than", 2000, 1, 10000));
            }
            Menu.Add(DrawingMenu);

            var HotkeyMenu = new Menu("Hotkey", "Hotkey");
            {
                HotkeyMenu.Add(new MenuKeyBind("placeNormalKey", "Place Normal Ward", Aimtec.SDK.Util.KeyCode.None, KeybindType.Press));
            }
            Menu.Add(HotkeyMenu);
            Menu.Attach();
        }
    }
}
