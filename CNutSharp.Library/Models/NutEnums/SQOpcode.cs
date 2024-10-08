﻿namespace CNutSharp.Library.Models.NutEnums;

public enum SQOpcode : byte
{
    _OP_LINE = 0x00,
    _OP_LOAD = 0x01,
    _OP_LOADINT = 0x02,
    _OP_LOADFLOAT = 0x03,
    _OP_DLOAD = 0x04,
    _OP_TAILCALL = 0x05,
    _OP_CALL = 0x06,
    _OP_PREPCALL = 0x07,
    _OP_PREPCALLK = 0x08,
    _OP_GETK = 0x09,
    _OP_MOVE = 0x0A,
    _OP_NEWSLOT = 0x0B,
    _OP_DELETE = 0x0C,
    _OP_SET = 0x0D,
    _OP_GET = 0x0E,
    _OP_EQ = 0x0F,
    _OP_NE = 0x10,
    _OP_ADD = 0x11,
    _OP_SUB = 0x12,
    _OP_MUL = 0x13,
    _OP_DIV = 0x14,
    _OP_MOD = 0x15,
    _OP_BITW = 0x16,
    _OP_RETURN = 0x17,
    _OP_LOADNULLS = 0x18,
    _OP_LOADROOT = 0x19,
    _OP_LOADBOOL = 0x1A,
    _OP_DMOVE = 0x1B,
    _OP_JMP = 0x1C,
    //_OP_JNZ=0x1D,
    _OP_JCMP = 0x1D,
    _OP_JZ = 0x1E,
    _OP_SETOUTER = 0x1F,
    _OP_GETOUTER = 0x20,
    _OP_NEWOBJ = 0x21,
    _OP_APPENDARRAY = 0x22,
    _OP_COMPARITH = 0x23,
    _OP_INC = 0x24,
    _OP_INCL = 0x25,
    _OP_PINC = 0x26,
    _OP_PINCL = 0x27,
    _OP_CMP = 0x28,
    _OP_EXISTS = 0x29,
    _OP_INSTANCEOF = 0x2A,
    _OP_AND = 0x2B,
    _OP_OR = 0x2C,
    _OP_NEG = 0x2D,
    _OP_NOT = 0x2E,
    _OP_BWNOT = 0x2F,
    _OP_CLOSURE = 0x30,
    _OP_YIELD = 0x31,
    _OP_RESUME = 0x32,
    _OP_FOREACH = 0x33,
    _OP_POSTFOREACH = 0x34,
    _OP_CLONE = 0x35,
    _OP_TYPEOF = 0x36,
    _OP_PUSHTRAP = 0x37,
    _OP_POPTRAP = 0x38,
    _OP_THROW = 0x39,
    _OP_NEWSLOTA = 0x3A,
    _OP_GETBASE = 0x3B,
    _OP_CLOSE = 0x3C,
}
