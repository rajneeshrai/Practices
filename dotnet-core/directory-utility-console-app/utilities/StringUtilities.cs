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
        public static bool CanTransformToLowerCase(string fileName)
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
        public static string TransformToLowerCase(string fileName)
        {
            if (fileName.Any(c => char.IsUpper(c)))
            {
                fileName = fileName.ToLower();
            }
            return fileName;
        }

        /// <summary>
        /// Transform to Upper Case
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string TraformToUpperCase(string fileName)
        {
            return fileName.ToUpper();
        }

        /// <summary>
        /// Transform to Camel Case
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string TransformToCamelCase(string fileName)
        {
            var charArray = fileName.ToCharArray();
            charArray[0] = char.ToUpper(charArray[0]);
            return string.Join(string.Empty, charArray);
        }
    }
}
