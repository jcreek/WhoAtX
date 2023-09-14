using Microsoft.AspNetCore.Mvc;
using WhoAtX.Data;
using WhoAtX.Models;

namespace WhoAtX.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Profile()
        {
            // Retrieve user profile data from the database
            var userProfile = _context.UserProfiles.FirstOrDefault();

            if (userProfile is null)
            {
                // throw new NullReferenceException("User not found");
                
                // For now, just give the default data
                userProfile = new UserProfile
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
            }

            // Map UserProfile to UserProfileViewModel
            var userProfileViewModel = new UserProfileViewModel
            {
                Name = userProfile.Name,
                Pronouns = userProfile.Pronouns,
                NamePronunciationPath = userProfile.NamePronunciationPath,
                AreasOfKnowledge = userProfile.AreasOfKnowledge,
                Projects = userProfile.Projects,
                Team = userProfile.Team,
                WorkingHours = userProfile.WorkingHours,
                TimeZone = userProfile.TimeZone,
            };

            // Pass the user profile data to the view
            return View(userProfileViewModel);
        }
    }
}
