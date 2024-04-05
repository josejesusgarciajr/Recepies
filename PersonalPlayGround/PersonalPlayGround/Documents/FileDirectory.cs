using System.Web;

namespace PersonalPlayGround.Documents
{
    public static class FileDirectory
    {
        public static readonly string WebRootPath = HttpContext.Current.Server.MapPath("~");
        public static readonly string RecipesDatabaseFolder = "Images\\Recipes\\";
        public static readonly string Image_Needed = "\\Images\\Image_Needed.png";
    }
}