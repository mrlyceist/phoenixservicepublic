namespace PhoenixService.ScheduleApp
{
    // TODO: move to NCore
    public static class StringExtensions
    {
        /// <summary>
        /// замена +7 на 8 для телефонных номеров
        /// </summary>
        /// <param name="cNumber"></param>
        /// <returns></returns>
        public static string NumberDelPlus(this string cNumber)
        {
            if (cNumber.Substring(0, 1) == "+")
            {
                cNumber = cNumber.Substring(1);
            }
            if (cNumber.Substring(0, 1) == "7")
            {
                cNumber = "8" + cNumber.Substring(1);
            }
            return cNumber;
        }
    }
}