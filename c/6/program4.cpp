// ʵ����  �������Ļ���������ʵ�֣��������Ľ������ȡ��С���ı���
//����:�ö��з�ʽʵ�ֲ�α���,�õݹ鷽��ʵ��ͳ�����Ľ������Ҷ�������߶�.
//��д����������֤��� 
//���� ���һ��ϵͳ
#include<stdio.h>
#include<stdlib.h>
#define OK   1
#define ERROR  0
typedef  int  Status;
typedef  char TElemType;
typedef  struct BiTNode{
	TElemType  data;
	struct BiTNode  *lchild,*rchild;
}BiTNode,*BiTree;
void  In(BiTree T){
	if(T){
		In(T->lchild);
		putchar(T->data);
		In(T->rchild);
	}
}
void  Pre(BiTree T){
	if(T){
		putchar(T->data);
		Pre(T->lchild);
		Pre(T->rchild);
	}
}
void  Post(BiTree T){
	if(T){
		Post(T->lchild);
		Post(T->rchild);
		putchar(T->data);
	}
}
void Create(BiTree &T){
	char ch=getchar();
	if(ch=='#')  T=NULL;
	else{
		T=new BiTNode;
		T->data=ch;
		Create(T->lchild);
		Create(T->rchild);
	}
}
int Nodes(BiTree T){
	return 1;
}
int Leafs(BiTree T){
	return 1;
}
int Depth(BiTree T){
	return 1;
}
void  Level(BiTree T){
	return ;
}
void main(){
	;
}

