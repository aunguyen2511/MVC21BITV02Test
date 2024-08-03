namespace _404NotFoundMidTest.Models
{
    public class MyTool
    {
        public static string UploadImageToFolder(IFormFile myfile, string folder)
        {
            if (myfile == null)
            {
                return string.Empty;
            }
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folder, myfile.FileName);
                using (var newFile = new FileStream(filePath, FileMode.CreateNew))
                {
                    myfile.CopyTo(newFile);
                }
                return myfile.FileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
