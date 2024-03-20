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
/// A common service for breadcrumbs
/// </summary>
internal class BreadcrumbService : IBreadcrumbService
{
    private readonly string m_breadcrumbName;
    private bool m_allowed;

    /// <summary>
    /// Initializes a new instance of <see cref="BreadcrumbService" />
    /// </summary>
    /// <param name="breadcrumbName">A breadcrumb filename to write to</param>
    public BreadcrumbService(string breadcrumbName = BreadcrumbConstants.BreadcrumbFile)
    {
        m_breadcrumbName = breadcrumbName;
        m_allowed = false;
    }

    /// <inheritdoc />
    public void Write(string text)
        => File.AppendAllText(m_breadcrumbName, $"[{DateTime.Now}]: {text}{Environment.NewLine}{Environment.NewLine}");

    /// <inheritdoc />
    public void WriteIfAllowed(string text)
    {
        if (m_allowed)
        {
            Write(text);
        }
    }

    /// <inheritdoc />
    public void Allow() => m_allowed = true;
    /// <inheritdoc />
    public void Disallow() => m_allowed = false;
    /// <inheritdoc />
    public void Toggle() => m_allowed = !m_allowed;

    /// <inheritdoc />
    public string BreadcrumbName
    {
        get => m_breadcrumbName;
    }

    /// <inheritdoc />
    public bool Allowed
    {
        get => m_allowed;
    }
}
