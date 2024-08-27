namespace ZooManagement.Helpers
{
    public static class DateHelper
    {
        public static int CalculateAge(DateTime DOB)
        {
            var todayDate = DateTime.Today;
            var age = todayDate.Subtract(DOB).TotalDays;
            return (int)Math.Round(age/365);
        }

    }
}