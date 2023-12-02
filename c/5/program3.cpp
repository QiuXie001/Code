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
	
   return ;
}
int  main(){
	printf("hello\n");
	return 1;
}

