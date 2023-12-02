// 实验四  二叉树的基本操作的实现，二叉树的建立、先、中、后的遍历
//增加:用队列方式实现层次遍历,用递归方法实现统计树的结点数、叶子数、高度.
//编写主函数，验证结果 
//开机 最后一个系统
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

