namespace _0_FrameWork.Application
{
    public static class FixedText
    {
        public static string FixEmail(this string email)
        {
            return email.Trim().ToLower();
        }
    }
}