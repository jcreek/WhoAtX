namespace WhoAtX.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Pronouns { get; set; }
    public string? NamePronunciationPath { get; set; }
    public string AreasOfKnowledge { get; set; }
    public string Projects { get; set; }
    public string Team { get; set; }
    public string WorkingHours { get; set; }
    public string TimeZone { get; set; }
}
