namespace CookBeyondLimits.Common
{
    public class AttributesConstraints
    {
        //// Users
        public const int UsernameMaxLength = 256;

        public const int FirstNameMinLength = 2;
        public const int FirstNameMaxLength = 30;

        public const int LastNameMinLength = 2;
        public const int LastNameMaxLength = 30;

        public const int EmailMinLength = 3;
        public const int EmailMaxLength = 256;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 100;

        //// ContactForm
        public const int NameMinLength = 2;
        public const int NameMaxLength = 50;

        public const int ContactFormTitleMinLength = 2;
        public const int ContactFormTitleMaxLength = 100;

        public const int ContactFormContentMinLength = 20;
        public const int ContactFormContentMaxLength = 10000;

        //// Recipe
        public const int RecipeTitleMinLength = 2;
        public const int RecipeTitleMaxLength = 100;

        public const int RecipeDescriptionMinLength = 10;
        public const int RecipeDescriptionMaxLength = 1000;

        //public const int RecipeTimeMinValue = 1;
        //public const int RecipeTimeMaxValue = 300;

        //public const double RecipeYieldMinValue = 0.1;
        //public const double RecipeYieldMaxValue = 10000;

        //// Browse
        //public const int BrowseSingleWordFieldsMaxLength = 20;
        //public const int BrowseMultipleWordFieldsMaxLength = 200;

        //public const double BrowseYieldMinValue = 0.1;
        //public const double BrowseYieldMaxValue = 10000;

        //public const double BrowseNutritionalValueMinValue = 0.1;
        //public const double BrowseNutritionalValueMaxValue = 10000;

        // Category
        public const int CategoryNameMinLength = 3;
        public const int CategoryNameMaxLength = 50;

        //// NutritionalValue
        //public const double NutritionalValueMinValue = 0.1;
        //public const double NutritionalValueMaxValue = 10000;

        //// Reviews
        //public const int ReviewCommentMinLength = 1;
        //public const int ReviewCommentMaxLength = 250;

        //public const int ReviewRatingMinValue = 1;
        //public const int ReviewRatingMaxValue = 5;
    }
}
