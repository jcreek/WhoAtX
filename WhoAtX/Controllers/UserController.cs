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

        private UserProfileViewModel MapUserProfileToViewModel(UserProfile userProfile)
        {
            var userProfileViewModel = new UserProfileViewModel
            {
                Id = userProfile.Id,
                Name = userProfile.Name,
                Pronouns = userProfile.Pronouns,
                NamePronunciationPath = userProfile.NamePronunciationPath,
                AreasOfKnowledge = userProfile.AreasOfKnowledge,
                Projects = userProfile.Projects,
                Team = userProfile.Team,
                WorkingHours = userProfile.WorkingHours,
                TimeZone = userProfile.TimeZone,
            };

            return userProfileViewModel;
        }
        
        private UserProfile MapViewModelToUserProfile(UserProfileViewModel userProfileViewModel)
        {
            var userProfile = new UserProfile
            {
                Id = userProfileViewModel.Id,
                Name = userProfileViewModel.Name,
                Pronouns = userProfileViewModel.Pronouns,
                NamePronunciationPath = userProfileViewModel.NamePronunciationPath,
                AreasOfKnowledge = userProfileViewModel.AreasOfKnowledge,
                Projects = userProfileViewModel.Projects,
                Team = userProfileViewModel.Team,
                WorkingHours = userProfileViewModel.WorkingHours,
                TimeZone = userProfileViewModel.TimeZone,
            };

            return userProfile;
        }

        public IActionResult Profile(int id)
        {
            var userProfile = _context.UserProfiles.Find(id);

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

            var userProfileViewModel = MapUserProfileToViewModel(userProfile);

            // Pass the user profile data to the view
            return View(userProfileViewModel);
        }
        
        public IActionResult New()
        {
            return View(new UserProfileViewModel());
        }

        [HttpPost]
        public IActionResult CreateUserProfile(UserProfileViewModel userProfileViewModel)
        {
            if (ModelState.IsValid)
            {
                var userProfile = MapViewModelToUserProfile(userProfileViewModel);

                _context.UserProfiles.Add(userProfile);
                _context.SaveChanges();

                return RedirectToAction("Profile");
            }

            // If ModelState is not valid, return to the create page with validation errors
            return View("New", userProfileViewModel);
        }
        
        public IActionResult Edit(int id)
        {
            var userProfile = _context.UserProfiles.Find(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            var userProfileViewModel = MapUserProfileToViewModel(userProfile);

            return View(userProfileViewModel);
        }
        
        [HttpPost]
        public IActionResult UpdateUserProfile(UserProfileViewModel userProfileViewModel)
        {
            if (ModelState.IsValid)
            {
                var userProfile = MapViewModelToUserProfile(userProfileViewModel);

                _context.UserProfiles.Update(userProfile);
                _context.SaveChanges();

                return RedirectToAction("Profile");
            }

            // If ModelState is not valid, return to the edit page with validation errors
            return View("Edit", userProfileViewModel);
        }
    }
}
