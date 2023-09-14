using Microsoft.AspNetCore.Mvc;
using WhoAtX.Models;

namespace WhoAtX.Controllers
{
    public class UserController : Controller
    {
        // TODO(#8): Get data from database rather than hard-coding it
        private UserProfileViewModel GetUserProfile()
        {
            // Sample user profile data
            var userProfile = new UserProfileViewModel
            {
                Name = "John Doe",
                Pronouns = "He/Him",
                NamePronunciationPath = "/audio/john_doe_pronunciation.mp3",
                // NamePronunciationPath = null,
                // Add more user profile data here
                AreasOfKnowledge = "Web Development",
                Projects = "Project X",
                Team = "Development Team",
                WorkingHours = "9:00 AM - 5:00 PM",
                TimeZone = "UTC-05:00",
                // Add more professional details here
            };

            return userProfile;
        }

        public IActionResult Profile()
        {
            // Retrieve user profile data
            var userProfile = GetUserProfile();

            // Pass the user profile data to the view
            return View(userProfile);
        }
    }
}
