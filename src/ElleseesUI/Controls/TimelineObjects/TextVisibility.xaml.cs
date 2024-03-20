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

using System.Windows.Controls;

namespace ElleseesUI.Controls.TimelineObjects
{
    /// <summary>
    /// Interaction logic for TextVisibility.xaml
    /// </summary>
    public partial class TextVisibility : UserControl
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TextVisibility" />.
        /// </summary>
        public TextVisibility()
        {
            InitializeComponent();

            // I don't care about external bindings. I want this UserControl to have bindings to point
            // to its properties.
            DataContext = this;
        }

        /// <summary>
        /// Text displayed in the control.
        /// </summary>
        public string ChildValue { get; set; } = string.Empty;
    }
}
