// ----------------------------------------------------------------------------
// (c) 2022 Ruzsinszki Gábor
// This code is licensed under MIT license (see LICENSE for details)
// ----------------------------------------------------------------------------

namespace FFConvert.Interfaces;

internal interface IValidator
{
    (bool status, string errorMessage) Validate(string input, IDictionary<string, string> parameters);
}
