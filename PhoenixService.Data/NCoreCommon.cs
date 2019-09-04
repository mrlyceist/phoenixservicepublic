using System;
using NCore;

namespace PhoenixService.Data
{
    public static class NCoreCommon
    {
        public static string Sys2015()
        {
            return NCore.Common.Sys2015();
        }

        public static string CreateDiscardCode()
        {
            return NCore.Common.CreateDiscardCode();
        }
    }
}