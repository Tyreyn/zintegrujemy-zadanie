﻿namespace Zintegrujemy_Zadanie.Helpers
{
    #region Usings
    using System.Net;
    #endregion

    /// <summary>
    /// Downloader class.
    /// </summary>
    public static class FileDownloader
    {
        #region Fields and Constants

        /// <summary>
        /// Downloadable file name.
        /// </summary>
        private static string DownloadableFileName;
        #endregion

        #region Public Methods
        /// <summary>
        /// Download specific file.
        /// </summary>
        /// <param name="fileName">
        /// Downloadable file name.
        /// </param>
        /// <param name="url">
        /// Downloadable file URL.
        /// </param>
        /// <param name="projectDirectory">
        /// The current project directory.
        /// </param>
        /// <returns>
        /// True, if download was successful, otherwise false.
        /// </returns>
        public static bool Download(string fileName, string url, string projectDirectory)
        {
            DownloadableFileName = fileName;
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
                    wc.DownloadFileAsync(new Uri(url), Path.Combine(projectDirectory, fileName));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }

            return true;
        }

        #endregion

        #region Private Methods
        private static void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine($"\r file download progress: {DownloadableFileName}   -->    {e.ProgressPercentage}");
        }
        #endregion
    }
}