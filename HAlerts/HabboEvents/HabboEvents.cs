using System;

namespace HAlerts
{
    public static class HabboEvents
    {
        public const string GetHelpTour = "help/tour";
        public const string FindFriends = "friendbar/findfriends";

        public const string ShowMeMenu = "toolbar/memenu";
        public const string ShowQuests = "questengine/quests";
        public const string ShowHelper = "talent/open/helper";
        public const string ShowFriendList = "friendlist/open";
        public const string ShowCitizenShip = "talent/open/helper";
        public const string ShowHabboClubCenter = "habboUI/open/hccenter";
        
        public const string GoToHomeRoom = "navigator/goto/home";

        public static string ShowGroup(int id) => $"group/{id}";
        public static string ShowHabboPage(string name) => $"habbopages/{name}";
        
        public static string GoToRoom(int id) => $"navigator/goto/{id}";

        public static string SearchForRooms(string query) => $"navigator/search/{query}";

        public static string ShowCreditsPage() => "habblet/open/credits";
        public static string ShowThumbnailCamera() => "roomThumbnailCamera/open";

        public static string ShowHabboWebPage(string name) => $"habblet/open/{name}";

        public static string ShowCatalog(HCatalogType type)
            => type == HCatalogType.BuildersClub ? "catalog/warehouse" : "catalog/open";

        public static string ShowCatalogPage(HCatalogType type, string name)
            => type == HCatalogType.BuildersClub ? $"catalog/warehouse/{name}" : $"catalog/open/{name}";

        public static string ShowPlayerProfile(string name) => $"friendbar/user/{name}";
        public static string ShowAvatarEditor() => "avatareditor/open";

        public static string ShowForumsTab(HForumsTab tab)
        {
            string tabStr = Enum.GetName(typeof(HForumsTab), tab).ToLower();
            return $"groupforum/list/{tabStr}";
        }

        public static string ShowInventory(HInventoryTab tab = 0)
        {
            string tabStr = Enum.GetName(typeof(HInventoryTab), tab).ToLower();

            return $"inventory/open/{tabStr}";
        }
        
        public static string ShowAchievements(HAchievementsTab tab = 0)
        {
            string tabStr = Enum.GetName(typeof(HAchievementsTab), tab).ToLower()
                .Replace("roombuilder", "room_builder");

            return $"questengine/achievements/{tabStr}";
        }

        public static string ShowCalendar(bool useAlternative = false)
            => useAlternative ? "openView/calendar" : "questengine/calendar";
        
        public static string HighlightMenu(HHightlightableMenu menu)
        {
            string menuString = "memenu";

            switch (menu)
            {
                case HHightlightableMenu.Catalog: { menuString = "catalog"; break; }
                case HHightlightableMenu.Navigator: { menuString = "navigator"; break; }
            }

            return $"toolbar/highlight/{menuString}";
        }
    }
}
