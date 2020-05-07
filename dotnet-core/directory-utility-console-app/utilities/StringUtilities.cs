using System.Linq;

namespace DirectoryUtility.Utilities
{
    public class StringUtilities
    {
        /// <summary>
        /// Check if file can be transformed to Lower case
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool CanTransformToLower(string fileName)
        {
            if (fileName.Any(c => char.IsUpper(c)))
            {
                return true;
            }
            return false;
        } 
        
        /// <summary>
        /// Transform to Lower case
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string TransformToLower(string fileName)
        {
            if (fileName.Any(c => char.IsUpper(c)))
            {
                fileName = fileName.ToLower();
            }
            return fileName;
        }
    }
}
