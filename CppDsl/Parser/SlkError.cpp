/*****************************************************************************

    SlkError.cpp

    ******************************************************************************/

#include "DslParser.h"
#include "SlkInc.h"
#include "SlkParse.h"
#include "tsnprintf.h"

using namespace DslParser;

//mScanner,mErrorInfo由构造函数的引用参数传入，不会为空。所以使用时不再检查是否为空。

#define GET_SYMBOL_NAME        SlkGetSymbolName

short SlkError::mismatch(short terminal, short token, SlkToken& tokens)
{
    if (mDslFile) {
        char* p = mDslFile->NewErrorInfo();
        if (p)
            tsnprintf(p, mDslFile->GetSingleErrorInfoCapacity(), "[line:%d last:%s cur:%s] expecting '%s' but found '%s' \n",
                tokens.getLineNumber(),
                tokens.getLastToken(),
                tokens.getCurToken(),
                GET_SYMBOL_NAME(terminal),
                GET_SYMBOL_NAME(token));
    }
    return token;
}

short SlkError::no_entry(short productionNumber, short nonterminal, short token, int level, SlkToken& tokens)
{
    productionNumber, nonterminal, level;
    if (mDslFile) {
        char* p = mDslFile->NewErrorInfo();
        if (p)
            tsnprintf(p, mDslFile->GetSingleErrorInfoCapacity(), "[line:%d last:%s cur:%s] syntax error: skipping input '%s' \n",
                tokens.getLineNumber(),
                tokens.getLastToken(),
                tokens.getCurToken(),
                GET_SYMBOL_NAME(token));

        token = tokens.get();// advance the input
        return token;
    }
    else {
        return 0;
    }
}

void SlkError::input_left(SlkToken& tokens)
{
    if (mDslFile) {
        char* p = mDslFile->NewErrorInfo();
        if (p)
            tsnprintf(p, mDslFile->GetSingleErrorInfoCapacity(), "[line:%d last:%s cur:%s] syntax completion, skipping left . \n",
                tokens.getLineNumber(),
                tokens.getLastToken(),
                tokens.getCurToken());
    }
}

void SlkError::message(const char* msg, SlkToken& tokens)
{
    if (mDslFile) {
        char* p = mDslFile->NewErrorInfo();
        if (p)
            tsnprintf(p, mDslFile->GetSingleErrorInfoCapacity(), "[line:%d last:%s cur:%s] %s . \n",
                tokens.getLineNumber(),
                tokens.getLastToken(),
                tokens.getCurToken(),
                msg);
    }
}

SlkError::SlkError(DslParser::DslFile& dslFile) :mDslFile(&dslFile)
{
    MyAssert(mDslFile);
}