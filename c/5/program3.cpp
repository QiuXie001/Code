//ʵ��3ջ�Ļ������ܣ�
//1��֤�������ܣ���ջ����ջ��ջ����ջ�գ�
//����6������10,20,30,40,50,60����ջ����ջ2������֤ջ����ջ��
//2�����㷨��ʮ������ת��������������ı�ʾ,ʮ������4769��ת����2���ƺ�16��������
//2---- 0001 0010 1010 0001   16----12A1; 
//
//3�������ݵ���֤��abccba,abcdcba,--- yes; abcdba,--no
//4����IO����֤���ĺϷ��ԣ�ע���ʱԪ������Ӧ�����ַ��ͣ� 
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

