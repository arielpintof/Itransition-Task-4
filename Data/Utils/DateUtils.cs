namespace Task4WebExample.Data.Utils;

public class DateUtils
{
    public static string GetTimeDifference(DateTime? lastLogin)
    {
        if (lastLogin is null) return "Never";

        var ts = DateTime.Now - lastLogin.Value;

        switch (ts.TotalMinutes)
        {
            case < 1:
                return "Just now";
            case < 60:
                return $"{ts.Minutes} minute{(ts.Minutes > 1 ? "s" : "")} ago";
        }

        if (ts.TotalHours < 24)
            return $"{ts.Hours} hour{(ts.Hours > 1 ? "s" : "")} ago";
        
        switch (ts.TotalDays)
        {
            case < 30:
                return $"{ts.Days} day{(ts.Days > 1 ? "s" : "")} ago";
            case < 365:
            {
                var months = (int)(ts.TotalDays / 30);
                return $"{months} month{(months > 1 ? "s" : "")} ago";
            }
            default:
            {
                var years = (int)(ts.TotalDays / 365);
                return $"{years} year{(years > 1 ? "s" : "")} ago";
            }
        }
    }
}