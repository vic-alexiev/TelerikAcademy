// ********************************
// <copyright file="FileUtils.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
//
// ********************************
namespace Utils
{
    using System;
    using System.IO;

    /// <summary>
    /// Performs operations on <see cref="System.String"/> instances 
    /// that contain file or directory path information.
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// Returns the extension of the specified path string.
        /// </summary>
        /// <param name="path">The path string from which to get the extension.</param>
        /// <returns>The extension of the specified path (excluding the period ".") 
        /// or System.String.Empty. If path is null, FileUtils.GetExtension(System.String) throws 
        /// ArgumentNullException. If path does not have extension information, 
        /// GetExtension(System.String) returns System.String.Empty.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when path is null.</exception>
        public static string GetExtension(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Path is null.");
            }

            int lastDotIndex = path.LastIndexOf(".");
            if (lastDotIndex == -1)
            {
                return string.Empty;
            }

            string extension = path.Substring(lastDotIndex + 1);
            return extension;
        }

        /// <summary>
        /// Returns the file name of the specified path string without the extension.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        /// <returns>The string returned by FileUtils.GetFileNameWithoutExtension(System.String), minus the
        /// last period (.) and all characters following it.</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when path is null.</exception>
        public static string GetFileNameWithoutExtension(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException("Path is null.");
            }

            int lastDotIndex = path.LastIndexOf(".");
            if (lastDotIndex == -1)
            {
                return path;
            }

            string fileNameWithoutExtension = path.Substring(0, lastDotIndex);
            return fileNameWithoutExtension;
        }
    }
}
