using System;

namespace HAlerts
{
    public static class HabboEvents
    {
        /// <summary>
        /// Opens the avatar editor.
        /// </summary>
        public static string ShowAvatarEditor = "avatareditor/open";
        /// <summary>
        /// Requests a tour through the hotel from a Habbo Helper.
        /// </summary>
        public const string GetHelpTour = "help/tour";
        /// <summary>
        /// Navigates to a random friend finding room.
        /// </summary>
        public const string FindFriends = "friendbar/findfriends";

        /// <summary>
        /// Opens the "Me" menu in the toolbar.
        /// </summary>
        public const string ShowMeMenu = "toolbar/memenu";
        /// <summary>
        /// Opens the quests window.
        /// </summary>
        public const string ShowQuests = "questengine/quests";
        /// <summary>
        /// Opens the Habbo Helper part of the talent track.
        /// </summary>
        public const string ShowHelper = "talent/open/helper";
        /// <summary>
        /// Opens the friend list.
        /// </summary>
        public const string ShowFriendList = "friendlist/open";
        /// <summary>
        /// Opens the Citizenship part of the talent track.
        /// </summary>
        public const string ShowCitizenShip = "talent/open/helper";
        /// <summary>
        /// Opens the Habbo Club Center.
        /// </summary>
        public const string ShowHabboClubCenter = "habboUI/open/hccenter";
        
        /// <summary>
        /// Goes to the room that is currently set as the player's home room.
        /// </summary>
        public const string GoToHomeRoom = "navigator/goto/home";

        /// <summary>
        /// Opens the "buy credits" page on the Habbo website. Keeps the client open in the background.
        /// </summary>
        /// <returns></returns>
        public static string ShowCreditsPage = "habblet/open/credits";
        /// <summary>
        /// Opens the small camera to take a photo for your room thumbnail. Only works when in a room.
        /// </summary>
        /// <returns></returns>
        public static string ShowThumbnailCamera = "roomThumbnailCamera/open";

        /// <summary>
        /// Opens the group details for the chosen group ID.
        /// </summary>
        /// <param name="id">The group ID</param>
        /// <returns></returns>
        public static string ShowGroup(int id) => $"group/{id}";
        /// <summary>
        /// Opens a window in-game with the chosen habbo page (those are hosted on /gamedata/habbopages/)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string ShowHabboPage(string name) => $"habbopages/{name}";
        
        /// <summary>
        /// Navigates to the chosen room ID.
        /// </summary>
        /// <param name="id">The room ID</param>
        /// <returns></returns>
        public static string GoToRoom(int id) => $"navigator/goto/{id}";

        /// <summary>
        /// Opens the navigator and searches for rooms based on the chosen search query.
        /// </summary>
        /// <param name="query">The search query</param>
        /// <returns></returns>
        public static string SearchForRooms(string query) => $"navigator/search/{query}";

        /// <summary>
        /// Opens the chosen page on the Habbo website. Keeps the client open in the background.
        /// </summary>
        /// <param name="name">The page name</param>
        /// <returns></returns>
        public static string ShowHabboWebPage(string name) => $"habblet/open/{name}";
        
        /// <summary>
        /// Opens a user's profile based on the chosen player name.
        /// </summary>
        /// <param name="name">The player name</param>
        /// <returns></returns>
        public static string ShowPlayerProfile(string name) => $"friendbar/user/{name}";
        /// <summary>
        /// Opens the catalog home page.
        /// </summary>
        /// <param name="type">Enum to specify wether the regular or builders club catalog has to be opened</param>
        /// <returns></returns>
        public static string ShowCatalog(HCatalogType type)
            => type == HCatalogType.BuildersClub ? "catalog/warehouse" : "catalog/open";

        /// <summary>
        /// Opens a chat window with a chosen player ID.
        /// </summary>
        /// <param name="id">The player ID</param>
        /// <returns></returns>
        public static string ShowPlayerChat(int id)
            => $"friendlist/openchat/{id}:0";

        /// <summary>
        /// Opens the catalog on the chosen page.
        /// </summary>
        /// <param name="type">Enum to specify wether the regular or builders club catalog has to be opened</param>
        /// <param name="name">The catalog page name</param>
        /// <returns></returns>
        public static string ShowCatalogPage(HCatalogType type, string name)
            => type == HCatalogType.BuildersClub ? $"catalog/warehouse/{name}" : $"catalog/open/{name}";

        /// <summary>
        /// Opens the seasonal calendar. Possibly only works on the hotel view.
        /// </summary>
        /// <param name="useAlternative">Because there are 2 different paths to open the calendar, this parameter lets you use the second option (openView). Default is QuestEngine.</param>
        /// <returns></returns>
        public static string ShowCalendar(bool useAlternative = false)
            => useAlternative ? "openView/calendar" : "questengine/calendar";

        /// <summary>
        /// Opens a list of forums based on the chosen tab.
        /// </summary>
        /// <param name="tab">Enum to specify which forum tab has to be opened.</param>
        /// <returns></returns>
        public static string ShowForumsTab(HForumsTab tab)
        {
            string tabStr = Enum.GetName(typeof(HForumsTab), tab).ToLower();
            return $"groupforum/list/{tabStr}";
        }

        /// <summary>
        /// Opens the inventory on the chosen tab.
        /// </summary>
        /// <param name="tab">Enum to specify which inventory tab has to be opened.</param>
        /// <returns></returns>
        public static string ShowInventory(HInventoryTab tab = 0)
        {
            string tabStr = Enum.GetName(typeof(HInventoryTab), tab).ToLower();

            return $"inventory/open/{tabStr}";
        }
        
        /// <summary>
        /// Opens the achievements window on the chosen tab.
        /// </summary>
        /// <param name="tab">Enum to specify which achievements tab has to be opened.</param>
        /// <returns></returns>
        public static string ShowAchievements(HAchievementsTab tab = 0)
        {
            string tabStr = Enum.GetName(typeof(HAchievementsTab), tab).ToLower()
                .Replace("roombuilder", "room_builder");

            return $"questengine/achievements/{tabStr}";
        }

        /// <summary>
        /// Highlights the chosen menu icon on the toolbar by pointing a big green animated arrow at them.
        /// </summary>
        /// <param name="menu">Enum to specify which menu icon will be highlighted</param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds a help "chatbubble" type of bubble to the selected part of the Habbo UI.
        ///<para>NOTE: If more than one bubble is present at once, only the last bubble will be closable. Others will never leave the UI.</para>
        /// </summary>
        /// <param name="uiControl">Enum to specify which control in the UI needs to have a help bubble added</param>
        /// <param name="message">The message that will be displayed on the help bubble</param>
        /// <returns></returns>
        public static string ShowHelpBubble(HUIControl uiControl, string message)
            => $"helpBubble/add/{Enum.GetName(typeof(HUIControl), uiControl)}/{message}";

        /// <summary>
        /// Removes a help "chatbubble" type of bubble from the selected part of the Habbo UI.
        /// </summary>
        /// <param name="uiControl">Enum to specify which control in the UI needs to have a help bubble added</param>
        /// <returns></returns>
        public static string RemoveHelpBubble(HUIControl uiControl)
            => $"helpBubble/remove/{Enum.GetName(typeof(HUIControl), uiControl)}";
    }
}
