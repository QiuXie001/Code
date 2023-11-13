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
    SqStack S;
    InitStack(S);
    while (N) {
        int remainder = N % base;
        Push(S, remainder);  // ��������ջ
        N = N / base;
    }
    while (!StackEmpty(S)) {
        int num;
        Pop(S, num);  // ��ջȡ����
        printf("%d", num);  // ������
    }
    printf("\n");
   return ;
}
int  main(){
    printf("1. ��֤�������ܣ���ջ����ջ��ջ����ջ�գ�:\n");
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
    printf("��ջԪ�أ�%d\n", e);
    Pop(S, e);
    printf("��ջԪ�أ�%d\n", e);
    if (StackEmpty(S)) {
        printf("ջΪ��\n");
    }
    else {
        printf("ջ��Ϊ��\n");
    }
    printf("\n");

    printf("2. �����㷨��ʮ������ת��������������ı�ʾ:\n");
    int N = 4769;
    printf("2���Ʊ�ʾ��");
    conversion(N, 2);
    printf("16���Ʊ�ʾ��");
    conversion(N, 16);
    printf("\n");

    printf("3. �������ݵ���֤:\n");
    char str1[] = "abccba";
    if (HUIWEN(str1)) {
        printf("%s �ǻ�������\n", str1);
    }
    else {
        printf("%s ���ǻ�������\n", str1);
    }
    char str2[] = "abcdcba";
    if (HUIWEN(str2)) {
        printf("%s �ǻ�������\n", str2);
    }
    else {
        printf("%s ���ǻ�������\n", str2);
    }
    char str3[] = "abcdba";
    if (HUIWEN(str3)) {
        printf("%s �ǻ�������\n", str3);
    }
    else {
        printf("%s ���ǻ�������\n", str3);
    }
    printf("\n");

    printf("4. ����IO����֤���ĺϷ���:\n");
    char str4[] = "IIIOIOOO";
    if (IO(str4)) {
        printf("%s �ǺϷ���\n", str4);
    }
    else {
        printf("%s ���ǺϷ���\n", str4);
    }
    char str5[] = "IOOIIIOO";
    if (IO(str5)) {
        printf("%s �ǺϷ���\n", str5);
    }
    else {
        printf("%s ���ǺϷ���\n", str5);
    }
    return 0;
}

