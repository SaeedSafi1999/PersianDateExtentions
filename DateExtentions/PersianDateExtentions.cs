using System;
using System.Globalization;
using System.Linq;

namespace DateExtentions
{
    public static class PersianDateExtentions
    {


        ///this local method used for Change language    

        static char[][] persianChars = new char[][]
        {
        "0123456789".ToCharArray(),"۰۱۲۳۴۵۶۷۸۹".ToCharArray()
        };
        static char[][] arabicChars = new char[][]
        {
        "0123456789".ToCharArray(),"٠١٢٣٤٥٦٧٨٩".ToCharArray()
        };
        public static string ToEnglishNumber(this string src)
        {
            if (string.IsNullOrEmpty(src)) return null;
            for (int x = 0; x <= 9; x++)
            {
                src = src.Replace(persianChars[1][x], persianChars[0][x]);
            }
            for (int x = 0; x <= 9; x++)
            {
                src = src.Replace(arabicChars[1][x], arabicChars[0][x]);
            }
            return src;
        }//convert to english number
        public static string ToPersianNumber(this string src)
        {
            if (string.IsNullOrEmpty(src)) return null;
            for (int x = 0; x <= 9; x++)
            {
                src = src.Replace(persianChars[0][x], persianChars[1][x]);
            }
            return src;
        }//convert to persian number
        public static string ConvertDayOfWeekToPersian(string DayInEnglish)
        {
            switch (DayInEnglish)
            {
                case "Monday":
                    return "دوشنبه";
                    break;
                case "Tuesday":
                    return "سه شنبه";
                    break;
                case "Wednesday":
                    return "چهار شنبه";
                    break;
                case "Thursday":
                    return "پنج شنبه";
                    break;
                case "Friday":
                    return "جمه";
                    break;
                case "Sunday":
                    return "یکشنبه";
                    break;
                case "Saturday":
                    return "شنبه";
                    break;
                default:
                    return null;
            }
        }//convert from english day of weeks to persian

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static DateTime ConvertToEnglishDate(DateTime Date)
        {
            Calendar persian = new PersianCalendar();
            var date = Date.ToString("yyy/MM/dd");
            int[] yyyy = date.Split('/').Select(x => int.Parse(x)).ToArray();
            DateTime dateRes = new DateTime(yyyy[0], yyyy[1], yyyy[2], persian);
            return dateRes;
        }// this method returns other dates to english dates
        public static string ConvertToEnglishDateWithPersianNumbers(DateTime Date)
        {
            Calendar persian = new PersianCalendar();
            var date = Date.ToString("yyy/MM/dd");
            int[] yyyy = date.Split('/').Select(x => int.Parse(x)).ToArray();
            DateTime dateRes = new DateTime(yyyy[0], yyyy[1], yyyy[2], persian);
            return ToPersianNumber(dateRes.ToString("yyy/MM/dd"));
        }// this method returns other dates to english dates with persian numbers
        public static string ConvertToPersianDate(DateTime Date, bool WithPersianMonth = false)
        {

            DateTime date = DateTime.ParseExact(Date.ToString("yyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            PersianCalendar persianCalendar = new PersianCalendar();
            if (WithPersianMonth)
            {
                int persianYear = persianCalendar.GetYear(date);
                string[] persianMonths = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
                string persianMonth = persianMonths[persianCalendar.GetMonth(date) - 1];
                int persianDay = persianCalendar.GetDayOfMonth(date);
                return $"{persianYear}/{persianMonth}/{persianDay}";
            }
            else
            {
                int persianYear = persianCalendar.GetYear(date);
                var persianMonth = persianCalendar.GetMonth(date);
                int persianDay = persianCalendar.GetDayOfMonth(date);
                return $"{persianYear}/{persianMonth}/{persianDay}";
            }
        }// this method returns other dates to persian dates
        public static string ConvertToShortPersianDate(DateTime Date)
        {
            DateTime date = DateTime.ParseExact(Date.ToString("yyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            PersianCalendar persianCalendar = new PersianCalendar();
            int persianYear = persianCalendar.GetYear(date);
            string[] persianMonths = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            string persianMonth = persianMonths[persianCalendar.GetMonth(date) - 1];
            int persianDay = persianCalendar.GetDayOfMonth(date);
            DayOfWeek PersianDayOfWeekRes = persianCalendar.GetDayOfWeek(date);
            var resWeekDay = ConvertDayOfWeekToPersian(PersianDayOfWeekRes.ToString());
            return $"{persianMonth} {persianDay} {resWeekDay}";
        }// this method returns other dates to short persian dates
        public static string ConvertToPersianDate(DateTime Date, bool WithPersianNumbers, bool WithPersianMonth = false)
        {

            DateTime date = DateTime.ParseExact(Date.ToString("yyy/MM/dd"), "yyyy/MM/dd", CultureInfo.InvariantCulture);
            int year = date.Year;
            int month = date.Month;
            int day = date.Day;
            PersianCalendar persianCalendar = new PersianCalendar();
            if (WithPersianMonth)
            {
                int persianYear = persianCalendar.GetYear(date);
                string[] persianMonths = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
                string persianMonth = persianMonths[persianCalendar.GetMonth(date) - 1];
                int persianDay = persianCalendar.GetDayOfMonth(date);
                if (WithPersianNumbers)
                {
                    return ToPersianNumber($"{persianYear}/{persianMonth}/{persianDay}");
                }
                else
                {
                    return $"{persianYear}/{persianMonth}/{persianDay}";
                }

            }
            else
            {
                int persianYear = persianCalendar.GetYear(date);
                var persianMonth = persianCalendar.GetMonth(date);
                int persianDay = persianCalendar.GetDayOfMonth(date);
                if (WithPersianNumbers)
                {
                    return ToPersianNumber($"{persianYear}/{persianMonth}/{persianDay}");
                }
                else
                {
                    return $"{persianYear}/{persianMonth}/{persianDay}";
                }
            }
        }// this method returns other dates to persian dates
        

    }
}
