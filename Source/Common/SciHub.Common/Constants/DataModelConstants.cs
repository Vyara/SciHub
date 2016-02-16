namespace SciHub.Common.Constants
{
    public class DataModelConstants
    {
        public const int UserFirstNameMinLength = 2;
        public const int UserFirstNameMaxLength = 100;
        public const int UserLastNameMinLength = 2;
        public const int UserLastNameMaxLength = 100;
        public const int UserAboutMaxLength = 500;
        public const string UrlValiadtion = @"(?:([^:/?#]+):)?(?://([^/?#]*))?([^?#]*\.(?:jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?";
    }
}
