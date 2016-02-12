using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberHidesStaticFromOuterClass

namespace AddonTemplate
{
    // I can't really help you with my layout of a good config class
    // since everyone does it the way they like it most, go checkout my
    // config classes I make on my GitHub if you wanna take over the
    // complex way that I use
    public static class Config
    {
        private static readonly string MenuName = "DarkTeemo";

        private static readonly Menu Menu;

        static Config()
        {
            // Initialize the menu
            Menu = MainMenu.AddMenu(MenuName, MenuName.ToLower());
            Menu.AddGroupLabel("Welcome to DarkTeemo");
            Menu.AddGroupLabel("More addons/Updates will be Coming soon!");

            // Initialize the modes
            Modes.Initialize();
        }

        public static void Initialize()
        {
        }

        public static class Modes
        {
            private static readonly Menu ComboPage, HarassPage, LaneclearPage, JungleclearPage, FleePage, MiscPage;

            static Modes()
            {
                // Initialize all modes
                ComboPage = Menu.AddSubMenu("Combo");
                // Combo
                Combo.Initialize();
                Menu.AddSeparator();
                HarassPage = Menu.AddSubMenu("Harass");
                // Harass
                Harass.Initialize();
                FleePage = Menu.AddSubMenu("Flee");
                //Flee
                Flee.Initialize();
                LaneclearPage = Menu.AddSubMenu("Laneclear");
                //LaneClear
                Laneclear.Initialize();
            }

            public static void Initialize()
            {
            }

            public static class Combo
            {
                private static readonly CheckBox _useQ;
                private static readonly CheckBox _useW;
                private static readonly CheckBox _useR;

                static Combo()
                {
                    // Initialize the menu values
                    ComboPage.AddGroupLabel("Combo");
                    _useQ = ComboPage.Add("comboUseQ", new CheckBox("Use Q"));
                    _useW = ComboPage.Add("comboUseW", new CheckBox("Use W"));
                    _useR = ComboPage.Add("comboUseR", new CheckBox("Use R", false)); // Default false
                }

                public static bool UseQ
                {
                    get { return _useQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _useW.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _useR.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class Harass
            {
                private static readonly CheckBox _UseQ;
                private static readonly CheckBox _UseW;
                private static readonly CheckBox _UseR;
                private static readonly Slider _Mana;

                static Harass()
                {
                    // Here is another option on how to use the menu, but I prefer the
                    // way that I used in the combo class
                    HarassPage.AddGroupLabel("Harass");
                    _UseQ = HarassPage.Add("harassUseQ", new CheckBox("Use Q"));
                    _UseW = HarassPage.Add("harassUseW", new CheckBox("Use W"));
                    _UseR = HarassPage.Add("harassUseR", new CheckBox("Use R", false)); // Default false

                    // Adding a slider, we have a little more options with them, using {0} {1} and {2}
                    // in the display name will replace it with 0=current 1=min and 2=max value
                    _Mana = HarassPage.Add("harassMana", new Slider("Maximum mana usage in percent ({0}%)", 40));
                }

                public static bool UseQ
                {
                    get { return _UseQ.CurrentValue; }
                }

                public static bool UseW
                {
                    get { return _UseW.CurrentValue; }
                }

                public static bool UseR
                {
                    get { return _UseR.CurrentValue; }
                }

                public static float Mana
                {
                    get { return _Mana.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class Flee
            {
                public static readonly CheckBox _UseW;
                public static readonly CheckBox _UseR;

                static Flee()
                {
                   FleePage.AddGroupLabel("Flee");
                    _UseW = FleePage.Add("fleeUseW", new CheckBox("Use W"));
                    _UseR = FleePage.Add("fleeUseR", new CheckBox("Use R Behind You"));
                }

                public static bool UseW
                {
                    get { return _UseW.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }

            public static class Laneclear
            {
                public static readonly CheckBox _UseR;

                static Laneclear()
                {
                    LaneclearPage.AddGroupLabel("Laneclear");
                    _UseR = LaneclearPage.Add("laneUseR", new CheckBox("Use R"));
                }

                public static bool UseR
                {
                    get { return _UseR.CurrentValue; }
                }

                public static void Initialize()
                {
                }
            }
        }
    }
}