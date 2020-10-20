// Placeholder class to avoid conflicts 

public static class DominoHash
{
    public static string DominoBase64Encode(int v, int n)
    {
        var itoa64 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz+/";

        var ret = "";

        while ((n - 1) >= 0)
        {
            n -= 1;
            ret = itoa64.Substring(v & 0x3f, 1) + ret;
            v >>= 6;
        }

        return ret;
    }

    public static string DominoEncode(byte[] final)
    {
        var byte10 = final[3] + 4;
        if (byte10 > 255)
        {
            byte10 -= 256;
        }

        final[3] = (byte) byte10;

        var passwd = "";

        for (var i = 0; i < 15; i += 3)
        {
            passwd += DominoBase64Encode((final[i] << 16) | (final[i+1] << 8) | final[i+2], 4);
        }

        return passwd.Remove(passwd.Length - 1, 1);
    }
}