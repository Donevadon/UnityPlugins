package com.oland.log;

public class Log {
    public static void debugLog(String tag,String message)
    {
        android.util.Log.i(tag,message);
    }
}
