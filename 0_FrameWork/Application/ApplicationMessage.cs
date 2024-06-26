namespace _0_FrameWork.Application
{
    public class ApplicationMessage
    {

        public const string DuplicatedEmailAddress = "You have already registered with this email.";
        public const string DuplicatedUser = "This user already exists.";
        public const string DuplicatedRecord = "Duplicate record entry is not allowed. Please try again.";
        public const string RecordNotFount = "No record found with these specifications.";
        public const string PasswordNotFount = "Your current password is incorrect.";
        public const string CheckEmailForExist = ".";
        public const string ExistUserCourse = "You have already purchased this course.";
        public const string IsNotImage = "Invalid image format.";
        public const string MaxSizePhoto = "The image size exceeds the allowed limit.";
       // public const string ServerError = "System error.";
        public const string BirthDate = "Invalid birthdate format.";
        public const string ServerError = "A server-side error has occurred. Please contact support.";
        public const string AlreadyTakenExam = "You have already taken the exam.";
        public const string AlreadyRegisteredInCourse = "You have already registered for this course.";
        public const string InvalidBirthDate = "Invalid birthdate format.";
        public const string ConfirmNotRobot = "Please confirm you are not a robot";

        public const string LoginToContinueRegisterCourse =
            "Please log in to continue. If not registered, kindly sign up first and retry.";
        public static string RelatedRemoveMessage => "به دلیل وابستگی قابل حذف نیست";

        public static string PhotoIsRequired = "افزودن حد اقل یک تصویر الزامی میباشد";
        // public static string RelatedRemoveMessage => "Due to dependencies, it cannot be deleted.";


        //public const string DuplicatedEmailAddress = "با این ایمیل قبلا ثبت نام کرده اید. ";
        //public const string DuplicatedUser = "این کاربر از قبل وجود دارد ";
        //public const string DuplicatedRecord = "ثبت رکورد تکراری مجاز نمیباشد، مجدداً تلاش کنید. ";
        //public const string RecordNotFount = " هیچ رکوردی با این مشخصات یافت نشد.";
        //public const string PasswordNotFount = "رمز عبور فعلی شما درست نمیباشد";
        //public const string CheckEmailForExist = ".";
        //public const string ExistUserCourse = "شما این کورسرا قبلا خریداری کرده اید.";
        //public const string IsNotImage = "فرمت عکس نامعتبر هست";
        //public const string MaxSizePhoto = "حجم عکس بیشتر از حد مجاز میباشد";
        //public const string ServerError = "خطای سیستمی";
        //public const string BirthDate = "فرمت تاریخ تولد معتبر نیست";

        public static string IncorrectPassword = "Your password is incorrect.";
        public static string OperationDone = "The operation was successfully completed";
        public static string NotRegistration = "You haven't signed up on the website yet.";
        public const string PasswordChangedSuccessfully = "Your password has been successfully changed.";

        public const string ResetPasswordEmailSent = "A password reset email has been sent to you. Follow the instructions in the email to continue the password reset process.";

        public const string AccountInactive = "Your account is inactive.";

    }

    public class Validate
    {
        public const string Required = "This field is required.";
        public const string MaxLength = "The characters in {0} exceed the allowed limit of {1}.";
        public const string Url = "Invalid URL.";
        public const string PasswordsDoNotMatch = "Passwords do not match.";

        //public const string Required = "پر کردن این فیلد اجباری میباشد";
        //public const string MaxLength = "کاراکتر های {0} بیشتر از حد مجاز {1} میباشد";
        //public const string Url = "لینک معتبر نیست";
    }

    public static class ThisType
    {
        public const int Course = 1;
        public const int Article = 2;
        public const int Comment = 3;
        public const int Account = 4;
        public const int Order = 5;
        public const int Index = 6;
        public const int EnterWallet = 7;
        public const int ExistWallet = 8;
        public const int Teacher = 9;
        public const int Blogger = 10;
        public const int AdminPanelIndex = 11;
        public const int ShowQuestion = 12;
        public const int Slide = 13;
        public const int SlideText = 14;
        public const int News= 15;
        public const int CourseCategory = 16;
        public const int Men = 1;
        public const int Female = 2;
    }

    public static class RoleType
    {
        public const int Manager = 1;
        public const int Manager1 = 7;
        public const int Teacher = 2;
        public const int Admin = 3;
        public const int User = 4;
        public const int Blogger = 5;
        public const int NoAuthorize = 6;
    }

    public static class PermissionPlace
    {
        //Dashboard Administration
        public const int AdministrationHomepage = 1;
        public const int AdministrationNotifications = 2;


        //Courses
        public const int ListCourses = 100;
        public const int SearchCourses = 101;
        public const int CreateCourses = 102;
        public const int EditCourses = 103;


        //CourseGroup
        public const int ListCourseGroups = 200;
        public const int SearchCourseGroups = 201;
        public const int CreateCourseGroups = 202;
        public const int EditCourseGroups = 203;
        public const int DeleteCourseGroups = 204;
        public const int RestoreCourseGroups = 205;


        //Articles
        public const int ListArticles = 400;
        public const int SearchArticles = 401;
        public const int CreateArticles = 402;
        public const int EditListArticles = 403;

        //ArticlesGroup
        public const int ListArticleCategories = 500;
        public const int SearchArticleCategories = 501;
        public const int CreateArticleCategories = 502;
        public const int EditArticleCategories = 503;

        //Course Level
        public const int CreateCourseLevel = 600;
        public const int EditCourseLevel = 601;

        //Course Status 
        public const int CreateCourseStatus = 610;
        public const int EditCourseStatus = 611;

        //CourseEpisode
        public const int ListCourseEpisodes = 620;
        public const int CreateCourseEpisodes = 621;
        public const int EditCourseEpisodes = 622;
        
        //onlineCourse
        public const int ListOnlineCourse= 623;
        public const int CreateOnlineCourse = 624;
        public const int EditOnlineCourse = 625;

        //CostumerDiscount
        public const int ListCostumerDiscount = 700;
        public const int SearchCostumerDiscount = 701;
        public const int CreateCostumerDiscount = 702;
        public const int EditCostumerDiscount = 703;
        public const int DeleteCostumerDiscount = 704;
        public const int RestoreCostumerDiscount = 705;


        //ColleagueDiscount
        public const int ListColleagueDiscount = 710;
        public const int SearchColleagueDiscount = 711;
        public const int CreateColleagueDiscount = 712;
        public const int EditColleagueDiscount = 713;
        public const int DeleteColleagueDiscount = 714;
        public const int RestoreColleagueDiscount = 715;

        //DiscountCode
        public const int ListDiscountCode = 720;
        public const int SearchDiscountCode = 721;
        public const int CreateDiscountCode = 722;
        public const int EditDiscountCode = 723;

        //users
        public const int ListUsers = 801;
        public const int SearchUsers = 802;
        public const int CreateUsers = 803;
        public const int EditUsers = 804;
        public const int BlockUsers = 805;
        public const int UnBlockUsers = 806;
        public const int ChangePasswordUsers = 807;
        public const int ListBlockedUsers = 808;

        //Teachers and Blogger
        public const int ListTeacherAndBlogger = 810;
        public const int EditTeacherAndBlogger = 811;
        public const int DeleteTeacherAndBlogger = 812;

        //Roles
        public const int ListRoles = 820;
        public const int CreateRoles = 821;
        public const int EditRoles = 822;

        //Comments
        public const int ListComments = 900;
        public const int ApproveComments = 901;
        public const int CancelComments = 902;
        public const int SearchComments = 903;


        //Homephoto
        public const int ChangePhotoHomePage = 1020;
        public const int CreatePhotoHomePage = 1021;

        //System Administrator
        public const int SystemAdministratorNotification = 1000;
        public const int SystemAdministratorOrders = 1001;
        public const int SystemAdministratorActivity = 1002;

        //News
        public const int ListNews= 1003;
        public const int CreateNews= 1004;
        public const int EditNews= 1005;


        public const int Slider= 1006;
        public const int Gallery= 1007;
        public const int Settings= 1008;
        public const int ListCity= 1009;


        //Quiz
        public const int ListQuiz = 1010;
        public const int CreateQuiz = 1011;
        public const int EditQuiz = 1012;


        public const int ListQuestion = 1013;
        public const int AddQuestion = 1014;
        public const int EditQuestion = 10153;
    }
}