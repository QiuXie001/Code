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
int Count(SString S,SString T,int pos){//ͳ���ִ�T�����ڴ�S�еĴ����� 
	 
	return 1;
}
int StrCompare(SString S,SString T){//�Ƚ��ַ���S��T�Ĵ�С����λ�Ƚϴ�С�����ز�ֵ�� 
	return OK;
}
Status StrInsert(SString &S,SString T,int pos){
	//�����ַ������ڴ�S��pos��ʼ��λ���ϲ��봮T�� 
	
	return OK;
}
Status StrCat(SString &S,SString T) {//����T�����ӵ���S��β���� 
	return OK;
}
int  main(){
	return 1;
}



