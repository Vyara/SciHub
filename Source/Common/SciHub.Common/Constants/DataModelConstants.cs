namespace SciHub.Common.Constants
{
    public class DataModelConstants
    {
        public const int UserFirstNameMinLength = 2;
        public const int UserFirstNameMaxLength = 100;
        public const int UserLastNameMinLength = 2;
        public const int UserLastNameMaxLength = 100;
        public const int UserAboutMaxLength = 500;
        public const int ShortStoryTagMinLength = 50;
        public const int ShortStoryTagMaxLength = 50;
        public const int ShortStoryRatingMinValue = 1;
        public const int ShortStoryRatingMaxValue = 5;
        public const int ShortStoryCommentMinLength = 2;
        public const int ShortStoryCommentMaxLength = 300;
        public const int ShortStoryTitleMinLength = 2;
        public const int ShortStoryTitleMaxLength = 200;
        public const int ShortStoryContentMinLength = 2;
        public const string UrlValiadtion = @"(?:([^:/?#]+):)?(?://([^/?#]*))?([^?#]*\.(?:jpg|gif|png))(?:\?([^#]*))?(?:#(.*))?";
    }
}
