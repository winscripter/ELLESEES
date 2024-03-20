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

namespace ElleseesUI.Core.ImageEditor;

internal struct Settings
{
    private float _hue = 0;
    private float _saturation = 0;
    private float _brightness = 0;
    private float _contrast = 0;
    private float _opacity = 0;

    public Settings()
    {
    }

    public float Hue
    {
        readonly get
        {
            return _hue;
        }
        set
        {
            _hue = value;
        }
    }

    public float Saturation
    {
        readonly get
        {
            return _saturation;
        }
        set
        {
            _saturation = value;
        }
    }

    public float Brightness
    {
        readonly get
        {
            return _brightness;
        }
        set
        {
            _brightness = value;
        }
    }

    public float Contrast
    {
        readonly get
        {
            return _contrast;
        }
        set
        {
            _contrast = value;
        }
    }

    public float Opacity
    {
        readonly get
        {
            return _opacity;
        }
        set
        {
            _opacity = value;
        }
    }
}
