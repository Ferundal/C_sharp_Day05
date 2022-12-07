using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace d05.Nasa
{
    public interface INasaClient<in TIn, out TOut>
    {
        TOut GetAsync(TIn input);
    }
}