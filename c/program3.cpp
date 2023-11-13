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
typedef struct{
	SElemType *base;
	SElemType *top;
	int stacksize;
}SqStack;
Status InitStack(SqStack &S){
	S.base=new SElemType[MAXSIZE];
	if(!S.base) return ERROR;
	S.top=S.base;
	S.stacksize=MAXSIZE;
	return OK;
}
Status Push(SqStack &S,SElemType e){
	if(S.top-S.base==S.stacksize)  return ERROR;
	*S.top++=e;
	return OK;
}
Status Pop(SqStack &S, SElemType &e){
	if(S.top==S.base)  return ERROR;
	e=*--S.top;
	return OK;
}
Status StackEmpty(SqStack S){
	if(S.base==S.top)  return OK;
	else  return ERROR;
}
Status StackPrn(SqStack s) {
	if(s.base==s.top )   return ERROR;
	SElemType  *p;
	for(p=s.base;p<s.top;p++)
	      printf("%d",*p);
	printf("\n");
	return OK;
}
Status HUIWEN(char *c){
	return OK;	
}
Status IO(char *c){
	return OK;
}
void conversion(int N,int base){
    SqStack S;
    InitStack(S);
    while (N) {
        int remainder = N % base;
        Push(S, remainder);  // 将余数入栈
        N = N / base;
    }
    while (!StackEmpty(S)) {
        int num;
        Pop(S, num);  // 出栈取余数
        printf("%d", num);  // 输出结果
    }
    printf("\n");
   return ;
}
int  main(){
    printf("1. 验证基本功能（入栈、出栈、栈满、栈空）:\n");
    SqStack S;
    InitStack(S);
    Push(S, 10);
    Push(S, 20);
    Push(S, 30);
    Push(S, 40);
    Push(S, 50);
    Push(S, 60);
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
    int N = 4769;
    printf("2进制表示：");
    conversion(N, 2);
    printf("16进制表示：");
    conversion(N, 16);
    printf("\n");

    printf("3. 回文数据的验证:\n");
    char str1[] = "abccba";
    if (HUIWEN(str1)) {
        printf("%s 是回文数据\n", str1);
    }
    else {
        printf("%s 不是回文数据\n", str1);
    }
    char str2[] = "abcdcba";
    if (HUIWEN(str2)) {
        printf("%s 是回文数据\n", str2);
    }
    else {
        printf("%s 不是回文数据\n", str2);
    }
    char str3[] = "abcdba";
    if (HUIWEN(str3)) {
        printf("%s 是回文数据\n", str3);
    }
    else {
        printf("%s 不是回文数据\n", str3);
    }
    printf("\n");

    printf("4. 输入IO串验证串的合法性:\n");
    char str4[] = "IIIOIOOO";
    if (IO(str4)) {
        printf("%s 是合法串\n", str4);
    }
    else {
        printf("%s 不是合法串\n", str4);
    }
    char str5[] = "IOOIIIOO";
    if (IO(str5)) {
        printf("%s 是合法串\n", str5);
    }
    else {
        printf("%s 不是合法串\n", str5);
    }
    return 0;
}

