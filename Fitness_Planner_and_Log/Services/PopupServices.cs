using System;
using Microsoft.Maui.Controls;

namespace Fitness_Planner_and_Log.Services
{
    public static class PopupService
    {
        public static async Task ShowPopupAsync(Page page)
        {
            await page.Navigation.PushModalAsync(new NavigationPage(page));
        }

        public static async Task DismissPopupAsync(Page page)
        {
            await page.Navigation.PopModalAsync();
        }
    }
}