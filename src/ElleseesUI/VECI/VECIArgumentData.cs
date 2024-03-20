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

namespace ElleseesUI.VECI;

internal static class VECIArgumentData
{
    public static string GetValueOfArgument(string argstr, string arg)
    {
        if (!argstr.Contains('|'))
        {
            if (argstr.Split('=')[0] != arg)
            {
                throw new ArgumentException($"No argument with name \"{arg}\" was found.", nameof(arg));
            }
            else
            {
                return argstr.Split('=')[1];
            }
        }

        foreach (string s in argstr.Split("|"))
        {
            if (s.Split('=')[0] == arg)
            {
                return s.Split('=')[1];
            }
        }

        throw new ArgumentException($"No argument with name \"{arg}\" was found.", nameof(arg));
    }
}
