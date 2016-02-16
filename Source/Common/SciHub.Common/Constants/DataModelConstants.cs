namespace SciHub.Common.Constants
{
    public class DataModelConstants
    {
        public const string UrlValiadtion = @"(?:([^:/?#]+):)?(?://([^/?#]*))?([^?#]*\.(?:jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?";
        public const int TagMinLength = 1;
        public const int TagMaxLength = 50;
        public const int ActorFirstNameMinLength = 2;
        public const int ActorFirstNameMaxLength = 100;
        public const int ActorLastNameMinLength = 2;
        public const int ActorLastNameMaxLength = 100;
        public const int DirectorFirstNameMinLength = 2;
        public const int DirectorFirstNameMaxLength = 100;
        public const int DirectorLastNameMinLength = 2;
        public const int DirectorLastNameMaxLength = 100;
    }
}
