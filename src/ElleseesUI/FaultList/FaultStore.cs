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

using System.Collections.ObjectModel;

namespace ElleseesUI.FaultList;

/// <summary>
/// A list of faults.
/// </summary>
public static class FaultStore
{
    /// <summary>
    /// A list of unhandled faults.
    /// </summary>
    public static readonly ObservableCollection<Fault> Faults = new();

    /// <summary>
    /// Adds a fault.
    /// </summary>
    /// <param name="fault">Fault that will be added.</param>
    public static void AddFault(Fault fault)
        => Faults.Add(fault);

    /// <summary>
    /// Removes a fault by ID. It assumes there <b>is</b> a fault with such ID,
    /// otherwise you'll be met with an unhandled <see cref="NullReferenceException" />.
    /// </summary>
    /// <param name="id">Fault ID.</param>
    public static void RemoveFaultByID(int id)
        => Faults.RemoveAt(Faults.IndexOf(Faults.Where(f => f.ID == id).First()!));

    /// <summary>
    /// Clears all faults.
    /// </summary>
    public static void DismissAll()
        => Faults.Clear();

    /// <summary>
    /// Gets a fault by ID.
    /// </summary>
    /// <param name="id">ID of the fault.</param>
    /// <returns>Fault with an ID if it was found, <see langword="null" /> otherwise.</returns>
    public static Fault? GetElementByID(int id)
        => Faults.Where(f => f.ID == id).FirstOrDefault();

    /// <summary>
    /// Generates an unoccupied ID for a fault.
    /// </summary>
    /// <returns>A fault ID that is safe to use.</returns>
    public static int GenerateFaultID()
    {
        int id = Random.Shared.Next(0, int.MaxValue);

        while (GetElementByID(id) != null)
        {
            id = Random.Shared.Next(0, int.MaxValue);
        }

        return id;
    }
}
