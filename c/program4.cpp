// 实验四  二叉树的基本操作的实现，二叉树的建立、先、中、后的遍历
//增加:用队列方式实现层次遍历,用递归方法实现统计树的结点数、叶子数、高度.
//编写主函数，验证结果 
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
	printf("\n先序遍历：");
	Pre(T);
	printf("\n中序遍历： ");
	In(T);
	printf("\n后序遍历： ");
	Post(T);
	printf("\n层次遍历： ");
	Level(T);
	printf("\n节点数： %d\n", Nodes(T));
	printf("叶子数： %d\n", Leafs(T));
	printf("高度：%d\n", Depth(T));
	
	printf("\n");
	return 0;
}

