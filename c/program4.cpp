// ʵ����  �������Ļ���������ʵ�֣��������Ľ������ȡ��С���ı���
//����:�ö��з�ʽʵ�ֲ�α���,�õݹ鷽��ʵ��ͳ�����Ľ������Ҷ�������߶�.
//��д����������֤��� 
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
	if (T == NULL) {
		return 0;
	}
	return Nodes(T->lchild) + Nodes(T->rchild) + 1;
}
int Leafs(BiTree T){
	if (T == NULL) {
		return 0;
	}
	if (T->lchild == NULL && T->rchild == NULL) {
		return 1;
	}
	return Leafs(T->lchild) + Leafs(T->rchild);
}
int Depth(BiTree T){
	if (T == NULL) {
		return 0;
	}
	else {
		int left_depth = Depth(T->lchild);
		int right_depth = Depth(T->rchild);
		return (left_depth > right_depth) ? (left_depth + 1) : (right_depth + 1);
	}
}
void  Level(BiTree T){
	BiTree Queue[100];
	int front = 0, rear = 0;
	Queue[rear++] = T;
	while (front != rear)
	{
		BiTree x;
		x = Queue[front++];
		putchar(x->data);
		if (x->lchild) Queue[rear++] = x->lchild;
		if (x->rchild) Queue[rear++] = x->rchild;
	}
}
int main(){
	BiTree T = NULL;
	Create(T);
	printf("\n���������");
	Pre(T);
	printf("\n��������� ");
	In(T);
	printf("\n��������� ");
	Post(T);
	printf("\n��α����� ");
	Level(T);
	printf("\n�ڵ����� %d\n", Nodes(T));
	printf("Ҷ������ %d\n", Leafs(T));
	printf("�߶ȣ�%d\n", Depth(T));
	
	printf("\n");
	return 0;
}

