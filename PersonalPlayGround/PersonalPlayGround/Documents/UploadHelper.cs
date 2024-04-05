using System.IO;
using System.Web;

namespace PersonalPlayGround.Documents
{
    public static class UploadHelper
    {
        public static void UploadRecipeImage(HttpPostedFileBase uploadFile)
        {
            string filePath = Path.Combine(FileDirectory.WebRootPath, FileDirectory.RecipesDatabaseFolder, uploadFile.FileName);
            if (!File.Exists(filePath))
            {
                uploadFile.SaveAs(filePath);
            }
        }
    }
}