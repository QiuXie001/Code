//�������������һ��ϵͳ��
//ʵ��������   �ַ�����Ӧ��
//1�������Ѿ������ָ�����ݽṹ�ĸ�ֵ�����������������ģʽƥ���㷨�� 
//2��ͬѧ��ɲ��롢�Ƚϡ�ͳ�ơ����ӵȲ����� 
//3�����������Ҫ��
//   ��1����ֵ2������"chinese","china",�����������ȷ�ԣ�
//    (2)�Ƚ�����������С�����ݱȽϽ��������Ĵ��������
//    (3)����2���������뵽��1���ĵ�5��λ��ǰ������������
//    (4)����2�����ӵ���1����β��������������
//    (5)ͳ���ִ���is����������this is fistiskis ok"�г��ֵĴ�����
 
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#define OK   1
#define ERROR  0
typedef  int  Status;
#define MAXLEN  255
typedef  struct{
    char  ch[MAXLEN+1];
    int length;
}SString;

int Index(SString S,SString T,int pos){//�����ִ�
    int i=pos,j=1;
    while(i<=S.length&&j<=T.length){
        if(S.ch[i]==T.ch[j]){i++;j++;}
        else {i=i-j+2;  j=1;}
    }
    if(j>T.length) return i-T.length;
    else  return 0;
}

Status StrAssign(SString &T,char *ch){//���ĸ�ֵ
    int i=0;
    while(ch[i]){ //while(ch[i]!='\0')
        T.ch[i+1]=ch[i]; i++;
    }
    T.length=i;
    return OK;
}

void Prn(SString S){
    for(int i=1;i<=S.length;i++)
        putchar(S.ch[i]);
    printf("\n");
}

int StrCompare(SString S,SString T){//�Ƚ��ַ���S��T�Ĵ�С����λ�Ƚϴ�С�����ز�ֵ�� 
    int len=S.length < T.length ? S.length : T.length;
    for(int i=1; i<=len; i++){
        if(S.ch[i] != T.ch[i]) return S.ch[i] - T.ch[i];
    }
    return S.length - T.length;
}

Status StrInsert(SString &S,SString T,int pos){//�����ַ������ڴ�S��pos��ʼ��λ���ϲ��봮T�� 
    if(pos<1 || pos >S.length+1 || S.length+T.length>MAXLEN) return ERROR;
    for(int i=S.length; i>=pos; i--){
        S.ch[i+T.length] = S.ch[i];
    }
    for(int i=pos, j=1; j<=T.length; i++, j++){
        S.ch[i] = T.ch[j];
    }
    S.length += T.length;
    return OK;
}

Status StrCat(SString &S,SString T) {//����T�����ӵ���S��β���� 
    if(S.length + T.length > MAXLEN) return ERROR;
    for(int i=1, j=S.length+1; i<=T.length; i++, j++){
        S.ch[j] = T.ch[i];
    }
    S.length += T.length;
    return OK;
}

int Count(SString S,SString T,int pos){//ͳ���ִ�T�����ڴ�S�еĴ����� 
    int count=0;
    int i=pos;
    while(i<=S.length){
        int index = Index(S, T, i);
        if(index==0) break;
        count++;
        i=index+1;
    }
    return count;
}

int  main(){
    SString S, T;
    char ch[] = "chinese";
    char ch2[] = "china";
    StrAssign(S, ch);
    Prn(S);
    StrAssign(T, ch2);
    Prn(T);
    int result = StrCompare(S, T);
    if(result > 0){
        Prn(S);
    }else if(result < 0){
        Prn(T);
    }else{
        printf("Equal!\n");
    }
    StrInsert(S, T, 5);
    Prn(S);
	StrAssign(S, ch);
	StrAssign(T, ch2);
    StrCat(S, T);
    Prn(S);
    char ch3[] = "this is fistiskis ok";
    SString S1, T1;
    StrAssign(S1, ch3);
    char ch4[] = "is";
    StrAssign(T1, ch4);
    int count = Count(S1, T1, 1);
    printf("count=%d\n", count);
    return 0;
}