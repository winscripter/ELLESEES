// MIT License
// 
// Copyright (c) 2024 winscripter
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

namespace ElleseesUI.Services.Breadcrumb;

/// <summary>
/// Constant strings used by breadcrumb navigation
/// </summary>
internal static class BreadcrumbConstants
{
    /// <summary>
    /// Breadcrumb log file
    /// </summary>
    public const string BreadcrumbFile = "Ellesees.breadcrumb.log";

    /// <summary>
    /// String constants for breadcrumbs
    /// </summary>
    public static class BreadcrumbMessageConstants
    {
        /// <summary>
        /// Constant for user opening video editor
        /// </summary>
        public const string UserOpensVideoEditor = "User opened video editor";

        /// <summary>
        /// Constant for user opening video editor without loading projects
        /// </summary>
        public const string UserOpensVideoEditorNoProject = "User opened video editor, but didn't load a project";

        /// <summary>
        /// Constant for user opening project and is currently being loaded
        /// </summary>
        public const string ProjectLoading = "User opened video editor, and ELLESEES is loading the project...";

        /// <summary>
        /// Constant for user opening project that couldn't be loaded
        /// </summary>
        public const string ProjectLoadError = "User opened video editor, but project couldn't load";

        /// <summary>
        /// Constant for user opening project that opened successfully
        /// </summary>
        public const string ProjectLoaded = "User opened video editor and project has loaded successfully";
    }
}
