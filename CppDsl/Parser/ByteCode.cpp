﻿#include "ByteCode.h"
#include "DslParser.h"

using namespace DslParser;

class TestRuntimeBuilder : public RuntimeBuilderT < TestRuntimeBuilder >
{
    using BaseType = RuntimeBuilderT<TestRuntimeBuilder>;
public:
    char* getLastToken() const { return const_cast<char*>(""); }
    int getLastLineNumber() const { return 0; }
    int getCommentNum(int& commentOnNewLine) const { commentOnNewLine; return 0; }
    char* getComment(int index) const { index; return const_cast<char*>(""); }
    void resetComments() {}
    void setCanFinish(int val) { val; }
    void setStringDelimiter(const char* begin, const char* end) { begin, end; }
    void setScriptDelimiter(const char* begin, const char* end) { begin, end; }
public:
    TestRuntimeBuilder(DslFile& dataFile) :BaseType(dataFile)
    {}
};

void CompileTest_ByteCode()
{
    DslStringAndObjectBufferT<> buffer;
    DslFile dataFile(buffer);
    TestRuntimeBuilder builder(dataFile);
    builder.addFunction();
    builder.beginStatement();
    builder.buildFirstTernaryOperator();
    builder.buildHighOrderFunction();
    builder.buildOperator();
    builder.buildSecondTernaryOperator();
    builder.endStatement();
    builder.markBracketParam();
    builder.markStatement();
    builder.markExternScript();
    builder.markBracketColonParam();
    builder.markParenthesisColonParam();
    builder.markAngleBracketColonParam();
    builder.markBracePercentParam();
    builder.markBracketPercentParam();
    builder.markParenthesisPercentParam();
    builder.markAngleBracketPercentParam();
    builder.setExternScript();
    builder.markParenthesisParam();
    builder.markPeriodBraceParam();
    builder.markPeriodBracketParam();
    builder.markPeriodParam();
    builder.markPeriodParenthesisParam();
    builder.setMemberId();
    builder.setCanFinish(false);
    builder.setFunctionId();
    builder.setMemberId();
    builder.markQuestionPeriodParam();
    builder.markQuestionParenthesisParam();
    builder.markQuestionBracketParam();
    builder.markQuestionBraceParam();
    builder.markPointerParam();
    builder.markPeriodStarParam();
    builder.markQuestionPeriodStarParam();
    builder.markPointerStarParam();
}