﻿namespace CNutSharp.Library.Models.NutEnums;

public enum SQObjTypeField
{
    _RT_NULL = 0x00000001,
    _RT_INTEGER = 0x00000002,
    _RT_FLOAT = 0x00000004,
    _RT_BOOL = 0x00000008,
    _RT_STRING = 0x00000010,
    _RT_TABLE = 0x00000020,
    _RT_ARRAY = 0x00000040,
    _RT_USERDATA = 0x00000080,
    _RT_CLOSURE = 0x00000100,
    _RT_NATIVECLOSURE = 0x00000200,
    _RT_GENERATOR = 0x00000400,
    _RT_USERPOINTER = 0x00000800,
    _RT_THREAD = 0x00001000,
    _RT_FUNCPROTO = 0x00002000,
    _RT_CLASS = 0x00004000,
    _RT_INSTANCE = 0x00008000,
    _RT_WEAKREF = 0x00010000,
    _RT_OUTER = 0x00020000,
}