//实验3栈的基本功能，
//1验证基本功能（入栈、出栈、栈满、栈空）
//输入6个数（10,20,30,40,50,60）入栈，出栈2个，验证栈满、栈空
//2增加算法：十进制数转换成任意进制数的表示,十进制数4769，转化成2进制和16进制数；
//2---- 0001 0010 1010 0001   16----12A1; 
//
//3回文数据的验证；abccba,abcdcba,--- yes; abcdba,--no
//4输入IO串验证串的合法性；注意此时元素类型应该是字符型； 
//IIIOIOOO--yes;  IOOIIIOO--no;
#include<stdio.h>
#include<stdlib.h>
#include<string.h>////////
#define OK   1
#define ERROR  0
typedef char SElemType;//////////
typedef  int Status;  ///////
#define MAXSIZE  100
typedef struct {
    SElemType* base;
    SElemType* top;
    int stacksize;
}SqStack;
Status InitStack(SqStack& S) {
    S.base = new SElemType[MAXSIZE];
    if (!S.base) return ERROR;
    S.top = S.base;
    S.stacksize = MAXSIZE;
    return OK;
}
Status Push(SqStack& S, SElemType e) {
    if (S.top - S.base == S.stacksize)  return ERROR;
    *S.top++ = e;
    return OK;
}
Status Pop(SqStack& S, SElemType& e) {
    if (S.top == S.base)  return ERROR;
    e = *--S.top;
    return OK;
}
Status StackEmpty(SqStack S) {
    if (S.base == S.top)  return OK;
    else  return ERROR;
}
Status StackPrn(SqStack s) {
    if (s.base == s.top)   return ERROR;
    SElemType* p;
    for (p = s.base; p < s.top; p++)
        printf("%d", *p);
    printf("\n");
    return OK;
}
Status HUIWEN(char* c) {
    int len = strlen(c); 
    int start = 0; 
    int end = len - 1; 
    while (start <= end)
    {
        if (c[start] != c[end]) 
        { return ERROR; } 
        start++; end--;
    } 
    return OK;
}
Status IO(char* c) {
    int start = 0;
    while (c[start] != '\0')
    {
        int len = strlen(c);
        int count_i = 0, count_o = 0;
        for (int i = 0; i < len; i++) {
            if (c[i] == 'I') {
                count_i++;
            }
            else if (c[i] == 'O') {
                count_o++;
            }
            else {
                return ERROR;
            }
            start++;
        }
        if (count_i == count_o || count_i == count_o + 1) {
            return OK;
        }
        else {
            return ERROR;
        }
    }
}
void conversion(int N, int base) {
    SqStack S;
    InitStack(S);
    while (N) {
        int remainder = N % base;
        Push(S, remainder);  // 将余数入栈
        N = N / base;
    }
    while (!StackEmpty(S)) {
        char num;
        Pop(S, num);  // 出栈取余数
        printf("%d", num);  // 输出结果
    }
    printf("\n");
    return;
}
int  main() {
    printf("1. 验证基本功能（入栈、出栈、栈满、栈空）:\n");
    SqStack S;
    InitStack(S);
    int num = 0;
    for (int i = 0; i < 6; i++)
    {  
        scanf_s("%d",&num);
        Push(S,num);
    };
    SElemType e;
    Pop(S, e);
    printf("出栈元素：%d\n", e);
    Pop(S, e);
    printf("出栈元素：%d\n", e);
    if (StackEmpty(S)) {
        printf("栈为空\n");
    }
    else {
        printf("栈不为空\n");
    }
    printf("\n");

    printf("2. 增加算法：十进制数转换成任意进制数的表示:\n");
    int N = 0;
    scanf_s("%d", &N);
    printf("2进制表示：");
    conversion(N, 2);
    printf("16进制表示：");
    conversion(N, 16);
    getchar();
    printf("\n");

    printf("3. 回文数据的验证:\n");
    char str1[100];
    int count = 0;
    gets_s(str1);
    if (HUIWEN(str1)) {
        printf("%s是回文数据\n",str1);
    }
    else {
        printf("%s不是回文数据\n",str1);
    }
    printf("\n");

    printf("4. 输入IO串验证串的合法性:\n");
    char str4[100];
    gets_s(str4);
    if (IO(str4)) {
        printf("%s是合法串\n",str4);
    }
    else {
        printf("%s不是合法串\n",str4);
    }
    
    return 0;
}

